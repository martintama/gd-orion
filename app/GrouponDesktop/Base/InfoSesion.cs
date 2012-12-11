using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class InfoSesion
    {
        public Object EntidadLogueada { get; set; }
        public Int16 Idtipo_usuario { get; set; }
        public LoginStatus EstadoLogin { get; set; }
        
        public InfoSesion(){
            this.EstadoLogin = LoginStatus.login_exitoso;
        }
        public enum LoginStatus{
            login_exitoso,
            login_datos_incorrectos,
            login_inhabilitado
        }

        public void ValidarUsuario(String usuario, String passhashed)
        {
            clsMain.objInfoSesion = new InfoSesion();

            Dbaccess.DBConnect();

            SqlCommand sqlc = new SqlCommand("orion.LoguearUsuario", Dbaccess.globalConn);
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;

            sqlc.Parameters.AddWithValue("@username", usuario);
            sqlc.Parameters.AddWithValue("@passhashed", passhashed);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            if (dr1.Read())
            {
                this.Idtipo_usuario = Convert.ToInt16(dr1["idtipo_usuario"]);
                switch (this.Idtipo_usuario)
                {
                    case -1: //Login Inhabilitado
                        {
                            this.EstadoLogin = LoginStatus.login_inhabilitado;
                            break;
                        }
                    case 0: //Datos invalidos
                        {
                            this.EstadoLogin = LoginStatus.login_datos_incorrectos;
                            break;
                        }
                    case 1: //administrativo
                        {
                            Administrativo unAdministrativo = new Administrativo();
                            unAdministrativo.UsuarioAsociado.Idusuario = Convert.ToInt32(dr1["idusuario"]);
                            unAdministrativo.UsuarioAsociado.RolAsociado = new Rol(Convert.ToInt32(dr1["idrol"]), "-");
                            unAdministrativo.UsuarioAsociado.TipoUsuarioAsociado = new TipoUsuario(Convert.ToInt16(dr1["idtipo_usuario"]), "-");
                            unAdministrativo.UsuarioAsociado.RolAsociado.GetFuncionalidades();

                            this.EntidadLogueada = unAdministrativo;
                            this.EstadoLogin = LoginStatus.login_exitoso;
                            break;
                        }
                    case 2: //Cliente
                        {
                            Cliente unCliente = Cliente.GetCliente(Convert.ToInt32(dr1["idusuario"]));
                            unCliente.UsuarioAsociado.RolAsociado.GetFuncionalidades();
                            this.EntidadLogueada = unCliente;
                            this.EstadoLogin = LoginStatus.login_exitoso;
                            break;
                        }
                    case 3: //Proveedor
                        {
                            Proveedor unProveedor = Proveedor.BuscaProveedor(Convert.ToInt32(dr1["idusuario"]));
                            this.EntidadLogueada = unProveedor;

                            this.EstadoLogin = LoginStatus.login_exitoso;
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

            Dbaccess.DBDisconnect();

        }

        public Usuario GetUsuarioAsociado()
        {
            Usuario usuarioRetorno = new Usuario();
            switch (this.Idtipo_usuario)
            {
                case 1: //administrativo
                    {
                        usuarioRetorno = ((Administrativo)this.EntidadLogueada).UsuarioAsociado;
                        break;
                    }
                case 2: //Cliente
                    {
                        usuarioRetorno = ((Cliente)this.EntidadLogueada).UsuarioAsociado;
                        break;
                    }
                case 3: //Proveedor
                    {
                        usuarioRetorno = ((Proveedor)this.EntidadLogueada).UsuarioAsociado;
                        break;
                    }
            }

            return usuarioRetorno;
        }
    }
}
