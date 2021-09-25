using System;
using System.Collections.Generic;
using System.Text;

namespace Penztar
{
    static class Penztar
    {
        static int penztarSorszam;
        static string cim;
        static string rovidnev;
        static string cegnev;
        static string cegjegyzek;
        static string adoszam;
        static string bankNeve;

        public static int PenztarSorszam
        {
            get
            {
                return penztarSorszam;
            }

            set
            {
                penztarSorszam = value;
            }
        }

        public static string Cim
        {
            get
            {
                return cim;
            }

            set
            {
                cim = value;
            }
        }

        public static string Rovidnev
        {
            get
            {
                return rovidnev;
            }

            set
            {
                rovidnev = value;
            }
        }

        public static string Cegnev
        {
            get
            {
                return cegnev;
            }

            set
            {
                cegnev = value;
            }
        }

        public static string Cegjegyzek
        {
            get
            {
                return cegjegyzek;
            }

            set
            {
                cegjegyzek = value;
            }
        }

        public static string Adoszam
        {
            get
            {
                return adoszam;
            }

            set
            {
                adoszam = value;
            }
        }

        public static string BankNeve
        {
            get
            {
                return bankNeve;
            }

            set
            {
                bankNeve = value;
            }
        }
    }
}
