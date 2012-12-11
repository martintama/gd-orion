using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    public class Proveedor
    {
        // CONSTRUCTORES
        public Proveedor()
        {
            this.UsuarioAsociado = new Usuario();
            this.Ciudad = new Ciudad();
            this.Rubro = new Rubro();
        }

        // PROPIEDADES
        public Int32 Idproveedor { get; set; }

        public String RazonSocial { get; set; }

        public String Mail { get; set; }

        public String Telefono { get; set; }

        public String Direccion { get; set; }

        public String CodPostal { get; set; }

        public Ciudad Ciudad { get; set; }

        public String Cuit { get; set; }

        public Rubro Rubro { get; set; }

        public String Contacto { get; set; }

        public Usuario UsuarioAsociado { get; set; }

        //METODOS
        public static List<Proveedor> BuscarProveedor(){
            return BuscarProveedor("", "", "",false,0);
        }

        public static Proveedor BuscaProveedor(Int32 idproveedor)
        {
            return BuscarProveedor("","","",false,idproveedor)[0];
        }
        public static List<Proveedor> BuscarProveedor(String razonSocial, String cuit, String email, Boolean soloHabilitados, Int32 idproveedor){
            List<Proveedor> listaProveedores = new List<Proveedor>();

            Dbaccess.DBConnect();

            String sqlwhere = "1=1 ";
            if (razonSocial != "")
                sqlwhere += "and p.razon_social like '%' + @razonsocial + '%' ";
            
            if (cuit != "")
                sqlwhere += "and p.cuit = @cuit ";
            
            if (email != "")
                sqlwhere += "and p.email like '%' + @email + '%' ";

            if (idproveedor > 0)
                sqlwhere += "and p.idproveedor = @idproveedor ";

            String sqlstr = "select p.idproveedor, p.razon_social, p.email, p.telefono, p.direccion, p.codigo_postal, ";
            sqlstr += "p.idciudad, c.descripcion ciudad, p.cuit, p.idrubro, r.descripcion rubro, ";
	        sqlstr += "p.contacto, p.idusuario, u.idrol, ro.descripcion rol,  u.idtipo_usuario, u.username, u.habilitado usuario_habilitado ";
            sqlstr += "from orion.proveedores p left join orion.ciudades c on c.idciudad = p.idciudad 	left join orion.rubros r on r.idrubro = p.idrubro ";
            sqlstr += "left join orion.usuarios u on u.idusuario = p.idusuario left join orion.roles ro on ro.idrol = u.idrol where " + sqlwhere + " order by p.razon_social";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            
            if (razonSocial != "")
                sqlc.Parameters.AddWithValue("@razonsocial", razonSocial);

            if (cuit != "")
                sqlc.Parameters.AddWithValue("@cuit", cuit);

            if (email != "")
                sqlc.Parameters.AddWithValue("@email", email);

            if (idproveedor > 0)
                sqlc.Parameters.AddWithValue("@idproveedor", idproveedor);
                
            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                Proveedor unProveedor = new Proveedor();
                unProveedor.Idproveedor = Convert.ToInt32(dr1["idproveedor"]);
                unProveedor.RazonSocial = dr1["razon_social"].ToString();
                unProveedor.Mail = dr1["email"].ToString();
                unProveedor.Telefono = dr1["telefono"].ToString();
                unProveedor.Direccion = dr1["direccion"].ToString();
                unProveedor.CodPostal = dr1["codigo_postal"].ToString();
                unProveedor.Ciudad.Idciudad = Convert.ToInt32(dr1["idciudad"]);
                unProveedor.Ciudad.Descripcion = dr1["ciudad"].ToString();
                unProveedor.Cuit = dr1["cuit"].ToString();
                unProveedor.Rubro.Idrubro = Convert.ToInt16(dr1["idrubro"]);
                unProveedor.Rubro.Descripcion = dr1["rubro"].ToString();
                unProveedor.Contacto = dr1["contacto"].ToString();
                unProveedor.UsuarioAsociado.Idusuario = Convert.ToInt32(dr1["idusuario"]);
                unProveedor.UsuarioAsociado.Username = dr1["username"].ToString();
                unProveedor.UsuarioAsociado.RolAsociado.Idrol = Convert.ToInt32(dr1["idrol"]);
                unProveedor.UsuarioAsociado.RolAsociado.NombreRol = dr1["rol"].ToString();
                unProveedor.UsuarioAsociado.TipoUsuarioAsociado.Idtipo_usuario = Convert.ToInt16(dr1["idtipo_usuario"]);
                if (Convert.ToBoolean(dr1["usuario_habilitado"].ToString()))
                {
                    unProveedor.UsuarioAsociado.Habilitado = true;
                }
                else{
                    unProveedor.UsuarioAsociado.Habilitado = false;
                }

                listaProveedores.Add(unProveedor);
            }

            dr1.Close();
            dr1.Dispose();
            Dbaccess.DBDisconnect();

            return listaProveedores;
        }

        internal short Grabar()
        {
            Int16 return_value = 0; //Supongo que todo está bien

            Dbaccess.DBConnect();
            SqlTransaction tran = Dbaccess.globalConn.BeginTransaction();

            try
            {

                return_value = this.UsuarioAsociado.Grabar(Dbaccess.globalConn, tran);

                if (return_value == 0) //Si no hay problemas
                {

                    SqlCommand cmd = new SqlCommand("Orion.Proveedores_Grabar", Dbaccess.globalConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tran;

                    cmd.Parameters.AddWithValue("@razon_social", this.RazonSocial);
                    cmd.Parameters.AddWithValue("@mail", this.Mail);
                    cmd.Parameters.AddWithValue("@telefono", this.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", this.Direccion);
                    cmd.Parameters.AddWithValue("@codpost", this.CodPostal);
                    cmd.Parameters.AddWithValue("@idciudad", this.Ciudad.Idciudad);
                    cmd.Parameters.AddWithValue("@cuit", this.Cuit);
                    cmd.Parameters.AddWithValue("@idrubro", this.Rubro.Idrubro);
                    cmd.Parameters.AddWithValue("@contacto", this.Contacto);
                    cmd.Parameters.AddWithValue("@idusuario", this.UsuarioAsociado.Idusuario);

                    SqlParameter returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    SqlParameter idproveedorParam = cmd.Parameters.AddWithValue("@idproveedor", this.Idproveedor);
                    idproveedorParam.Direction = ParameterDirection.InputOutput;

                    cmd.ExecuteNonQuery();

                    return_value = Convert.ToInt16(returnParameter.Value);
                    
                    cmd.Dispose();

                    if (return_value == 0)
                    {
                        this.Idproveedor = Convert.ToInt32(idproveedorParam.Value);
                        tran.Commit();
                    }
                    else
                    {
                        return_value = -2; //Datos duplicados
                        tran.Rollback();

                    }
                    
                }
                else
                {
                    return_value = -1; //Usuarios ya existentes
                    tran.Rollback();

                }

            }
            catch (Exception ex)
            {

                tran.Rollback();
                return_value = -3;

            }

            tran.Dispose();
            Dbaccess.DBDisconnect();

            return return_value;
        }



        internal void Inhabilitar()
        {
            if (this.UsuarioAsociado.Idusuario > 0)
            {
                this.UsuarioAsociado.Inhabilitar();
            }
        }

        internal void Habilitar()
        {
            if (this.UsuarioAsociado.Idusuario > 0)
            {
                this.UsuarioAsociado.Habilitar();
            }
        }
    }


}
