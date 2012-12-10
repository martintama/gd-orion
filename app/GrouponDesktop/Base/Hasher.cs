using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace GrouponDesktop.Base
{
    //Recibe un string y devuelve el mismo en SHA256
    public static class Hasher
    {
        public static String ConvertirSHA256(String input)
        {
            SHA256Managed sha256hasher = new SHA256Managed();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = sha256hasher.ComputeHash(inputBytes);


            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();  
        }
    }
}
