using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GrouponDesktop.Logic.Global
{
    public class Rol
    {
        public class Funcionalidad
        {
            public Funcionalidad(Int32 id, String descrip)
            {
                this.idfuncionalidad = id;
                this.Descripcion = descrip;
            }

            public Int32 idfuncionalidad { get; set; }

            public String Descripcion { get; set; }
        }

        public Rol()
        {
            this.FuncHabilitadas = new List<Funcionalidad>();
            this.FuncInhabilitadas = new List<Funcionalidad>();
        }
        public String NombreRol { get; set; }

        public Int32 Idrol { get; set; }

        public bool Estado { get; set; }

        public List<Funcionalidad> FuncHabilitadas { get; set; }

        public List<Funcionalidad> FuncInhabilitadas { get; set; }

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

            }
            else
            {
                //Es un alta
                sqlstr = "Insert into orion.roles(descripcion) values(@descripcion)";

                sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@descripcion", this.NombreRol);
                sqlc.ExecuteNonQuery();
                sqlc.Dispose();
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
                sqlstr += "where f.idfuncionalidad in (select idfuncionalidad from ORION.roles_funcionalidades where idrol = @idrol and habilitado = 1) order by f.descripcion";

                SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idrol", this.Idrol);

                SqlDataReader dr1 = sqlc.ExecuteReader();

                while (dr1.Read())
                {
                    this.FuncHabilitadas.Add(new Rol.Funcionalidad(
                        Convert.ToInt32(dr1["idfuncionalidad"]), dr1["descripcion"].ToString()));
                }

                dr1.Close();
                sqlc.Dispose();

                //Traigo funcionalidades deshablitadas
                sqlstr = "select f.idfuncionalidad, f.descripcion from ORION.funcionalidades f ";
                sqlstr += "where f.idfuncionalidad not in (select idfuncionalidad from ORION.roles_funcionalidades where idrol = @idrol and habilitado = 1) order by f.descripcion";

                sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idrol", this.Idrol);

                dr1 = sqlc.ExecuteReader();
                while (dr1.Read())
                {
                    this.FuncInhabilitadas.Add(new Rol.Funcionalidad(
                        Convert.ToInt32(dr1["idfuncionalidad"]), dr1["descripcion"].ToString()));
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
                    this.FuncInhabilitadas.Add(new Rol.Funcionalidad(
                        Convert.ToInt32(dr1["idfuncionalidad"]), dr1["descripcion"].ToString()));
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
    }
}
