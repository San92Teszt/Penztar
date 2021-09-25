using System;
using System.Collections.Generic;
using System.Text;

namespace Penztar
{
    static class Egyenlegek
    {
        static int forint;
        static int eur;
        static int usd;

        public static int Forint
        {
            get
            {
                return forint;
            }

            set
            {
                forint = value;
            }
        }

        public static int Eur
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

        public static int Usd
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
