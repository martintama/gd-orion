using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    public class Ciudad
    {
        // CONSTRUCTORES
        public Ciudad()
        {
        }

        public Ciudad(Int32 idciudad, String descripcion)
        {
            this.Idciudad = idciudad;
            this.Descripcion = descripcion;
        }

        //PROPIEDADES
        public Int32 Idciudad { get; set; }

        public String Descripcion { get; set; }

        // METODOS
        public static List<Ciudad> getListaCiudades()
        {
            return getListaCiudades(new List<Ciudad>());
        }

        public static List<Ciudad> getListaCiudades(List<Ciudad> listaExclusion)
        {
            List<Ciudad> listaCiudades = new List<Ciudad>();

            Dbaccess.DBConnect();

            //Traigo todas las ciudades y las pongo como deshabilitadas en el caso de que sea un nuevo usuario
            String sqlstr = "select idciudad, descripcion from ORION.ciudades order by descripcion ";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                Ciudad city = new Ciudad(
                    Convert.ToInt32(dr1["idciudad"]), dr1["descripcion"].ToString().Trim());

                bool encontrado = false;
                foreach (Ciudad item in listaExclusion)
                {
                    if (item.Idciudad == city.Idciudad)
                    {
                        encontrado = true;
                    }
                }

                if (!encontrado)
                {
                    listaCiudades.Add(city);
                }
            }

            dr1.Close();
            sqlc.Dispose();

            Dbaccess.DBDisconnect();

            return listaCiudades;
        }
    }
}
