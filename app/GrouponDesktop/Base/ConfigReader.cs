using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.IO;

namespace GrouponDesktop.Base
{
    public static class ConfigReader
    {
        public static Configuracion LoadConfig(String ruta)
        {

            Configuracion unaConfiguracion = new Configuracion();

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(ruta);
            XmlNode xnodes = xdoc.SelectSingleNode("/Config/FechaSistema");

            unaConfiguracion.FechaActual = DateTime.ParseExact(xnodes.InnerText, "dd/MM/yyyy",null);

            xnodes = xdoc.SelectSingleNode("/Config/Database");

            unaConfiguracion.DataBase.Server = xnodes.SelectSingleNode("Server").InnerText;
            unaConfiguracion.DataBase.Base = xnodes.SelectSingleNode("Base").InnerText;
            unaConfiguracion.DataBase.Usuario = xnodes.SelectSingleNode("Usuario").InnerText;
            unaConfiguracion.DataBase.Pass = xnodes.SelectSingleNode("Pass").InnerText;

            return unaConfiguracion;
        }
    }
}

