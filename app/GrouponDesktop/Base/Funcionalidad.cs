using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    public class Funcionalidad
    {
        // CONTRUCTOR
        public Funcionalidad(Int32 id, String descrip)
        {
            this.idfuncionalidad = id;
            this.Descripcion = descrip;
        }

        // PROPIEDADES
        public Int32 idfuncionalidad { get; set; }

        public String Descripcion { get; set; }
    }

}
