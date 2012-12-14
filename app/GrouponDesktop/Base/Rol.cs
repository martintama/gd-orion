using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    public class Rol
    {
        // CONTRUCTORES
        public Rol()
        {
            this.FuncHabilitadas = new List<Funcionalidad>();
            this.FuncInhabilitadas = new List<Funcionalidad>();
            this.TipoUsuarioAsociados = new List<TipoUsuario>();
        }

        public Rol(Int32 idrol, String descripcion)
        {
            this.Idrol = idrol;
            this.NombreRol = descripcion;
            this.FuncHabilitadas = new List<Funcionalidad>();
            this.FuncInhabilitadas = new List<Funcionalidad>();
            this.TipoUsuarioAsociados = new List<TipoUsuario>();
        }

        // PROPIEDADES
        public String NombreRol { get; set; }

        public Int32 Idrol { get; set; }

        public bool Estado { get; set; }

        public List<Funcionalidad> FuncHabilitadas { get; set; }

        public List<Funcionalidad> FuncInhabilitadas { get; set; }
        
        public List<TipoUsuario> TipoUsuarioAsociados { get; set; }

        // METODOS
        public List<Rol> GetRoles()
        {
            return this.GetRoles("");
        }

        public List<Rol> GetRoles(String filtro)
        {
            List<Rol> listaRoles = new List<Rol>();

            Dbaccess.DBConnect();

            SqlCommand sqlc = new SqlCommand("orion.Roles_Obtener", Dbaccess.globalConn);
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;

            sqlc.Parameters.AddWithValue("@filtro", filtro);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                Rol unRol = new Rol();
                unRol.Idrol = Convert.ToInt32(dr1["idrol"]);
                unRol.NombreRol = dr1["descripcion"].ToString();
                unRol.Estado = Convert.ToBoolean(dr1["Estado"]);

                if (dr1["Administrativo"].ToString() == "S")
                {
                    unRol.TipoUsuarioAsociados.Add(new TipoUsuario(1, null));
                }

                if (dr1["Cliente"].ToString() == "S")
                {
                    unRol.TipoUsuarioAsociados.Add(new TipoUsuario(2, null));
                }

                if (dr1["Proveedor"].ToString() == "S")
                {
                    unRol.TipoUsuarioAsociados.Add(new TipoUsuario(3, null));
                }
                listaRoles.Add(unRol);
            }

            dr1.Close();
            dr1.Dispose();

            sqlc.Dispose();

            Dbaccess.DBConnect();

            return listaRoles;
        }

        public Int16 GrabarRol()
        {

            Dbaccess.DBConnect();

            Int16 retvalue = 0;
            String sqlstr = "";
            SqlCommand sqlc;
            
            if (this.Idrol > 0)
            {
                //Si tengo el idrol quiere decir que es una MODIFICACION
                sqlstr = "Update orion.roles set descripcion = @descripcion where idrol = @idrol";
                sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
   
                sqlc.Parameters.AddWithValue("@idrol", this.Idrol);
                sqlc.Parameters.AddWithValue("@descripcion", this.NombreRol);
                sqlc.ExecuteNonQuery();
                sqlc.Dispose();

                //Reseteo todo
                sqlstr = "Delete from orion.roles_funcionalidades where idrol = @idrol";
                sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idrol", this.Idrol);
                sqlc.ExecuteNonQuery();
                sqlc.Dispose();

                sqlstr = "Delete from orion.tipos_usuario_rol where idrol = @idrol";
                sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idrol", this.Idrol);
                sqlc.ExecuteNonQuery();
                sqlc.Dispose();
            }
            else
            {
                

                sqlc = new SqlCommand("Orion.Roles_Crear", Dbaccess.globalConn);
                sqlc.CommandType = CommandType.StoredProcedure;
                SqlParameter idrolParameter;
                idrolParameter = sqlc.Parameters.AddWithValue("@idrol", this.Idrol);
                idrolParameter.Direction = ParameterDirection.InputOutput;

                //sqlc.Parameters.AddWithValue("@descripcion", this.NombreRol);
                sqlc.Parameters.AddWithValue("@descripcion", "AAA");

                sqlc.ExecuteNonQuery();
                sqlc.Dispose();

                this.Idrol = Convert.ToInt32(idrolParameter.Value);
            }

            //Agrego las funcionalidades
            sqlstr = "Insert into orion.roles_funcionalidades(idrol, idfuncionalidad) values(@idrol, @idfuncionalidad)";
            sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.Add("@idrol", SqlDbType.Int);
            sqlc.Parameters.Add("@idfuncionalidad", SqlDbType.Int);
            sqlc.Prepare();

            foreach (Funcionalidad func in this.FuncHabilitadas)
            {
                sqlc.Parameters["@idrol"].Value = this.Idrol;
                sqlc.Parameters["@idfuncionalidad"].Value = func.idfuncionalidad;
                sqlc.ExecuteNonQuery();
            }
            sqlc.Dispose();

            //Y agrego los tipos de usuario asociados
            sqlstr = "Insert into orion.tipos_usuario_rol(idrol, idtipo_usuario) values(@idrol, @idtipo_usuario)";
            sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.Add("@idrol", SqlDbType.Int);
            sqlc.Parameters.Add("@idtipo_usuario", SqlDbType.Int);
            sqlc.Prepare();

            foreach (TipoUsuario tipo in this.TipoUsuarioAsociados)
            {
                sqlc.Parameters["@idrol"].Value = this.Idrol;
                sqlc.Parameters["@idtipo_usuario"].Value = tipo.Idtipo_usuario;
                sqlc.ExecuteNonQuery();
            }
            sqlc.Dispose();

            Dbaccess.DBDisconnect();

            return retvalue;
        }

        public Int16 InhabilitarRol()
        {
            return this.InhabilitarRol(false);
        }

        public Int16 InhabilitarRol(bool forzar)
        {
            Dbaccess.DBConnect();

            SqlCommand cmd = new SqlCommand("Orion.Roles_Inhabilitar", Dbaccess.globalConn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter returnParameter;
            
            cmd.Parameters.AddWithValue("@idrol", this.Idrol);
            cmd.Parameters.AddWithValue("@forzar", forzar);
            
            returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();

            Dbaccess.DBDisconnect();

            return Convert.ToInt16(returnParameter.Value);

        }

        public void GetFuncionalidades()
        {

            Dbaccess.DBConnect();

            if (this.Idrol > 0)
            {
                //Traigo funcionalidades habilitadas
                String sqlstr = "select f.idfuncionalidad, f.descripcion from ORION.funcionalidades f ";
                sqlstr += "where f.idfuncionalidad in (select idfuncionalidad from ORION.roles_funcionalidades where idrol = @idrol) order by f.descripcion";

                SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idrol", this.Idrol);

                SqlDataReader dr1 = sqlc.ExecuteReader();

                while (dr1.Read())
                {
                    this.FuncHabilitadas.Add(new Funcionalidad(
                        Convert.ToInt32(dr1["idfuncionalidad"]), dr1["descripcion"].ToString().Trim()));
                }

                dr1.Close();
                sqlc.Dispose();

                //Traigo funcionalidades deshablitadas
                sqlstr = "select f.idfuncionalidad, f.descripcion from ORION.funcionalidades f ";
                sqlstr += "where f.idfuncionalidad not in (select idfuncionalidad from ORION.roles_funcionalidades where idrol = @idrol) order by f.descripcion";

                sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idrol", this.Idrol);

                dr1 = sqlc.ExecuteReader();
                while (dr1.Read())
                {
                    this.FuncInhabilitadas.Add(new Funcionalidad(
                        Convert.ToInt32(dr1["idfuncionalidad"]), dr1["descripcion"].ToString().Trim()));
                }

                dr1.Close();
                sqlc.Dispose();

                ////Traigo el nombre
                //sqlstr = "select descripcion from ORION.roles where idrol = @idrol;";

                //sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                //sqlc.Parameters.AddWithValue("@idrol", objRol.Idrol);

                //dr1 = sqlc.ExecuteReader();
                //while (dr1.Read())
                //{
                //    objRol.NombreRol = dr1["descripcion"].ToString();
                //}

                //dr1.Close();
                //sqlc.Dispose();
            }
            else
            {
                //Traigo todas las funcionalidades y las pongo como deshabilitadas en el caso de que sea un nuevo usuario
                String sqlstr = "select f.idfuncionalidad, f.descripcion from ORION.funcionalidades f order by f.descripcion";

                SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);

                SqlDataReader dr1 = sqlc.ExecuteReader();

                while (dr1.Read())
                {
                    this.FuncInhabilitadas.Add(new Funcionalidad(
                        Convert.ToInt32(dr1["idfuncionalidad"]), dr1["descripcion"].ToString().Trim()));
                }

                dr1.Close();
                sqlc.Dispose();
            }
            Dbaccess.DBDisconnect();
            
        }

        internal void HabilitarRol()
        {
            Dbaccess.DBConnect();

            String sqlstr = "Update orion.roles set habilitado = 1 where idrol = @idrol";
            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);

            sqlc.Parameters.AddWithValue("@idrol", this.Idrol);
            sqlc.ExecuteNonQuery();
            sqlc.Dispose();

            Dbaccess.DBDisconnect();
        }

        public bool AsociadoATipoUsuario(Int16 idtipo_usuario)
        {
            Boolean esta = false;

            Int16 indice = 0;

            while (indice < this.TipoUsuarioAsociados.Count && !esta)
            {
                if (this.TipoUsuarioAsociados[indice].Idtipo_usuario == idtipo_usuario)
                {
                    esta = true;
                }

                indice++;
            }

            return esta;
        }

        internal static List<Rol> getRoles(short idtipo_usuario)
        {
            List<Rol> listaRoles = new List<Rol>();

            Dbaccess.DBConnect();
            String sqlstr = "select r.idrol, r.descripcion from orion.roles r where r.idrol in (select idrol from orion.tipos_usuario_rol where idtipo_usuario = @idtipo_usuario)";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.AddWithValue("@idtipo_usuario", idtipo_usuario);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                Rol unRol = new Rol();
                unRol.Idrol = Convert.ToInt32(dr1["idrol"]);
                unRol.NombreRol = dr1["descripcion"].ToString();

                listaRoles.Add(unRol);
            }

            dr1.Close();
            sqlc.Dispose();

            Dbaccess.DBDisconnect();

            return listaRoles;
        }
    }
}
