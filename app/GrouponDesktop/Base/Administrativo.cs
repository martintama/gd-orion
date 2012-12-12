using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    class Administrativo
    {
        public Administrativo()
        {
            this.UsuarioAsociado = new Usuario();
        }
        public Usuario UsuarioAsociado { get; set; }

    }
}
