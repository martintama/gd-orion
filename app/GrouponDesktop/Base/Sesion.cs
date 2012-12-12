using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    static class Sesion
    {
        static public Object EntidadLogueada { get; set; }
        static public Int16 Idtipo_usuario { get; set; }
        static public LoginStatus EstadoLogin { get; set; }
        public static DateTime currentDate;

        public enum LoginStatus{
            login_exitoso,
            login_datos_incorrectos,
            login_inhabilitado
        }

        public static LoginStatus ValidarUsuario(String usuario, String passhashed)
        {
            Int32 idasociado = 0;
            Dbaccess.DBConnect();

            SqlCommand sqlc = new SqlCommand("orion.Usuarios_Loguear", Dbaccess.globalConn);
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;

            sqlc.Parameters.AddWithValue("@username", usuario);
            sqlc.Parameters.AddWithValue("@passhashed", passhashed);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            if (dr1.Read())
            {
                Idtipo_usuario = Convert.ToInt16(dr1["idtipo_usuario"]);
                switch (Idtipo_usuario)
                {
                    case -1: //Login Inhabilitado
                        {
                            EstadoLogin = LoginStatus.login_inhabilitado;
                            break;
                        }
                    case 0: //Datos invalidos
                        {
                            EstadoLogin = LoginStatus.login_datos_incorrectos;
                            break;
                        }
                    case 1: //administrativo
                        {
                            Administrativo unAdministrativo = new Administrativo();
                            unAdministrativo.UsuarioAsociado.Idusuario = Convert.ToInt32(dr1["idusuario"]);
                            unAdministrativo.UsuarioAsociado.RolAsociado = new Rol(Convert.ToInt32(dr1["idrol"]), "-");
                            unAdministrativo.UsuarioAsociado.TipoUsuarioAsociado = new TipoUsuario(Convert.ToInt16(dr1["idtipo_usuario"]), "-");

                            EntidadLogueada = unAdministrativo;
                            EstadoLogin = LoginStatus.login_exitoso;
                            break;
                        }
                    case 2: //Cliente
                        {
                            idasociado = Convert.ToInt32(dr1["idcliente"]);
                            break;
                        }
                    case 3: //Proveedor
                        {
                            idasociado = Convert.ToInt32(dr1["idproveedor"]);
                            break;
                        }
                }

                dr1.Close();
                dr1.Dispose();


            }
            else
            {
                throw new Exception("Error conectando a base de datos");
            }

            dr1.Close();
            dr1.Dispose();

            switch(Idtipo_usuario)
            {
                case 1: //Administrativo
                    {
                        ((Administrativo)EntidadLogueada).UsuarioAsociado.RolAsociado.GetFuncionalidades();
                        break;
                    }
                case 2: //Cliente
                    {
                        Cliente unCliente = Cliente.GetCliente(idasociado);
                        unCliente.UsuarioAsociado.RolAsociado.GetFuncionalidades();
                        EntidadLogueada = unCliente;
                        EstadoLogin = LoginStatus.login_exitoso;
                        break;
                    }
                case 3: //Proveedor
                    {
                        Proveedor unProveedor = Proveedor.BuscaProveedor(idasociado);
                        unProveedor.UsuarioAsociado.RolAsociado.GetFuncionalidades();
                        EntidadLogueada = unProveedor;

                        EstadoLogin = LoginStatus.login_exitoso;
                        break;
                    }
            }

            dr1.Close();
            dr1.Dispose();

            Dbaccess.DBDisconnect();

            return EstadoLogin;
        }

        public static Usuario GetUsuarioAsociado()
        {
            Usuario usuarioRetorno = new Usuario();
            switch (Idtipo_usuario)
            {
                case 1: //administrativo
                    {
                        usuarioRetorno = ((Administrativo)EntidadLogueada).UsuarioAsociado;
                        break;
                    }
                case 2: //Cliente
                    {
                        usuarioRetorno = ((Cliente)EntidadLogueada).UsuarioAsociado;
                        break;
                    }
                case 3: //Proveedor
                    {
                        usuarioRetorno = ((Proveedor)EntidadLogueada).UsuarioAsociado;
                        break;
                    }
            }

            return usuarioRetorno;
        }

        public static void CerrarSesion(){
            Usuario unUsuario = GetUsuarioAsociado();
            unUsuario.Username = "";
            unUsuario.Idusuario = 0;
            unUsuario.RolAsociado = null;
            unUsuario.TipoUsuarioAsociado = null;
        }
    }
}
