﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop
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
                    "localhost\\SQLSERVER2008",
                    "GD2C2012",
                    "gd",
                    "gd2012");

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
