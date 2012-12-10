using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    static class clsMain
    {
        public static InfoSesion objInfoSesion;

        public static DateTime currentDate;

        public enum Funcionalidades
        {
            ABM_Cliente = 1,
            ABM_Proveedor,
            ABM_Rol,
            Armar_Cupon,
            Cargar_Credito,
            Comprar_Cupon,
            Comprar_GiftCard,
            Facturacion_Proveedores,
            Historial_Compra,
            Listado_Estadístico,
            Pedir_Devolucion,
            Publicar_Cupon, 
            Registro_Consumo_cupon,
            Registro_Usuario 
        }

    }
}
