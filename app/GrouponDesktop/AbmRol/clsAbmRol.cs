using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace GrouponDesktop.AbmRol
{
    class clsAbmRol
    {
        public DataTable GetRoles(){
            return this.GetRoles("");
        }

        public DataTable GetRoles(String filtro)
        {
            DataTable tablaDatos = new DataTable();

            Dbaccess.DBConnect();

            SqlCommand sqlc = new SqlCommand("orion.Roles_Obtener", Dbaccess.globalConn);
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;

            sqlc.Parameters.AddWithValue("@filtro", filtro);

            SqlDataAdapter da1 = new SqlDataAdapter(sqlc);
            da1.Fill(tablaDatos);

            da1.Dispose();
            Dbaccess.DBConnect();

            return tablaDatos;
        }

        public Int16 InhabilitarRol(Int32 idrol)
        {
            Dbaccess.DBConnect();

            SqlCommand cmd = new SqlCommand("Orion.Roles_Inhabilitar", Dbaccess.globalConn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;
            SqlParameter returnParameter;

            param = cmd.Parameters.AddWithValue("@idrol", idrol);
            param.Direction = ParameterDirection.Input;


            returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();
            
            return Convert.ToInt16(returnParameter.Value);

        }

        public ClsRol GetRol(Int32 idrol)
        {
            ClsRol objRol = new ClsRol();
           
            Dbaccess.DBConnect();

            //Traigo funcionalidades habilitadas
            String sqlstr = "select f.idfuncionalidad, f.descripcion from ORION.funcionalidades f ";
            sqlstr += "where f.idfuncionalidad in (select idfuncionalidad from ORION.roles_funcionalidades where idrol = @idrol and habilitado = 1)";
              
            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.AddWithValue("@idrol", idrol);

            SqlDataReader dr1 = sqlc.ExecuteReader();
            
            while (dr1.Read()){
                objRol.FuncHabilitadas.Add(new ClsRol.Funcionalidad(
                    Convert.ToInt32(dr1["idfuncionalidad"]), dr1["descripcion"].ToString()));
            }

            dr1.Close();
            sqlc.Dispose();

            //Traigo funcionalidades deshablitadas
            sqlstr = "select f.idfuncionalidad, f.descripcion from ORION.funcionalidades f ";
            sqlstr += "where f.idfuncionalidad not in (select idfuncionalidad from ORION.roles_funcionalidades where idrol = @idrol and habilitado = 1)";
            
            sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.AddWithValue("@idrol", idrol);

            dr1 = sqlc.ExecuteReader();
            while (dr1.Read()){
                objRol.FuncInhabilitadas.Add(new ClsRol.Funcionalidad(
                    Convert.ToInt32(dr1["idfuncionalidad"]), dr1["descripcion"].ToString()));
            }

            dr1.Close();
            sqlc.Dispose();

            //Traigo el nombre
            sqlstr = "select descripcion from ORION.roles where idrol = @idrol;";
            
            sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.AddWithValue("@idrol", idrol);

            dr1 = sqlc.ExecuteReader();
            while (dr1.Read()){
                    objRol.NombreRol = dr1["descripcion"].ToString();
            }

            dr1.Close();
            sqlc.Dispose();

            Dbaccess.DBDisconnect();
            return objRol;
        }
    
    }
}
