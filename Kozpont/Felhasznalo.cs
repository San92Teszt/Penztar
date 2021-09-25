using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozpont
{
    class Felhasznalo
    {
        private string felh;
        private string jel;

        public Felhasznalo(string felh, string jel)
        {
            Felh = felh;
            Jel = jel;
        }

        public string Felh
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

        public string Jel
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
