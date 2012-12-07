using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Logic.Global
{
    public class Usuario
    {
        public Usuario()
        {
            this.RolAsociado = new Rol();
            this.TipoUsuarioAsociado = new TipoUsuario();
        }

        public int Idusuario { get; set; }

        public String Username { get; set; }

        public String Clave { get; set; }

        public Rol RolAsociado { get; set; }

        public TipoUsuario TipoUsuarioAsociado { get; set; }

        public Boolean Habilitado { get; set; }
    }
}
