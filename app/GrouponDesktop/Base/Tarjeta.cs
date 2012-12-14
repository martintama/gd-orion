using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    class Tarjeta
    {
        public Tarjeta()
        {
            this.TipoTarjetaAsociada = new TipoTarjeta();
            this.ClienteAsociado = new Cliente();
        }
        public Int32 Idtarjeta { get; set; }

        public TipoTarjeta TipoTarjetaAsociada { get; set; }

        public String NumeroTarjeta { get; set; }

        public Int16 CodigoSeguridad { get; set; }

        public String Titular { get; set; }

        public Int32 Dni { get; set; }

        public Int16 MesVencimiento { get; set; }

        public Int16 AnioVencimiento { get; set; }

        public Cliente ClienteAsociado { get; set; }


    }
}
