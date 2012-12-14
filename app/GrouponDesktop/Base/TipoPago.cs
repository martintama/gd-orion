using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class TipoPago
    {
        public TipoPago(){

        }

        public TipoPago(Int32 _idtipo_pago, String _descripcion){
            this.Idtipo_Pago = _idtipo_pago;
            this.Descripcion = _descripcion;
        }

        public Int32 Idtipo_Pago { get; set; }

        public String Descripcion { get; set; }

        public static List<TipoPago> GetTiposPago()
        {
            List<TipoPago> listaTipos = new List<TipoPago>();

            Dbaccess.DBConnect();

            String sqlstr = "select idtipo_pago, descripcion from ORION.tipos_pago where visible = 1 order by idtipo_pago";
            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                TipoPago item = new TipoPago();
                item.Idtipo_Pago = Convert.ToInt16(dr1["idtipo_pago"]);
                item.Descripcion = dr1["descripcion"].ToString();

                listaTipos.Add(item);
            }

            Dbaccess.DBDisconnect();

            return listaTipos;
        }
    }
}
