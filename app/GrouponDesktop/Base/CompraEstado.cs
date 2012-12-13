using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    class CompraEstado
    {
        public CompraEstado()
        {
        }

        public CompraEstado(Int16 idestado, String descrip)
        {
            this.Idestado_compra = idestado;
            this.Descripcion = descrip;
        }
        public Int16 Idestado_compra { get; set; }

        public String Descripcion { get; set; }
    }
}
