using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    class Compra
    {
        public enum EstadoCompra{
            Comprado = 1,
            Consumido,
            Devuelto,
            Vencido
        }

        public Int32 Idcompra { get; set; }

        public Int32 Idcliente { get; set; }

        public DateTime FechaCompra { get; set; }

        public Int16 Cantidad { get; set; }

        public Int32 Idcupon { get; set; }

        public String CodigoCompra { get; set; }

        public EstadoCompra Estado { get; set; }

    }
}
