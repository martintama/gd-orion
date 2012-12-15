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

            Application.SetCompatibleTextRenderingDefault(false);
            //PRODUCCION    
            Application.Run(new frmLogin());
                      

        }
    }
}
