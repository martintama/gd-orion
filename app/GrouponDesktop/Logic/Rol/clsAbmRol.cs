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
        public List<ClsRol> GetRoles(){
            return this.GetRoles("");
        }

        public List<ClsRol> GetRoles(String filtro)
        {
            List<ClsRol> listaRoles = new List<ClsRol>();

            Dbaccess.DBConnect();

            SqlCommand sqlc = new SqlCommand("orion.Roles_Obtener", Dbaccess.globalConn);
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;

            sqlc.Parameters.AddWithValue("@filtro", filtro);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                ClsRol unRol = new ClsRol();
                unRol.Idrol = Convert.ToInt32(dr1["idrol"]);
                unRol.NombreRol = dr1["descripcion"].ToString();
                unRol.Estado = Convert.ToBoolean(dr1["Estado"]);

                listaRoles.Add(unRol);
            }

            dr1.Close();
            dr1.Dispose();

            Dbaccess.DBConnect();

            return listaRoles;
        }

        
        

        
    }
}
