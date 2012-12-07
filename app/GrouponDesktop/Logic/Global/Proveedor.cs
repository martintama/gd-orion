using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Logic.Global
{
    class Proveedor
    {
        public String RazonSocial { get; set; }

        public String Mail { get; set; }

        public String Telefono { get; set; }

        public String Direccion { get; set; }

        public String Localidad { get; set; }

        public String CodPostal { get; set; }

        public Ciudad Ciudad { get; set; }

        public String Cuit { get; set; }

        public Rubro Rubro { get; set; }

        public String Contacto { get; set; }

        public Usuario UsuarioAsociado { get; set; }
    }
}
