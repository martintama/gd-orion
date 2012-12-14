using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class TipoTarjeta
    {
        public TipoTarjeta()
        {

        }

        public TipoTarjeta(Int16 _idtipo_tarjeta, String _descripcion)
        {
            this.Idtipo_tarjeta = _idtipo_tarjeta;
            this.Descripcion = _descripcion;
        }
        public Int16 Idtipo_tarjeta { get; set; }

        public String Descripcion { get; set; }

        public static List<TipoTarjeta> GetTiposTarjeta()
        {
            List<TipoTarjeta> listaTipos = new List<TipoTarjeta>();

            Dbaccess.DBConnect();

            String sqlstr = "select idtipo_tarjeta, descripcion from ORION.tipos_tarjeta order by idtipo_tarjeta";
            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                TipoTarjeta item = new TipoTarjeta();
                item.Idtipo_tarjeta = Convert.ToInt16(dr1["idtipo_tarjeta"]);
                item.Descripcion = dr1["descripcion"].ToString();

                listaTipos.Add(item);
            }

            Dbaccess.DBDisconnect();

            return listaTipos;
        }
    }
}
