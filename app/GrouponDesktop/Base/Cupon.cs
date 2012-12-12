﻿using System;
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
        }

        public Int32 Idcupon { get; set; }

        public Int32 Idproveedor { get; set; }

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

        public Boolean Activo { get; set; }

        public List<Ciudad> ListaCiudades { get; set; }


        internal void Grabar()
        {
            Dbaccess.DBConnect();

            String sqlstr = "Insert into orion.cupones(idproveedor, descripcion, fecha_alta, fecha_publicacion, fecha_vencimiento, fecha_vencimiento_canje, ";
            sqlstr += "precio_real, precio_ficticio, cantidad_disponible, cantidad_max_usuario) values(@idproveedor, @descripcion, @fecha_alta, @fecha_publicacion, ";
            sqlstr += "@fecha_vencimiento, @fecha_vencimiento_canje, @precio_real, @precio_ficticio, @cantidad_disponible, @cantidad_max_usuario)";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.AddWithValue("@idproveedor", this.Idproveedor);
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
            List<Cupon> listaCupones = new List<Cupon>();

            Dbaccess.DBConnect();

            String sqlstr = "select c.idproveedor, c.descripcion, c.fecha_vencimiento, c.fecha_vencimiento_canje, c.precio_real, c.precio_ficticio, ";
            sqlstr += "c.cantidad_disponible, c.cantidad_max_usuario from orion.cupones c inner join orion.proveedores p on p.idproveedor = c.idproveedor ";
            sqlstr += "inner join orion.usuarios u on u.idusuario = p.idusuario where publicado = 1 and @fecha between c.fecha_publicacion and c.fecha_Vencimiento ";

            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            sqlc.Parameters.AddWithValue("@fecha", Sesion.currentDate);

            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                Cupon unCupon = new Cupon();
                unCupon.Idproveedor = Convert.ToInt32(dr1["idproveedor"].ToString());
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
    }
}
