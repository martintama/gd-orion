using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class Factura
    {
        public Factura()
        {
            this.Items = new List<Consumo>();
        }
        public Int32 Idfactura { get; set; }

        public Int32 NroFactura { get; set; }

        public DateTime FechaFactura { get; set; }

        public decimal Monto { get; set; }

        public List<Consumo> Items { get; set; }

    }
}
