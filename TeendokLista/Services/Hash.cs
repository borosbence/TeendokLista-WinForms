using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TeendokLista.Services
{
    public static class Hash
    {
        public static string Encrypt(string text)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            byte[] hash = SHA512.Create().ComputeHash(textBytes);

            string hashedPwd = string.Empty;
            for (int i = 0; i < hash.Length; i++)
            {
                hashedPwd += hash[i].ToString("X2");
            }

            return hashedPwd;
        }
    }
}