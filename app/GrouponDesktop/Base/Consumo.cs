using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class Consumo
    {
        public Int32 Idconsumo { get; set; }

        public Int32 Idcliente { get; set; }

        public DateTime FechaConsumo { get; set; }

        public Int32 Idcompra { get; set; }

        public Boolean Facturado { get; set; }

        internal void Consumir()
        {
            Dbaccess.DBConnect();

            SqlCommand sqlc = new SqlCommand("Orion.Compras_Consumir", Dbaccess.globalConn);
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.Parameters.AddWithValue("@fecha", this.FechaConsumo);
            sqlc.Parameters.AddWithValue("@idcompra", this.Idcompra);
            
            sqlc.ExecuteNonQuery();

            Dbaccess.DBDisconnect();
        }
    }
}
