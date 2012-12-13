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
    
        public Compra()
        {
            this.Estado = new CompraEstado();
            this.CuponAsociado = new Cupon();
            this.ConsumoAsociado = new Consumo();
            this.DevolucionAsociada = new Devolucion();
            this.ClienteAsociado = new Cliente();
        }
        public Int32 Idcompra { get; set; }

        public Cliente ClienteAsociado { get; set; }

        public DateTime FechaCompra { get; set; }

        public Int16 Cantidad { get; set; }

        public String CodigoCompra { get; set; }

        public CompraEstado Estado { get; set; }

        public Cupon CuponAsociado { get; set; }

        public Consumo ConsumoAsociado { get; set; }

        public Devolucion DevolucionAsociada { get; set; }
        
        public void GrabarCompra()
        {
            Dbaccess.DBConnect();

            String sqlstr = "Orion.Cupones_Comprar";
            
            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;

            sqlc.Parameters.AddWithValue("@fecha", Sesion.currentDate);
            sqlc.Parameters.AddWithValue("@idcliente", this.ClienteAsociado.Idcliente);
            sqlc.Parameters.AddWithValue("@cantidad", this.Cantidad);
            sqlc.Parameters.AddWithValue("@idcupon", this.CuponAsociado.Idcupon);

            SqlParameter codigoParameter;
            codigoParameter = sqlc.Parameters.Add("@codigo", SqlDbType.VarChar, 12);
            codigoParameter.Direction = ParameterDirection.Output;
            sqlc.ExecuteNonQuery();

            this.CodigoCompra = codigoParameter.Value.ToString();

            Dbaccess.DBDisconnect();
        }

        internal static Compra BuscarCompra(string codigo, Cliente unCliente)
        {
            Compra unaCompra = new Compra();

            Dbaccess.DBConnect();

            String sqlstr = "select co.idcompra, co.fecha_compra, co.codigo, cu.descripcion, cu.fecha_vencimiento_canje, co.cantidad, ";
            sqlstr += "con.fecha_consumo, de.fecha_devolucion, ce.idcompra_estado, ce.descripcion estado from ORION.compras co ";
            sqlstr += "inner join ORION.cupones cu on cu.idcupon = co.idcupon left join ORION.consumos con on con.idcompra = co.idcompra ";
            sqlstr += "left join ORION.devoluciones de on de.idcompra = co.idcompra inner join ORION.compras_estados ce on ce.idcompra_estado = co.idcompra_estado ";
            sqlstr += "where co.codigo = @codigo and co.idcliente = @idcliente";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.AddWithValue("@codigo", codigo);
            sqlc.Parameters.AddWithValue("@idcliente", unCliente.Idcliente);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            if (dr1.Read())
            {
                unaCompra.Idcompra = Convert.ToInt32(dr1["idcompra"]);
                unaCompra.FechaCompra = Convert.ToDateTime(dr1["fecha_compra"]);
                unaCompra.CodigoCompra = dr1["codigo"].ToString();
                unaCompra.CuponAsociado.FechaVencimientoCanje = Convert.ToDateTime(dr1["fecha_vencimiento_canje"]);
                unaCompra.CuponAsociado.Descripcion = dr1["descripcion"].ToString();
                unaCompra.Cantidad = Convert.ToInt16(dr1["cantidad"]);

                if (dr1["fecha_consumo"].ToString() != "")
                {
                    unaCompra.ConsumoAsociado.FechaConsumo = Convert.ToDateTime(dr1["fecha_consumo"]);
                }
                if (dr1["fecha_devolucion"].ToString() != "")
                {
                    unaCompra.DevolucionAsociada.FechaDevolucion = Convert.ToDateTime(dr1["fecha_devolucion"]);
                }
                unaCompra.Estado = new CompraEstado(Convert.ToInt16(dr1["idcompra_estado"]), dr1["estado"].ToString());

            }

            dr1.Close();
            dr1.Dispose();

            sqlc.Dispose();

            Dbaccess.DBDisconnect();

            return unaCompra;
        }

        internal static List<Compra> BuscarCompras(DateTime fechaDesde, DateTime fechaHasta, Int32 idcliente)
        {
            List<Compra> listaCompras = new List<Compra>();

            Dbaccess.DBConnect();

            String sqlstr = "select co.fecha_compra, co.codigo, cu.descripcion, cu.fecha_vencimiento_canje, ";
            sqlstr += "con.fecha_consumo, de.fecha_devolucion, ce.idcompra_estado, ce.descripcion estado from ORION.compras co ";
            sqlstr += "inner join ORION.cupones cu on cu.idcupon = co.idcupon left join ORION.consumos con on con.idcompra = co.idcompra ";
            sqlstr += "left join ORION.devoluciones de on de.idcompra = co.idcompra inner join ORION.compras_estados ce on ce.idcompra_estado = co.idcompra_estado ";
            sqlstr += "where co.idcliente = @idcliente and fecha_compra between @fechadesde and @fechahasta";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.AddWithValue("@fechadesde", fechaDesde);
            sqlc.Parameters.AddWithValue("@fechahasta", fechaHasta);
            sqlc.Parameters.AddWithValue("@idcliente", idcliente);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                Compra unaCompra = new Compra();

                unaCompra.FechaCompra = Convert.ToDateTime(dr1["fecha_compra"]);
                unaCompra.CodigoCompra = dr1["codigo"].ToString();
                unaCompra.CuponAsociado.FechaVencimientoCanje = Convert.ToDateTime(dr1["fecha_vencimiento_canje"]);
                unaCompra.CuponAsociado.Descripcion = dr1["descripcion"].ToString();

                if (dr1["fecha_consumo"].ToString() != "")
                {
                    unaCompra.ConsumoAsociado.FechaConsumo = Convert.ToDateTime(dr1["fecha_consumo"]);
                }
                if (dr1["fecha_devolucion"].ToString() != "")
                {
                    unaCompra.DevolucionAsociada.FechaDevolucion = Convert.ToDateTime(dr1["fecha_devolucion"]);
                }
                unaCompra.Estado = new CompraEstado(Convert.ToInt16(dr1["idcompra_estado"]), dr1["estado"].ToString());

                listaCompras.Add(unaCompra);

            }

            dr1.Close();
            dr1.Dispose();

            sqlc.Dispose();

            Dbaccess.DBDisconnect();
            return listaCompras;
        }

        internal static Compra BuscarCompra(string codigo)
        {
            Compra unaCompra = new Compra();

            Dbaccess.DBConnect();

            String sqlstr = "select co.idcompra, cu.idproveedor, co.fecha_compra, co.codigo, cu.descripcion, cu.fecha_vencimiento_canje, co.cantidad, cu.precio_real, ";
            sqlstr += "co.fecha_compra, con.fecha_consumo, de.fecha_devolucion, ce.idcompra_estado, ce.descripcion estado, cl.nombre, cl.apellido, cl.dni from ORION.compras co ";
            sqlstr += "inner join ORION.cupones cu on cu.idcupon = co.idcupon left join ORION.consumos con on con.idcompra = co.idcompra ";
            sqlstr += "left join ORION.devoluciones de on de.idcompra = co.idcompra inner join ORION.compras_estados ce on ce.idcompra_estado = co.idcompra_estado ";
            sqlstr += "inner join ORION.clientes cl on cl.idcliente = co.idcliente where co.codigo = @codigo";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.AddWithValue("@codigo", codigo);
            
            SqlDataReader dr1 = sqlc.ExecuteReader();

            if (dr1.Read())
            {
                unaCompra.Idcompra = Convert.ToInt32(dr1["idcompra"]);
                unaCompra.FechaCompra = Convert.ToDateTime(dr1["fecha_compra"]);
                unaCompra.CodigoCompra = dr1["codigo"].ToString();
                unaCompra.Cantidad = Convert.ToInt16(dr1["cantidad"]);
                unaCompra.CuponAsociado.FechaVencimientoCanje = Convert.ToDateTime(dr1["fecha_vencimiento_canje"]);
                unaCompra.CuponAsociado.Descripcion = dr1["descripcion"].ToString();
                unaCompra.CuponAsociado.PrecioReal = Convert.ToDecimal(dr1["precio_real"]);
                unaCompra.FechaCompra = Convert.ToDateTime(dr1["fecha_compra"]);
                unaCompra.CuponAsociado.ProveedorAsoaciado.Idproveedor = Convert.ToInt32(dr1["idproveedor"]);
                unaCompra.ClienteAsociado.Nombre = dr1["nombre"].ToString();
                unaCompra.ClienteAsociado.Apellido = dr1["apellido"].ToString();
                unaCompra.ClienteAsociado.DNI = Convert.ToInt32(dr1["dni"]);
                

                if (dr1["fecha_consumo"].ToString() != "")
                {
                    unaCompra.ConsumoAsociado.FechaConsumo = Convert.ToDateTime(dr1["fecha_consumo"]);
                }
                if (dr1["fecha_devolucion"].ToString() != "")
                {
                    unaCompra.DevolucionAsociada.FechaDevolucion = Convert.ToDateTime(dr1["fecha_devolucion"]);
                }
                unaCompra.Estado = new CompraEstado(Convert.ToInt16(dr1["idcompra_estado"]), dr1["estado"].ToString());

            }

            dr1.Close();
            dr1.Dispose();

            sqlc.Dispose();

            Dbaccess.DBDisconnect();

            return unaCompra;
        }
    }
}

