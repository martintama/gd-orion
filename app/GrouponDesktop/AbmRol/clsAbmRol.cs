using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

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
    }
}
