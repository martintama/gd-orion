using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    class Devolucion
    {
        public Int32 Iddevolucion { get; set; }

        public Int32 Idcliente { get; set; }

        public DateTime FechaDevolucion { get; set; }

        public Int32 Idcompra { get; set; }

        public String Motivo { get; set; }
    }
}
