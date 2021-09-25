using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penztar
{
    class Mozgas
    {
        int masikPenztar;
        string tipus;
        double arfolyam;
        string sorszam;
        DateTime datum;
        bool kiadas;
        string megjegyzes;
        int osszeg;

        public Mozgas(int masikPenztar, string tipus, double arfolyam, string sorszam, DateTime datum, bool kiadas, string megjegyzes, int osszeg)
        {
            this.masikPenztar = masikPenztar;
            this.Tipus = tipus;
            this.Arfolyam = arfolyam;
            this.Sorszam = sorszam;
            this.Datum = datum;
            this.Kiadas = kiadas;
            this.Megjegyzes = megjegyzes;
            this.Osszeg = osszeg;
        }

        public int MasikPenztar
        {
            get
            {
                return masikPenztar;
            }

            set
            {
                masikPenztar = value;
            }
        }

        public string Tipus
        {
            get
            {
                return tipus;
            }

            set
            {
                tipus = value;
            }
        }

        public double Arfolyam
        {
            get
            {
                return arfolyam;
            }

            set
            {
                arfolyam = value;
            }
        }

        public string Sorszam
        {
            get
            {
                return sorszam;
            }

            set
            {
                sorszam = value;
            }
        }

        public DateTime Datum
        {
            get
            {
                return datum;
            }

            set
            {
                datum = value;
            }
        }

        public bool Kiadas
        {
            get
            {
                return kiadas;
            }

            set
            {
                kiadas = value;
            }
        }

        public string Megjegyzes
        {
            get
            {
                return megjegyzes;
            }

            set
            {
                megjegyzes = value;
            }
        }

        public int Osszeg
        {
            get
            {
                return osszeg;
            }

            set
            {
                osszeg = value;
            }
        }
    }
}
