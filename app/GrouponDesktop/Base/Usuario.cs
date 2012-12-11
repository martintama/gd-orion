using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    public class Usuario
    {
        // CONTRUCTORES
        public Usuario()
        {
            this.RolAsociado = new Rol();
            this.TipoUsuarioAsociado = new TipoUsuario();
        }

        // PROPIEDADES
        public int Idusuario { get; set; }

        public String Username { get; set; }

        public String Clave { get; set; }

        public Rol RolAsociado { get; set; }

        public TipoUsuario TipoUsuarioAsociado { get; set; }

        public Boolean Habilitado { get; set; }

        // METODOS
        public Int16 Grabar(SqlConnection sqlconn, SqlTransaction sqltran){
            SqlCommand cmd = new SqlCommand("Orion.Usuarios_Grabar", sqlconn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = sqltran;
            
            cmd.Parameters.AddWithValue("@username", this.Username);
            if (this.Clave != "")
            {
                cmd.Parameters.AddWithValue("@pass", Hasher.ConvertirSHA256(this.Clave));
            }
            cmd.Parameters.AddWithValue("@idrol", this.RolAsociado.Idrol);
            cmd.Parameters.AddWithValue("@idtipo_usuario", this.TipoUsuarioAsociado.Idtipo_usuario);

            SqlParameter returnParameter;
            returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            SqlParameter idusuarioParameter;
            idusuarioParameter = cmd.Parameters.AddWithValue("@idusuario", this.Idusuario);
            idusuarioParameter.Direction = ParameterDirection.InputOutput;

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            this.Idusuario = Convert.ToInt32(idusuarioParameter.Value);
            return Convert.ToInt16(returnParameter.Value);
            
        }

        internal void Inhabilitar()
        {
            if (this.Idusuario > 0)
            {
                Dbaccess.DBConnect();

                String sqlstr = "update orion.usuarios set habilitado = 0 where idusuario = @idusuario";

                SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idusuario", this.Idusuario);

                sqlc.ExecuteNonQuery();

                sqlc.Dispose();

                Dbaccess.DBDisconnect();
            }
        }

        internal void Habilitar()
        {
            if (this.Idusuario > 0)
            {
                Dbaccess.DBConnect();

                String sqlstr = "update orion.usuarios set habilitado = 1 where idusuario = @idusuario";

                SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idusuario", this.Idusuario);

                sqlc.ExecuteNonQuery();

                sqlc.Dispose();

                Dbaccess.DBDisconnect();
            }
        }

        public static Object GetEntidadAsociada(Int32 idusuario)
        {
            Object objetoRetorno = new Object();
            Usuario usuarioRetorno = new Usuario();

            Int16 idtipo_usuario = 0;
            Int32 idasociado = 0;

            if (idusuario > 0)
            {
                Dbaccess.DBConnect();

                String sqlstr = "select u.idusuario, u.idtipo_usuario, u.idrol, c.idcliente, p.idproveedor from ORION.usuarios u ";
                sqlstr += "left join ORION.clientes c on c.idusuario = u.idusuario left join ORION.proveedores p on p.idusuario = u.idusuario ";
                sqlstr += "where u.idusuario = @idusuario";

                SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idusuario", idusuario);

                SqlDataReader dr1 = sqlc.ExecuteReader();

                if (dr1.Read()){
                    idtipo_usuario = Convert.ToInt16(dr1["idtipo_usuario"]);

                    switch (idtipo_usuario)
                    {
                        case 1: //Administrativo
                            {
                                //No tiene ningun dato asociado...
                                usuarioRetorno = new Usuario();
                                usuarioRetorno.Idusuario = idusuario;
                                usuarioRetorno.RolAsociado = new Rol(Convert.ToInt32(dr1["idrol"]), "-");

                                usuarioRetorno.TipoUsuarioAsociado = new TipoUsuario(Convert.ToInt16(dr1["idtipo_usuario"]), "-");

                               
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
                }
                else{
                    throw new Exception("Usuario sin tipo usuario");
                }
                dr1.Close();
                dr1.Dispose();
                sqlc.Dispose();


                Dbaccess.DBDisconnect();

                switch (idtipo_usuario)
                {
                    case 1: //Administrativo
                        {
                            Administrativo unAdministrativo = new Administrativo();
                            usuarioRetorno.RolAsociado.GetFuncionalidades();
                            unAdministrativo.UsuarioAsociado = usuarioRetorno;
                            objetoRetorno = unAdministrativo;
                            break;
                        }
                    case 2: //Cliente
                        {
                            objetoRetorno = Cliente.GetCliente(idasociado);
                            break;
                        }
                    case 3: //Proveedor
                        {
                            objetoRetorno = Proveedor.BuscaProveedor(idasociado);
                            break;
                        }
                }
            }

            return objetoRetorno;
        }
    }
}
