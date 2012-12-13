using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{

    static class Dbaccess
    {
        //Objeto conexion global
        public static SqlConnection globalConn;

        public static void DBConnect()
        {
            if (globalConn == null || globalConn.State == System.Data.ConnectionState.Closed)
            {
                string connString = string.Format(
                    "Server={0};Database={1};User Id={2};Password={3};",
                    Sesion.ConfigApp.DataBase.Server,
                    Sesion.ConfigApp.DataBase.Base,
                    Sesion.ConfigApp.DataBase.Usuario,
                    Sesion.ConfigApp.DataBase.Pass);

                globalConn = new SqlConnection(connString);
                
                globalConn.Open();
            }
        }

        public static void DBDisconnect()
        {
            if (globalConn.State == System.Data.ConnectionState.Open)
            {
                globalConn.Close();
            }

            globalConn.Dispose();
        }
    }
}
