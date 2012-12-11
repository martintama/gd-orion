using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    class Factura
    {  
        public Int32 Idfactura { get; set; }

        public Int32 NroFactura { get; set; }

        public DateTime FechaFactura { get; set; }

        public List<Consumo> Items { get; set; }
    }
}
