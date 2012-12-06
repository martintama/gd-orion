using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Logic.Global
{
    class Usuario
    {
        public String Username { get; set; }

        public String Clave { get; set; }

        public Rol RolAsociado { get; set; }

        public TipoUsuario TipoUsuarioAsociado { get; set; }
    }
}
