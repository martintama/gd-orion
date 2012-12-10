using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base{
    public class TipoUsuario
    {
        // CONSTURCTORES
        public TipoUsuario()
        {
            
        }
        public TipoUsuario(Int16 idtipo_usuario, String descripcion)
        {
            this.Idtipo_usuario = idtipo_usuario;
            this.Descripcion = descripcion;
        }

        // PROPIEDADES
        public Int16 Idtipo_usuario { get; set; }

        public String Descripcion { get; set; }
    }
}
