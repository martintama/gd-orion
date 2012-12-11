using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    class Cupon
    {
        public Int32 Idcupon { get; set; }

        public Int32 Idproveedor { get; set; }

        public String Descripcion { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public DateTime FechaVencimientoCanje { get; set; }

        public Decimal PrecioReal { get; set; }

        public Decimal PrecioFicticio { get; set; }

        public Int16 CantidadDisponible { get; set; }

        public Int16 CantidadMaxUsuario { get; set; }

        public Boolean Publicado { get; set; }

        public DateTime FechaPublicacionReal { get; set; }

        public Boolean Activo { get; set; }

        public List<Ciudad> ListaCiudades { get; set; }

    }
}
