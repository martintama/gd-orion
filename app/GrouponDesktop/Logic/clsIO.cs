﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.IO;

namespace GrouponDesktop.Logic
{
    public static class clsIO
    {
        public static void loadConfig()
        {

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\GrouponConfig.xml");
            XmlNode xnodes = xdoc.SelectSingleNode("/Config/FechaSistema");

            clsMain.currentDate = DateTime.ParseExact(xnodes.InnerText, "dd/MM/yyyy",null);           

        }
    }
}

