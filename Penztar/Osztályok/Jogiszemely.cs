using System;
using System.Collections.Generic;
using System.Text;

namespace Penztar
{
    class Jogiszemely : Ugyfel
    {
        string cegnev;
        string adoszam;
        string cegjegyzek;
        public Jogiszemely(int ufszam, int irsz, string helyseg, string utcahaz, string cegnev, string adoszam, string cegjegyzek) : base(ufszam, irsz, helyseg, utcahaz)
        {
            Cegnev = cegnev;
            Adoszam = adoszam;
            Cegjegyzek = cegjegyzek;
        }

        public string Cegnev
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

        public string Adoszam
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

        public string Cegjegyzek
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
    }
}
