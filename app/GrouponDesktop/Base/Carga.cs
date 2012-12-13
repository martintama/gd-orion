using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    class Carga
    {
        public Carga()
        {
            this.ClienteAsociado = new Cliente();
            this.TipoPagoAsociado = new TipoPago();
            this.TarjetaAsociada = new Tarjeta();
        }

        public Int32 Idcarga { get; set; }

        public DateTime FechaCarga { get; set; }

        public Cliente ClienteAsociado { get; set; }

        public TipoPago TipoPagoAsociado { get; set; }

        public Decimal Monto { get; set; }

        public Tarjeta TarjetaAsociada { get; set; }
        
    }
}
