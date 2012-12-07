using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using GrouponDesktop.Logic.Global;

namespace GrouponDesktop.Logic
{
    class clsAbmRol
    {
        public List<Rol> GetRoles(){
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

        
        

        
    }
}
