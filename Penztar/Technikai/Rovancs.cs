using System;
using System.Collections.Generic;
using System.Text;

namespace Penztar
{
    static class Rovancs
    {
        static Dictionary<int, int> huf;
        static Dictionary<int, int> eur;
        static Dictionary<int, int> usd;

        public static Dictionary<int, int> Huf
        {
            get
            {
                return huf;
            }

            set
            {
                huf = value;
            }
        }

        public static Dictionary<int, int> Eur
        {
            get
            {
                return eur;
            }

            set
            {
                eur = value;
            }
        }

        public static Dictionary<int, int> Usd
        {
            get
            {
                return usd;
            }

            set
            {
                usd = value;
            }
        }
    }
}
