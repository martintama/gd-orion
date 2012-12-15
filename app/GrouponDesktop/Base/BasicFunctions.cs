using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GrouponDesktop.Base
{
    static class BasicFunctions
    {
        public static Boolean EsNumero(String cadena)
        {
            Boolean valido = true;

            Int32 indice = 0;

            while (indice < cadena.Length && valido)
            {
                if (!Char.IsNumber(cadena[indice]))
                {
                    valido = false;
                }
                indice++;
            }

            return valido;
        }


        public static bool EsMail(string email)
        {
            //Expresión regular para detectar un mail valido.
            string pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.
    (com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";
            
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            
            bool valido = false;

            if (email == "")
            {
                valido = false;
            }
            else
            {
                //Verifico si matchea con la direccion
                valido = check.IsMatch(email);
            }
            
            return valido;
        } 
    }
}
