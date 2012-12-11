using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    public class Cliente
    {
        // CONSTRUCTORES
        public Cliente()
        {
            this.Ciudades = new List<Ciudad>();
            this.UsuarioAsociado = new Usuario();

            this.Ciudades = new List<Ciudad>();
            this.CiudadesDisponibles = new List<Ciudad>();
        }

        // PROPIEDADES
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

        // METODOS
        internal short Grabar()
        {
            Int16 return_value = 0; //Supongo que todo está bien

            Dbaccess.DBConnect();
            SqlTransaction tran = Dbaccess.globalConn.BeginTransaction();
            
            try
            {

                return_value = this.UsuarioAsociado.Grabar(Dbaccess.globalConn, tran);

                if (return_value == 0) //Si no ay problemas
                {

                    SqlCommand cmd = new SqlCommand("Orion.Clientes_Grabar", Dbaccess.globalConn);
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

                    SqlParameter returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    SqlParameter idclienteParam = cmd.Parameters.AddWithValue("@idcliente", this.Idcliente);
                    idclienteParam.Direction = ParameterDirection.InputOutput;

                    cmd.ExecuteNonQuery();
                   
                    return_value = Convert.ToInt16(returnParameter.Value);
                    

                    cmd.Dispose();

                    //Finalmente, si hasta acá está todo OK, grabo las ciudades preferidas y listo. 
                    if (return_value == 0)
                    {
                        this.Idcliente = Convert.ToInt32(idclienteParam.Value);

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
                        tran.Rollback();
                        
                    }
                    
                }
                else
                {
                    return_value = 1; //Usuarios ya existentes
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

        internal static Cliente GetCliente(Int32 idcliente)
        {
            return GetClientes("", "", -1, "",false,idcliente)[0];
        }

        internal static List<Cliente> GetClientes()
        {
            //Va -1 porque el usuario no puede cargar numeros negativos
            return GetClientes("", "", -1, "");
        }

        internal static List<Cliente> GetClientes(String nombre, String apellido, Int32 dni, String email)
        {
            return GetClientes("", "", -1, "", false, 0);
        }
        
        internal static List<Cliente> GetClientes(String nombre, String apellido, Int32 dni, String email, Boolean soloHabilitados, Int32 idcliente)
        {
            List<Cliente> listaClientes = new List<Cliente>();

            Dbaccess.DBConnect();

            String sqlwhere = "c.idusuario > 0 ";
            if (nombre != "")
                sqlwhere += "and c.nombre like @nombre ";

            if (apellido != "")
                sqlwhere += "and c.apellido like @apellido ";

            if (dni >= 0)
                sqlwhere += "and c.dni = @dni ";

            if (email != "")
                sqlwhere += "and c.email like @email ";
            
            if (soloHabilitados)
                sqlwhere += "and u.habilitado = 1 ";

            if (idcliente >= 0)
                sqlwhere += "and c.idcliente = @idcliente ";

            String sqlstr = "select c.idcliente, c.nombre, c.apellido, c.dni, c.email, c.telefono, c.direccion, c.codigo_postal, ";
            sqlstr += "Convert(char(10),c.fecha_nacimiento,102) fecha_nacimiento, u.idrol, r.descripcion nombrerol,  u.idusuario, u.clave, c.credito_actual, ";
            sqlstr += "cc.idciudad, ci.descripcion ciudad, u.idusuario, u.username, u.habilitado as usuario_habilitado, tu.idtipo_usuario, tu.descripcion tipo_usuario from ORION.clientes c  ";
            sqlstr += "left join ORION.clientes_ciudades cc on cc.idcliente = c.idcliente left join ORION.ciudades ci on ci.idciudad = cc.idciudad ";
            sqlstr += "left join ORION.usuarios u on u.idusuario = c.idusuario left join ORION.roles r on r.idrol = u.idrol ";
            sqlstr += "left join ORION.tipos_usuario tu on tu.idtipo_usuario = u.idtipo_usuario ";
            sqlstr += "where " + sqlwhere + " order by c.nombre, c.apellido, c.dni";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);

            if (nombre != "")
                sqlc.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

            if (apellido != "")
                sqlc.Parameters.AddWithValue("@apellido", "%" + apellido + "%");

            if (dni >= 0)
                sqlc.Parameters.AddWithValue("@dni", dni);

            if (email != "")
                sqlc.Parameters.AddWithValue("@email", "%" + email + "%");

            if (idcliente >= 0)
                sqlc.Parameters.AddWithValue("@idcliente", idcliente) ;
            
            SqlDataReader dr1 = sqlc.ExecuteReader();

            //Hago un corte de control para cargar las ciudades
            Boolean hayDatos;
            Int32 idcliente_actual = 0;

            if (dr1.Read())
            {
                idcliente_actual = Convert.ToInt32(dr1["idcliente"]);
                hayDatos = true;
            }
            else
                hayDatos = false;

            while (hayDatos)
            {
                Cliente unCliente = new Cliente();
                unCliente.Idcliente = idcliente_actual;
                unCliente.Nombre = dr1["nombre"].ToString();
                unCliente.Apellido = dr1["apellido"].ToString();
                unCliente.Mail = dr1["email"].ToString();
                unCliente.DNI = Convert.ToInt32(dr1["dni"]);
                unCliente.Direccion = dr1["direccion"].ToString();
                unCliente.CodPostal = dr1["codigo_postal"].ToString();
                unCliente.Telefono = dr1["telefono"].ToString();

                unCliente.FechaNacimiento = DateTime.ParseExact(dr1["fecha_nacimiento"].ToString(), "yyyy.MM.dd", null);
                unCliente.UsuarioAsociado.Idusuario = Convert.ToInt32(dr1["idusuario"].ToString());
                unCliente.UsuarioAsociado.Username = dr1["username"].ToString();
                unCliente.UsuarioAsociado.Habilitado = Convert.ToBoolean(dr1["usuario_habilitado"].ToString());
                unCliente.UsuarioAsociado.RolAsociado = new Rol(Convert.ToInt32(dr1["idrol"]), dr1["nombrerol"].ToString());
                unCliente.UsuarioAsociado.TipoUsuarioAsociado = new TipoUsuario(Convert.ToInt16(dr1["idtipo_usuario"]), dr1["tipo_usuario"].ToString());


                while (hayDatos && unCliente.Idcliente == idcliente_actual)
                {

                    unCliente.Ciudades.Add(new Ciudad(Convert.ToInt32(dr1["idciudad"]), dr1["ciudad"].ToString()));

                    if (dr1.Read())
                    {
                        idcliente_actual = Convert.ToInt32(dr1["idcliente"]);
                    }
                    else
                    {
                        hayDatos = false;
                    }
                }

                listaClientes.Add(unCliente);
            }

            dr1.Close();
            dr1.Dispose();

            sqlc.Dispose();

            Dbaccess.DBConnect();

            return listaClientes;
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

