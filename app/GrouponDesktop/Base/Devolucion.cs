using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class Devolucion
    {
        public Int32 Iddevolucion { get; set; }

        public Int32 Idcliente { get; set; }

        public DateTime FechaDevolucion { get; set; }

        public Int32 Idcompra { get; set; }

        public String Motivo { get; set; }

        internal void Devolver()
        {
            Dbaccess.DBConnect();

            SqlCommand sqlc = new SqlCommand("Orion.Devoluciones_Pedir", Dbaccess.globalConn);
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.Parameters.AddWithValue("@fecha", this.FechaDevolucion);
            sqlc.Parameters.AddWithValue("@idcompra", this.Idcompra);
            sqlc.Parameters.AddWithValue("@idcliente", this.Idcliente);
            sqlc.Parameters.AddWithValue("@motivo", this.Motivo);

            sqlc.ExecuteNonQuery();

            Dbaccess.DBDisconnect();
            
        }
    }
}
