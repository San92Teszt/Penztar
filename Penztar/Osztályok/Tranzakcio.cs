using System;
using System.Collections.Generic;
using System.Text;

namespace Penztar
{
    public enum ValutaTipus
    {
        EUR,
        USD
    }
    class Tranzakcio
    {
        int penztarSzam;
        string trsorszam;
        DateTime datum;
        bool vetel;
        int forint;
        int valuta;
        ValutaTipus tipus;
        double arfolyam;
        bool storno;
        Ugyfel uf;

        public Tranzakcio(int penztarSzam, string trsorszam, DateTime datum, bool vetel, int forint, int valuta, ValutaTipus tipus, double arfolyam, bool storno, Ugyfel uf)
        {
            PenztarSzam = penztarSzam;
            Trsorszam = trsorszam;
            Datum = datum;
            Vetel = vetel;
            Forint = forint;
            Valuta = valuta;
            Tipus = tipus;
            Arfolyam = arfolyam;
            Storno = storno;
            Uf = uf;
        }

        public int PenztarSzam
        {
            get
            {
                return penztarSzam;
            }

            set
            {
                penztarSzam = value;
            }
        }

        public string Trsorszam
        {
            get
            {
                return trsorszam;
            }

            set
            {
                trsorszam = value;
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

        public bool Vetel
        {
            get
            {
                return vetel;
            }

            set
            {
                vetel = value;
            }
        }

        public int Forint
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

        public int Valuta
        {
            get
            {
                return valuta;
            }

            set
            {
                valuta = value;
            }
        }

        public ValutaTipus Tipus
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

        public bool Storno
        {
            get
            {
                return storno;
            }

            set
            {
                storno = value;
            }
        }

        internal Ugyfel Uf
        {
            get
            {
                return uf;
            }

            set
            {
                uf = value;
            }
        }
    }
}
