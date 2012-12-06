using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.AbmRol
{
    class ClsRol
    {
        public ClsRol()
        {
            this.FuncHabilitadas = new List<Funcionalidad>();
            this.FuncInhabilitadas = new List<Funcionalidad>();
        }
        public String NombreRol { get; set; }

        public List<Funcionalidad> FuncHabilitadas { get; set; }

        public List<Funcionalidad> FuncInhabilitadas { get; set; }

        public class Funcionalidad
        {
            public Funcionalidad(Int32 id, String descrip)
            {
                this.idfuncionalidad = id;
                this.Descripcion = descrip;
            }

            public Int32 idfuncionalidad { get; set; }

            public String Descripcion { get; set; }
        }
    }
}
