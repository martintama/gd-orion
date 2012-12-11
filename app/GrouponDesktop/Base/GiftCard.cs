using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    class GiftCard
    {
        public DateTime Fecha { get; set; }

        public Decimal Monto { get; set; }

        public Cliente ClienteOrigen { get; set; }

        public Cliente ClienteDestino { get; set; }

    }
}
