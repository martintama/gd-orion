using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    class TipoPago
    {
        public TipoPago(){

        }

        public TipoPago(Int32 _idtipo_pago, String _descripcion){
            this.Idtipo_Pago = _idtipo_pago;
            this.Descripcion = _descripcion;
        }

        public Int32 Idtipo_Pago { get; set; }

        public String Descripcion { get; set; }

    }
}
