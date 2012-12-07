using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Logic.Global
{
    public class TipoUsuario
    {
        public TipoUsuario()
        {

        }
        public TipoUsuario(Int16 idusuario_tipo, String descripcion)
        {
            this.Idusuario_tipo = idusuario_tipo;
            this.Descripcion = descripcion;
        }
        public Int16 Idusuario_tipo { get; set; }

        public String Descripcion { get; set; }
    }
}
