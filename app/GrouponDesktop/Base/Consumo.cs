using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    class Consumo
    {
        public Int32 Idconsumo { get; set; }

        public Int32 Idcliente { get; set; }

        public DateTime FechaConsumo { get; set; }

        public Int32 Idcompra { get; set; }

        public Boolean Facturado { get; set; }

    }
}
