using System;
using System.Collections.Generic;
using System.Text;

namespace Penztar
{
    class Felhasznalo
    {
        static string felh;
        static string jelsz;
        static bool admin;

        public static string Felh
        {
            get
            {
                return felh;
            }

            set
            {
                felh = value;
            }
        }

        public static string Jelsz
        {
            get
            {
                return jelsz;
            }

            set
            {
                jelsz = value;
            }
        }

        public static bool Admin
        {
            get
            {
                return admin;
            }

            set
            {
                admin = value;
            }
        }
    }
}
