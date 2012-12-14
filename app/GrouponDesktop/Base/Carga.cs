using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class Carga
    {
        public Carga()
        {
            this.ClienteAsociado = new Cliente();
            this.TipoPagoAsociado = new TipoPago();
            this.TarjetaAsociada = new Tarjeta();
        }

        public Int32 Idcarga { get; set; }

        public DateTime FechaCarga { get; set; }

        public Cliente ClienteAsociado { get; set; }

        public TipoPago TipoPagoAsociado { get; set; }

        public Decimal Monto { get; set; }

        public Tarjeta TarjetaAsociada { get; set; }


        internal void Efectivizar()
        {

            Dbaccess.DBConnect();

            if (this.TipoPagoAsociado.Idtipo_Pago == 3) //Si es con tarjeta
            {
                SqlCommand sqlct = new SqlCommand("ORION.Tarjetas_ObtenerId", Dbaccess.globalConn);
                sqlct.CommandType = CommandType.StoredProcedure;

                sqlct.Parameters.AddWithValue("@idcliente", this.ClienteAsociado.Idcliente);
                sqlct.Parameters.AddWithValue("@idtipo_tarjeta", this.TarjetaAsociada.TipoTarjetaAsociada.Idtipo_tarjeta);
                sqlct.Parameters.AddWithValue("@numero_tarjeta", this.TarjetaAsociada.NumeroTarjeta);
                sqlct.Parameters.AddWithValue("@codigo_seguridad", this.TarjetaAsociada.CodigoSeguridad);
                sqlct.Parameters.AddWithValue("@nombre_titular", this.TarjetaAsociada.Titular);
                sqlct.Parameters.AddWithValue("@dni_titular", this.TarjetaAsociada.Dni);
                sqlct.Parameters.AddWithValue("@mes_vencimiento", this.TarjetaAsociada.MesVencimiento);
                sqlct.Parameters.AddWithValue("@anio_vencimiento", this.TarjetaAsociada.AnioVencimiento);

                SqlDataReader dr1 = sqlct.ExecuteReader();

                if (dr1.Read())
                {
                    this.TarjetaAsociada.Idtarjeta = Convert.ToInt32(dr1["idtarjeta"]);
                }
                dr1.Close();
                dr1.Dispose();
            }

            SqlCommand sqlc = new SqlCommand("ORION.Credito_Cargar", Dbaccess.globalConn);
            sqlc.CommandType = CommandType.StoredProcedure;

            sqlc.Parameters.AddWithValue("@fecha", Sesion.ConfigApp.FechaActual);
            sqlc.Parameters.AddWithValue("@idcliente", this.ClienteAsociado.Idcliente);
            sqlc.Parameters.AddWithValue("@idtipo_pago", this.TipoPagoAsociado.Idtipo_Pago);
            sqlc.Parameters.AddWithValue("@monto", this.Monto);
            sqlc.Parameters.AddWithValue("@idtarjeta", this.TarjetaAsociada.Idtarjeta);

            sqlc.ExecuteNonQuery();

            Dbaccess.DBDisconnect();

        }
    }
}
