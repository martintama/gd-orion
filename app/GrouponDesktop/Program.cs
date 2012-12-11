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
            Sesion.Idtipo_usuario = 1;
            Sesion.ValidarUsuario("15403632", "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92");
            
            Application.Run(new frmMain());
            

        }
    }
}
