using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //PRODUCCION    
            Application.Run(new frmLogin());
            
            //DESARROLLO
            clsMain.objInfoSesion = new InfoSesion();
            clsMain.objInfoSesion.Idusuario = 1;
            clsMain.objInfoSesion.Idrol = 1;
            clsMain.objInfoSesion.Idusuario_tipo = 1;
            Dbaccess.DBConnect();
            clsMain.objInfoSesion.Funcionalidades = clsLogin.obtenerFuncionalidades(1);
            Dbaccess.DBDisconnect();

            Application.Run(new frmMain());

        }
    }
}
