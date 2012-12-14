using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class Estadistica
    {
        public enum TipoEstadistica
        {
            Devoluciones,
            GiftCards
        }

        public class EstadisticaDevoluciones
        {
            public Int16 Indice { get; set; }

            public String RazonSocial { get; set; }

            public String Cuit { get; set; }

            public Int32 TotalVendidos { get; set; }

            public Int32 TotalDevueltos { get; set; }

            public Decimal MontoDevuelto { get; set; }

            public Decimal Porcentaje { get; set; }
        }

        public class EstadisticaGiftCards
        {
            public Int16 Indice { get; set; }

            public String NombreApellido { get; set; }

            public Int32 Dni { get; set; }

            public Int32 GiftcardsRecibidos { get; set; }

            public Decimal MontoTotalRecibido { get; set; }
        }

        public Estadistica()
        {
            this.Tipo = new TipoEstadistica();

        }

        public TipoEstadistica Tipo { get; set; }

        public Int16 Anio { get; set; }

        public Int16 Semestre { get; set; }

        //Ocultos. De afuera solo llamo a GetEstadistica y ella se encarga de ver cual devolver
        private List<EstadisticaGiftCards> EstadisticasGiftCards { get; set; }
        private List<EstadisticaDevoluciones> EstadisticasDevoluciones { get; set; }

        private List<EstadisticaDevoluciones> GetEstadisticaDevoluciones(Int16 anio, Int16 semestre)
        {
            List<EstadisticaDevoluciones> listaDevoluciones = new List<EstadisticaDevoluciones>();

            Dbaccess.DBConnect();

            String sqlwhere = "";

            if (semestre == 1)
            {
                sqlwhere = " month(com.fecha_compra) between 1 and 6 ";
            }
            else
            {
                sqlwhere = " month(com.fecha_compra) between 7 and 12 ";
            }

            String sqlstr = "select top 5 p.idproveedor, p.razon_social, p.cuit, COUNT(1) vendidos, sum(case when com.idcompra_estado = 3 then 1 else 0 end) devueltos, ";
            sqlstr += "SUM(case when com.idcompra_estado is not null then cup.precio_real * com.cantidad else 0 end) monto ";
            sqlstr += "from ORION.compras com left join ORION.devoluciones d on com.idcompra = d.idcompra ";
            sqlstr += "inner join ORION.cupones cup on cup.idcupon = com.idcupon inner join ORION.proveedores p on p.idproveedor = cup.idproveedor ";
            sqlstr += "where year(com.fecha_compra) = @anio1 and " + sqlwhere + " and cup.idproveedor in (";
	        sqlstr += "select top 5 p.idproveedor from ORION.compras com inner join ORION.cupones cup on cup.idcupon = com.idcupon ";
            sqlstr += "inner join ORION.proveedores p on p.idproveedor = cup.idproveedor where year(com.fecha_compra) = @anio2 and " + sqlwhere;
            sqlstr += "group by p.idproveedor order by cast(sum(case when com.idcompra_estado = 3 then 1 else 0 end) as decimal)/CAST(count(1)  as decimal) desc)";
            sqlstr += "group by p.idproveedor, p.razon_social, p.cuit order by SUM(case when d.iddevolucion is not null then cup.precio_real * com.cantidad else 0 end) desc";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);

            sqlc.Parameters.AddWithValue("@anio1", anio);
            sqlc.Parameters.AddWithValue("@anio2", anio);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            Int16 indice = 1;
            while (dr1.Read())
            {
                EstadisticaDevoluciones unaEstadistica = new EstadisticaDevoluciones();

                unaEstadistica.Indice = indice;
                unaEstadistica.RazonSocial = dr1["razon_social"].ToString();
                unaEstadistica.Cuit = dr1["cuit"].ToString();
                unaEstadistica.TotalVendidos = Convert.ToInt32(dr1["vendidos"]);
                unaEstadistica.TotalDevueltos = Convert.ToInt32(dr1["devueltos"]);
                unaEstadistica.MontoDevuelto = Convert.ToDecimal(dr1["monto"]);
                unaEstadistica.Porcentaje = Decimal.Round((Convert.ToDecimal(unaEstadistica.TotalDevueltos) / Convert.ToDecimal(unaEstadistica.TotalVendidos) * 100),2);
                
                listaDevoluciones.Add(unaEstadistica);

                indice++;
            }

            Dbaccess.DBDisconnect();

            return listaDevoluciones;
        }

        private List<EstadisticaGiftCards> GetEstadisticaGiftCards(Int16 anio, Int16 semestre)
        {
            List<EstadisticaGiftCards> listaGiftCards = new List<EstadisticaGiftCards>();

            Dbaccess.DBConnect();

            String sqlwhere = "";

            if (semestre == 1)
            {
                sqlwhere = " month(gc.fecha) between 1 and 6 ";
            }
            else
            {
                sqlwhere = " month(gc.fecha) between 7 and 12 ";
            }


            String sqlstr = "select top 5 c.nombre, c.apellido, c.dni, COUNT(gc.idgift_card) cantidad, SUM(gc.monto) monto from ORION.gift_cards gc ";
            sqlstr += "inner join ORION.clientes c on c.idcliente = gc.idcliente_destino ";
            sqlstr += "where year(gc.fecha) = @anio and " + sqlwhere;
            sqlstr += "group by c.nombre, c.apellido, c.dni order by SUM(gc.monto) desc";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);

            sqlc.Parameters.AddWithValue("@anio", anio);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            Int16 indice = 1;
            while (dr1.Read())
            {
                EstadisticaGiftCards unaEstadistica = new EstadisticaGiftCards();

                unaEstadistica.Indice = indice;
                unaEstadistica.NombreApellido = dr1["nombre"].ToString() + " " + dr1["apellido"].ToString();
                unaEstadistica.Dni = Convert.ToInt32(dr1["dni"]);
                unaEstadistica.GiftcardsRecibidos = Convert.ToInt32(dr1["cantidad"]);
                unaEstadistica.MontoTotalRecibido = Convert.ToDecimal(dr1["monto"]);

                listaGiftCards.Add(unaEstadistica);

                indice++;
            }

            Dbaccess.DBDisconnect();
            
            return listaGiftCards;
        }

        public Object GetEstadisticas()
        {
            if (this.Tipo == TipoEstadistica.Devoluciones)
            {
                return this.GetEstadisticaDevoluciones(this.Anio, this.Semestre);
            }
            else
            {
                return this.GetEstadisticaGiftCards(this.Anio, this.Semestre);
            }
        }
    }
}
