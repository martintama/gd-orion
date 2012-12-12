using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class GiftCard
    {
        public DateTime Fecha { get; set; }

        public Decimal Monto { get; set; }

        public Cliente ClienteOrigen { get; set; }

        public Cliente ClienteDestino { get; set; }


        internal void CompraGiftCard()
        {

            Dbaccess.DBConnect();

            SqlCommand cmd = new SqlCommand("Orion.GiftCard_Comprar", Dbaccess.globalConn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idcliente_origen", this.ClienteOrigen.Idcliente);
            cmd.Parameters.AddWithValue("@idcliente_destino", this.ClienteDestino.Idcliente);
            cmd.Parameters.AddWithValue("@fecha", Sesion.currentDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@monto", this.Monto);

            cmd.ExecuteNonQuery();

            Dbaccess.DBDisconnect();

        }
    }
}
