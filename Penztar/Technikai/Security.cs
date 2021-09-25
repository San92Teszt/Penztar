using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Penztar
{
    class Security
    {
        public static string SHA1Convert(string kod)
        {
            SHA1Managed sha1 = new SHA1Managed();
            string buffer= BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(kod)));
            string feltolt = "";
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i]!='-')
                {
                    feltolt += buffer[i];
                }
            }
            return feltolt;
        }
    }
}
