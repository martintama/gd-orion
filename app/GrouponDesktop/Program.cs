using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GrouponDesktop.Base;
using GrouponDesktop.UI;
using System.Reflection;
using System.IO;

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
            String rutaConfig = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\GrouponConfig.xml";
            Sesion.ConfigApp = ConfigReader.LoadConfig(rutaConfig);
                        
            Application.EnableVisualStyles();

            //Application.SetCompatibleTextRenderingDefault(false);
            //PRODUCCION    
            //Application.Run(new frmLogin());
            
            //DESARROLLO
            //Administrativo
            Sesion.Idtipo_usuario = 1;
            Sesion.ValidarUsuario("admin", "E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7");

            //Cliente de prueba
            //Sesion.Idtipo_usuario = 2;
            //Sesion.ValidarUsuario("15403632", "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92");

            //Proveedor de prueba
            //Sesion.Idtipo_usuario = 3;
            //Sesion.ValidarUsuario("67275970246", "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92");

            Application.Run(new frmMain());
            

        }
    }
}
