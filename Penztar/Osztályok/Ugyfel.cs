using System;
using System.Collections.Generic;
using System.Text;

namespace Penztar
{
    abstract class Ugyfel
    {
        int ufszam;
        int irsz;
        string helyseg;
        string utcahaz;

        protected Ugyfel(int ufszam, int irsz, string helyseg, string utcahaz)
        {
            Ufszam = ufszam;
            Irsz = irsz;
            Helyseg = helyseg;
            Utcahaz = utcahaz;
        }

        public int Ufszam
        {
            get
            {
                return ufszam;
            }

            set
            {
                ufszam = value;
            }
        }

        public int Irsz
        {
            get
            {
                return irsz;
            }

            set
            {
                irsz = value;
            }
        }

        public string Helyseg
        {
            get
            {
                return helyseg;
            }

            set
            {
                helyseg = value;
            }
        }

        public string Utcahaz
        {
            get
            {
                return utcahaz;
            }

            set
            {
                utcahaz = value;
            }
        }
    }
}
