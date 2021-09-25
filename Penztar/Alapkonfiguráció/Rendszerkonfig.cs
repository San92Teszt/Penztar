using System;
using System.Collections.Generic;
using System.Text;

namespace Penztar
{
    static class Rendszerkonfig
    {
        static string ipcim;
        static string dbnev;
        static string felh;
        static string jel;
       

        public static string Ipcim
        {
            get
            {
                return ipcim;
            }

            set
            {
                ipcim = value;
            }
        }

        public static string Dbnev
        {
            get
            {
                return dbnev;
            }

            set
            {
                dbnev = value;
            }
        }

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

        public static string Jel
        {
            get
            {
                return jel;
            }

            set
            {
                jel = value;
            }
        }

      
    }
}
