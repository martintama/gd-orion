using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        internal void GrabarDatos()
        {
            // Usar un SP porque hay que restar el stock y el credito al cliente.. un bardo.
            throw new NotImplementedException();
        }

        internal static Compra BuscarCompra(string p, Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
