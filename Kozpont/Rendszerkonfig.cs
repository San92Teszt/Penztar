namespace Kozpont
{
    internal class Rendszerkonfig
    {
        static string ipcim="localhost";
        static string dbnev="Penztar";
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