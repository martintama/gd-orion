using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GrouponDesktop.Logic;

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
            clsIO.loadConfig();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //PRODUCCION    

            //Application.Run(new frmLogin());
            
            //DESARROLLO
            
            clsMain.objInfoSesion = new InfoSesion();
            clsMain.objInfoSesion.Idusuario = 1;
            clsMain.objInfoSesion.Idrol = 4;
            clsMain.objInfoSesion.idtipo_usuario = 1;
            Dbaccess.DBConnect();
            clsMain.objInfoSesion.Funcionalidades = clsLogin.obtenerFuncionalidades(clsMain.objInfoSesion.Idrol);
            Dbaccess.DBDisconnect();

            Application.Run(new frmMain());
            

        }
    }
}
