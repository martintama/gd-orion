using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GrouponDesktop.Logic.Global
{
    public class Cliente
    {
        public Cliente()
        {
            this.Ciudades = new List<Ciudad>();
            this.UsuarioAsociado = new Usuario();

            this.Ciudades = new List<Ciudad>();
            this.CiudadesDisponibles = new List<Ciudad>();
        }

        public Int32 Idcliente { get; set; }

        public String Nombre { get; set; }

        public String Apellido { get; set; }

        public Int32 DNI { get; set; }

        public String Mail { get; set; }

        public String Telefono { get; set; }

        public String Direccion { get; set; }

        public String CodPostal { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public List<Ciudad> Ciudades { get; set; }

        public List<Ciudad> CiudadesDisponibles { get; set; }

        public Usuario UsuarioAsociado { get; set; }

        public Boolean Habilitado { get; set; }

        internal short Grabar()
        {
            Int16 return_value = 0; //Supongo que todo está bien

            Dbaccess.DBConnect();
            SqlTransaction tran = Dbaccess.globalConn.BeginTransaction();
            
            try
            {

                SqlCommand cmd = new SqlCommand("Orion.Usuarios_Grabar", Dbaccess.globalConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tran;

                cmd.Parameters.AddWithValue("@username", this.UsuarioAsociado.Username);
                cmd.Parameters.AddWithValue("@pass", Hasher.ConvertirSHA256(this.UsuarioAsociado.Clave));
                cmd.Parameters.AddWithValue("@idrol", this.UsuarioAsociado.RolAsociado.Idrol);
                cmd.Parameters.AddWithValue("@idtipo_usuario", this.UsuarioAsociado.TipoUsuarioAsociado.Idtipo_usuario);

                SqlParameter returnParameter;
                returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                SqlParameter idusuarioParameter;
                idusuarioParameter = cmd.Parameters.AddWithValue("@idusuario", this.UsuarioAsociado.Idusuario);
                idusuarioParameter.Direction = ParameterDirection.InputOutput;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return_value = Convert.ToInt16(returnParameter.Value);
                this.UsuarioAsociado.Idusuario = Convert.ToInt32(idusuarioParameter.Value);
                
                if (return_value == 0) //Si no ay problemas
                {

                    cmd = new SqlCommand("Orion.Clientes_Grabar", Dbaccess.globalConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tran;

                    cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", this.Apellido);
                    cmd.Parameters.AddWithValue("@dni", this.DNI);
                    cmd.Parameters.AddWithValue("@mail", this.Mail);
                    cmd.Parameters.AddWithValue("@telefono", this.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", this.Direccion);
                    cmd.Parameters.AddWithValue("@codpost", this.CodPostal);
                    cmd.Parameters.AddWithValue("@fechanac", this.FechaNacimiento.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@idusuario", this.UsuarioAsociado.Idusuario);

                    returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    SqlParameter idclienteParam = cmd.Parameters.AddWithValue("@idcliente", this.Idcliente);
                    idclienteParam.Direction = ParameterDirection.InputOutput;

                    cmd.ExecuteNonQuery();
                   
                    return_value = Convert.ToInt16(returnParameter.Value);
                    this.Idcliente = Convert.ToInt32(idclienteParam.Value);

                    cmd.Dispose();

                    //Finalmente, si hasta acá está todo OK, grabo las ciudades preferidas y listo. 
                    if (return_value == 0)
                    {
                        //Borro antes todas las ciudades y las recreo
                        String sqlstr = "Delete from orion.clientes_ciudades where idcliente = @idcliente";
                        cmd = new SqlCommand(sqlstr, Dbaccess.globalConn);
                        cmd.Transaction = tran;
                        cmd.Parameters.AddWithValue("@idcliente", this.Idcliente);

                        cmd.ExecuteNonQuery();

                        cmd.Dispose();

                        sqlstr = "Insert into orion.clientes_ciudades(idcliente, idciudad) values(@idcliente, @idciudad);";
                        cmd = new SqlCommand(sqlstr, Dbaccess.globalConn);
                        cmd.Transaction = tran;
                        cmd.Parameters.Add("@idcliente", SqlDbType.Int);
                        cmd.Parameters.Add("@idciudad", SqlDbType.Int);
                        cmd.Prepare();

                        foreach (Ciudad item in this.Ciudades)
                        {
                            cmd.Parameters["@idcliente"].Value = this.Idcliente;
                            cmd.Parameters["@idciudad"].Value = item.Idciudad;
                            cmd.ExecuteNonQuery();
                        }
                        cmd.Dispose();

                        tran.Commit();
                    }
                    else
                    {
                        return_value = 2; //Datos duplicados
                        this.UsuarioAsociado.Idusuario = 0; //Reseteo el idusuario
                        tran.Rollback();
                        
                    }
                    
                }
                else
                {
                    return_value = 1; //Usuarios ya existentes
                    this.UsuarioAsociado.Idusuario = 0; //Reseteo el idusuario
                    tran.Rollback();
                    
                }

            }
            catch (Exception ex)
            {
                
                tran.Rollback();
                return_value = 3;           
                
            }
            
            tran.Dispose();
            Dbaccess.DBDisconnect();

            return return_value;
        }


        internal void GetCiudades()
        {
            Dbaccess.DBConnect();

            if (this.Idcliente > 0)
            {
                //Traigo ciudades habilitadas
                String sqlstr = "select idciudad, descripcion from ORION.ciudades ";
                sqlstr += "where idciudad in (select idciudad from ORION.clientes_ciudades where idcliente = @idcliente and activo = 1) and activo = 1 order by descripcion;";

                SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idcliente", this.Idcliente);

                SqlDataReader dr1 = sqlc.ExecuteReader();

                while (dr1.Read())
                {
                    this.Ciudades.Add(new Ciudad(
                        Convert.ToInt32(dr1["idciudad"]), dr1["descripcion"].ToString().Trim()));
                }

                dr1.Close();
                sqlc.Dispose();

                //Traigo funcionalidades deshablitadas
                sqlstr = "select idciudad, descripcion from ORION.ciudades ";
                sqlstr += "where idciudad not in (select idciudad from ORION.clientes_ciudades where idcliente = @idcliente and activo = 1) and activo = 1 order by descripcion;";

                sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idcliente", this.Idcliente);

                dr1 = sqlc.ExecuteReader();
                while (dr1.Read())
                {
                    this.Ciudades.Add(new Ciudad(
                        Convert.ToInt32(dr1["idciudad"]), dr1["descripcion"].ToString().Trim()));
                }

                dr1.Close();
                sqlc.Dispose();

            }

            Dbaccess.DBDisconnect();
            
        }

        internal void Inhabilitar()
        {
            if (this.Idcliente > 0)
            {
                Dbaccess.DBConnect();

                String sqlstr = "update orion.clientes set activo = 0 where idcliente = @idcliente";

                SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idcliente", this.Idcliente);

                sqlc.ExecuteNonQuery();

                sqlc.Dispose();

                Dbaccess.DBDisconnect();
            }
        }

        internal void Habilitar()
        {
            if (this.Idcliente > 0)
            {
                Dbaccess.DBConnect();

                String sqlstr = "update orion.clientes set activo = 1 where idcliente = @idcliente";

                SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idcliente", this.Idcliente);

                sqlc.ExecuteNonQuery();

                sqlc.Dispose();

                Dbaccess.DBDisconnect();
            }
        }
    }
}

