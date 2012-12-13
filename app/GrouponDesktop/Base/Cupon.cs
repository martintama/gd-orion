using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class Cupon
    {
        public Cupon()
        {
            this.ListaCiudades = new List<Ciudad>();
            this.ProveedorAsoaciado = new Proveedor();
        }

        public Int32 Idcupon { get; set; }

        public Proveedor ProveedorAsoaciado { get; set; }

        public String Descripcion { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public DateTime FechaVencimientoCanje { get; set; }

        public Decimal PrecioReal { get; set; }

        public Decimal PrecioFicticio { get; set; }

        public Int16 CantidadDisponible { get; set; }

        public Int16 CantidadMaxUsuario { get; set; }

        public Boolean Publicado { get; set; }

        public DateTime FechaPublicacionReal { get; set; }

        public Int16 CantidadRestoDisponible { get; set; }

        public List<Ciudad> ListaCiudades { get; set; }

        internal void Grabar()
        {
            Dbaccess.DBConnect();

            String sqlstr = "Insert into orion.cupones(idproveedor, descripcion, fecha_alta, fecha_publicacion, fecha_vencimiento, fecha_vencimiento_canje, ";
            sqlstr += "precio_real, precio_ficticio, cantidad_disponible, cantidad_max_usuario) values(@idproveedor, @descripcion, @fecha_alta, @fecha_publicacion, ";
            sqlstr += "@fecha_vencimiento, @fecha_vencimiento_canje, @precio_real, @precio_ficticio, @cantidad_disponible, @cantidad_max_usuario)";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.AddWithValue("@idproveedor", this.ProveedorAsoaciado.Idproveedor);
            sqlc.Parameters.AddWithValue("@descripcion", this.Descripcion);
            sqlc.Parameters.AddWithValue("@fecha_alta", this.FechaAlta);
            sqlc.Parameters.AddWithValue("@fecha_publicacion", this.FechaPublicacion);
            sqlc.Parameters.AddWithValue("@fecha_vencimiento", this.FechaVencimiento);
            sqlc.Parameters.AddWithValue("@fecha_vencimiento_canje", this.FechaVencimientoCanje);
            sqlc.Parameters.AddWithValue("@precio_real", this.PrecioReal);
            sqlc.Parameters.AddWithValue("@precio_ficticio", this.PrecioFicticio);
            sqlc.Parameters.AddWithValue("@cantidad_disponible", this.CantidadDisponible);
            sqlc.Parameters.AddWithValue("@cantidad_max_usuario", this.CantidadMaxUsuario);

            sqlc.ExecuteNonQuery();

            Dbaccess.DBDisconnect();
        }

        public static List<Cupon> BuscarCupones()
        {
            return BuscarCupones(0, true);
        }

        public static List<Cupon> BuscarCupones(Int32 idproveedor, Boolean estadoPublicacion)
        {
            List<Cupon> listaCupones = new List<Cupon>();

            Dbaccess.DBConnect();

            String strwhere = "";
            String strwhere_sub = "";
            
            if (estadoPublicacion)
            {
                strwhere = "@fecha between c.fecha_publicacion and c.fecha_Vencimiento and publicado = 1 and c.cantidad_disponible > 0 ";
            }
            else
            {
                strwhere = "c.fecha_publicacion = @fecha and publicado = 0 ";
            }

            if (idproveedor > 0)
                strwhere += "and c.idproveedor = @idproveedor ";

            String sqlstr = "select c.idcupon, c.idproveedor, c.descripcion, c.fecha_vencimiento, c.fecha_vencimiento_canje, c.precio_real, c.precio_ficticio, ";
                sqlstr += "c.cantidad_disponible, c.cantidad_max_usuario, p.razon_social from orion.cupones c inner join orion.proveedores p on p.idproveedor = c.idproveedor ";
                sqlstr += "inner join orion.usuarios u on u.idusuario = p.idusuario where " + strwhere + " order by p.razon_social";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.AddWithValue("@fecha", Sesion.currentDate);

            if (idproveedor > 0)
                sqlc.Parameters.AddWithValue("@idproveedor", idproveedor);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                Cupon unCupon = new Cupon();
                unCupon.ProveedorAsoaciado.Idproveedor = Convert.ToInt32(dr1["idproveedor"].ToString());
                unCupon.ProveedorAsoaciado.RazonSocial = dr1["razon_social"].ToString();
                unCupon.Idcupon = Convert.ToInt32(dr1["idcupon"]);
                unCupon.Descripcion = dr1["descripcion"].ToString();
                unCupon.FechaVencimiento = Convert.ToDateTime(dr1["fecha_vencimiento"]);
                unCupon.FechaVencimientoCanje = Convert.ToDateTime(dr1["fecha_vencimiento_canje"]);
                unCupon.PrecioReal = Convert.ToDecimal(dr1["precio_real"]);
                unCupon.PrecioFicticio = Convert.ToDecimal(dr1["precio_ficticio"]);
                unCupon.CantidadDisponible = Convert.ToInt16(dr1["cantidad_disponible"]);
                unCupon.CantidadMaxUsuario = Convert.ToInt16(dr1["cantidad_max_usuario"]);

                listaCupones.Add(unCupon);
            }

            Dbaccess.DBDisconnect();

            return listaCupones;
        }

        internal void CalcularRestoCompra(Int32 idcliente)
        {
            Dbaccess.DBConnect();

            String sqlstr = "";


            sqlstr = "select isnull(SUM(cantidad),0) from ORION.compras where idcliente = @idcliente and idcupon = @idcupon and idcompra_estado in (1,2)";
            
            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.AddWithValue("@idcliente", idcliente);
            sqlc.Parameters.AddWithValue("@idcupon", this.Idcupon);


            this.CantidadRestoDisponible = (Int16)(this.CantidadMaxUsuario - Convert.ToInt16(sqlc.ExecuteScalar()));

            sqlc.Dispose();

            Dbaccess.DBDisconnect();

        }

        internal static void PublicarCupones(List<Cupon> listaCuponesPublicar)
        {
            Dbaccess.DBConnect();

            String sqlstr = "Update orion.cupones set publicado = 1, fecha_publicacion_real = @fecha where idcupon = @idcupon";
            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.Add("@fecha", System.Data.SqlDbType.Date);
            sqlc.Parameters.Add("@idcupon", System.Data.SqlDbType.Int);

            sqlc.Prepare();

            foreach (Cupon unCupon in listaCuponesPublicar)
            {
                sqlc.Parameters["@fecha"].Value = Sesion.currentDate.ToString("yyyy-MM-dd");
                sqlc.Parameters["@idcupon"].Value = unCupon.Idcupon;
                sqlc.ExecuteNonQuery();
            }

            Dbaccess.DBDisconnect();
        }

    }
}
