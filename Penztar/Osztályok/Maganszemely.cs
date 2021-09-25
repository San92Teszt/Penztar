using System;
using System.Collections.Generic;
using System.Text;

namespace Penztar
{
    class Maganszemely : Ugyfel
    {
        string veznev;
        string kernev;
        string igszam;
        string lakcimszam;
        string szulhely;
        DateTime szulido;
        public Maganszemely(int ufszam, int irsz, string helyseg, string utcahaz, string veznev, string kernev, string igszam, string lakcimszam, string szulhely, DateTime szulido) : base(ufszam, irsz, helyseg, utcahaz)
        {
            Veznev = veznev;
            Kernev = kernev;
            Igszam = igszam;
            Lakcimszam = lakcimszam;
            Szulhely = szulhely;
            Szulido = szulido;
        }

        public string Veznev
        {
            get
            {
                return veznev;
            }

            set
            {
                veznev = value;
            }
        }

        public string Kernev
        {
            get
            {
                return kernev;
            }

            set
            {
                kernev = value;
            }
        }

        public string Igszam
        {
            get
            {
                return igszam;
            }

            set
            {
                igszam = value;
            }
        }

        public string Lakcimszam
        {
            get
            {
                return lakcimszam;
            }

            set
            {
                lakcimszam = value;
            }
        }

        public string Szulhely
        {
            get
            {
                return szulhely;
            }

            set
            {
                szulhely = value;
            }
        }

        public DateTime Szulido
        {
            get
            {
                return szulido;
            }

            set
            {
                szulido = value;
            }
        }
    }
}
