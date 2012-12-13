using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    public class Configuracion
    {
        public class DataBaseConfig
        {
            public String Server { get; set; }

            public Int32 Puerto { get; set; }

            public String Base { get; set; }

            public String Usuario { get; set; }

            public String Pass { get; set; }
        }

        public Configuracion()
        {
            this.DataBase = new DataBaseConfig();
        }

        public DateTime FechaActual { get; set; }

        public DataBaseConfig DataBase { get; set; }
    }
}
