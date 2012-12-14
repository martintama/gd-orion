using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class Consumo
    {
        public Consumo()
        {
            //Sino da stack overflow
            //this.CompraAsociada = new Compra();
        }
        public Int32 Idconsumo { get; set; }

        public Int32 Idcliente { get; set; }

        public DateTime FechaConsumo { get; set; }

        public Int32 Idcompra { get; set; }

        public Boolean Facturado { get; set; }

        public Compra CompraAsociada { get; set; }

        internal static List<Consumo> BuscarConsumos(Int32 idfactura)
        {
            return BuscarConsumos(idfactura, 0, new DateTime(), new DateTime());
        }

        internal static List<Consumo> BuscarConsumos(Int32 idproveedor, DateTime fechaDesde, DateTime fechaHasta)
        {
            return BuscarConsumos(0, idproveedor, fechaHasta, fechaHasta);
        }

        private static List<Consumo> BuscarConsumos(Int32 idfactura, Int32 idproveedor, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Consumo> listaConsumos = new List<Consumo>();

            Dbaccess.DBConnect();

            SqlCommand sqlc = new SqlCommand();

            //Si vino el idfactura, hay que buscar por idfactura
            if (idfactura > 0)
            {
                String sqlstr = "select con.fecha_consumo, cup.codigo_cupon, com.codigo as codigo_compra, cup.descripcion, cup.precio_real * com.cantidad importe_compra from ORION.facturas f ";
                sqlstr += "inner join ORION.facturas_items fi on fi.idfactura = f.idfactura inner join ORION.consumos con on con.idconsumo = fi.idconsumo ";
                sqlstr += "inner join ORION.compras com on com.idcompra = con.idcompra inner join ORION.cupones cup on cup.idcupon = com.idcupon ";
                sqlstr += "where f.idfactura = @idfactura and con.facturado = 1 order by fecha_consumo, codigo_cupon";

                sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idfactura", idfactura);

            }
            else if (idproveedor > 0){
                String sqlstr = "select con.fecha_consumo, cup.codigo_cupon, com.codigo as codigo_compra, cup.descripcion, cup.precio_real * com.cantidad importe_compra from ORION.consumos con ";
                sqlstr += "inner join ORION.compras com on com.idcompra = con.idcompra inner join ORION.cupones cup on cup.idcupon = com.idcupon ";
                sqlstr += "where cup.idproveedor = @idproveedor and con.facturado = 0 and con.fecha_consumo between @fecha_desde and @fecha_hasta order by fecha_consumo, codigo_cupon";

                sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
                sqlc.Parameters.AddWithValue("@idproveedor", idproveedor);
                sqlc.Parameters.AddWithValue("@fecha_desde", fechaDesde);
                sqlc.Parameters.AddWithValue("@fecha_hasta", fechaHasta);
            }

            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                Consumo unConsumo = new Consumo();
                unConsumo.CompraAsociada = new Compra();

                unConsumo.FechaConsumo = Convert.ToDateTime(dr1["fecha_consumo"]);
                unConsumo.CompraAsociada.CuponAsociado.Codigo = dr1["codigo_cupon"].ToString();
                unConsumo.CompraAsociada.CodigoCompra = dr1["codigo_compra"].ToString();
                unConsumo.CompraAsociada.CuponAsociado.Descripcion = dr1["descripcion"].ToString();
                unConsumo.CompraAsociada.MontoCompra = Convert.ToDecimal(dr1["importe_compra"]);
                listaConsumos.Add(unConsumo);
            }

            dr1.Close();
            dr1.Dispose();

            Dbaccess.DBDisconnect();

            return listaConsumos;
        }

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
