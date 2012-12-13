using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrouponDesktop.Base
{
    class Estadistica
    {
        public enum TipoEstadistica
        {
            Devoluciones,
            GiftCards
        }

        public class EstadisticaDevoluciones
        {
            public String RazonSocial { get; set; }

            public String Cuit { get; set; }

            public Int32 TotalVendidos { get; set; }

            public Int32 TotalDevueltos { get; set; }

            public Decimal MontoDevuelto { get; set; }

            public Int32 Porcentaje { get; set; }
        }

        public class EstadisticaGiftCards
        {
            public String NombreApellido { get; set; }

            public Int32 Dni { get; set; }

            public Int32 GiftcardsRecibidos { get; set; }

            public Decimal MontoTotalRecibido { get; set; }
        }

        public Estadistica()
        {
            this.Tipo = new TipoEstadistica();

        }

        public TipoEstadistica Tipo { get; set; }

        public Int16 Anio { get; set; }

        public Int16 Semestre { get; set; }

        //Ocultos. De afuera solo llamo a GetEstadistica y ella se encarga de ver cual devolver
        private List<EstadisticaGiftCards> EstadisticasGiftCards { get; set; }
        private List<EstadisticaDevoluciones> EstadisticasDevoluciones { get; set; }

        private List<EstadisticaDevoluciones> GetEstadisticaDevoluciones(Int16 anio, Int16 mes)
        {
            List<EstadisticaDevoluciones> listaDevoluciones = new List<EstadisticaDevoluciones>();

            return listaDevoluciones;
        }

        private List<EstadisticaGiftCards> GetEstadisticaGiftCards(Int16 anio, Int16 mes)
        {
            List<EstadisticaGiftCards> listaGiftCards = new List<EstadisticaGiftCards>();

            return listaGiftCards;
        }

        public Object GetEstadisticas()
        {
            if (this.Tipo == TipoEstadistica.Devoluciones)
            {
                return this.GetEstadisticaDevoluciones(this.Anio, this.Semestre);
            }
            else
            {
                return this.GetEstadisticaDevoluciones(this.Anio, this.Semestre);
            }
        }
    }
}
