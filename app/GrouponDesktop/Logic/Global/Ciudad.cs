using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Logic.Global
{
    public class Ciudad
    {
        public Ciudad(Int32 idciudad, String descripcion)
        {
            this.Idciudad = idciudad;
            this.Descripcion = descripcion;
        }

        public Int32 Idciudad { get; set; }

        public String Descripcion { get; set; }
    }
}
