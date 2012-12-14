using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    public class Rubro
    {
        public Int16 Idrubro { get; set; }

        public String Descripcion { get; set; }

        public static List<Rubro> getRubros()
        {
            List<Rubro> listaRubros = new List<Rubro>();

            Dbaccess.DBConnect();

            String sqlstr = "Select idrubro, descripcion from orion.rubros order by descripcion";
            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                Rubro item = new Rubro();
                item.Idrubro = Convert.ToInt16(dr1["idrubro"]);
                item.Descripcion = dr1["descripcion"].ToString();

                listaRubros.Add(item);
            }

            Dbaccess.DBDisconnect();

            return listaRubros;
        }
    }
}
