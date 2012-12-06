using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Logic.Global
{
    class Cliente
    {
        public Cliente()
        {
            this.Ciudades = new List<Ciudad>();
        }

        public Int32 Idcliente { get; set; }

        public String Nombre { get; set; }

        public String Apellido { get; set; }

        public Int32 DNI { get; set; }

        public String Mail { get; set; }

        public String Telefono { get; set; }

        public String Direccion { get; set; }

        public String Localidad { get; set; }

        public String CodPostal { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public List<Ciudad> Ciudades { get; set; }

        public Usuario UsuarioAsociado { get; set; }

        public Boolean Habilitado { get; set; }

        internal short Grabar()
        {
            throw new NotImplementedException();
        }
    }
}
