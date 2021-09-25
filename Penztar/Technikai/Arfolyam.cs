using System;
using System.Collections.Generic;
using System.Text;

namespace Penztar
{
    static class Arfolyam
    {
        static double eurKozep;
        static double usdKozep;

        static KeyValuePair<double, double> eur;
        static KeyValuePair<double, double> usd;
        public static double EurKozep
        {
            get
            {
                return eurKozep;
            }

            set
            {
                eurKozep = value;
            }
        }

        public static double UsdKozep
        {
            get
            {
                return usdKozep;
            }

            set
            {
                usdKozep = value;
            }
        }

        public static KeyValuePair<double, double> Eur
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

        public static KeyValuePair<double, double> Usd
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
