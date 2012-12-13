using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class Compra
    {
        public enum EstadoCompra{
            EnProceso = 0,
            Comprado,
            Consumido,
            Devuelto,
            Vencido
        }

        public Compra()
        {
            this.Estado = EstadoCompra.EnProceso;
            this.CuponAsociado = new Cupon();
        }
        public Int32 Idcompra { get; set; }

        public Int32 Idcliente { get; set; }

        public DateTime FechaCompra { get; set; }

        public Int16 Cantidad { get; set; }

        public String CodigoCompra { get; set; }

        public EstadoCompra Estado { get; set; }

        public Cupon CuponAsociado { get; set; }

        public void GrabarCompra()
        {
            Dbaccess.DBConnect();

            String sqlstr = "Orion.Cupones_Comprar";
            String codigo = "";



            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;

            sqlc.Parameters.AddWithValue("@fecha", Sesion.currentDate);
            sqlc.Parameters.AddWithValue("@idcliente", this.Idcliente);
            sqlc.Parameters.AddWithValue("@cantidad", this.Cantidad);
            sqlc.Parameters.AddWithValue("@idcupon", this.CuponAsociado.Idcupon);

            SqlParameter codigoParameter;
            codigoParameter = sqlc.Parameters.Add("@codigo", SqlDbType.VarChar, 12);
            codigoParameter.Direction = ParameterDirection.Output;
            sqlc.ExecuteNonQuery();

            this.CodigoCompra = codigoParameter.Value.ToString();

            Dbaccess.DBDisconnect();
        }

        internal static Compra BuscarCompra(string p, Cliente cliente)
        {
            throw new NotImplementedException();
        }

        
    }
}
