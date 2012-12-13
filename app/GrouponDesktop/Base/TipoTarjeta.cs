using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    class TipoTarjeta
    {
        public TipoTarjeta()
        {

        }

        public TipoTarjeta(Int16 _idtipo_tarjeta, String _descripcion)
        {
            this.Idtipo_tarjeta = _idtipo_tarjeta;
            this.Descripcion = _descripcion;
        }
        public Int16 Idtipo_tarjeta { get; set; }

        public String Descripcion { get; set; }
    }
}
