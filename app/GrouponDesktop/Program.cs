using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GrouponDesktop.Base;
using GrouponDesktop.UI;

namespace GrouponDesktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IoBLL.loadConfig();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //PRODUCCION    

            //Application.Run(new frmLogin());
            
            //DESARROLLO
            clsMain.objInfoSesion.Idtipo_usuario = 1;
            clsMain.objInfoSesion.EntidadLogueada = (Administrativo)Usuario.GetEntidadAsociada(1);
            
            Application.Run(new frmMain());
            

        }
    }
}
