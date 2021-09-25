using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Penztar
{
    static class Fajlkezelo
    {
        public static void PenztarAdatbetolt()
        {
            string[] adatok = File.ReadAllLines("penztaradatok.csv")[0].Split(';');
            Penztar.PenztarSorszam = Convert.ToInt32(adatok[0]);
            Penztar.Cim = adatok[1];
            Penztar.Rovidnev = adatok[2];
            Penztar.Cegnev = adatok[3];
            Penztar.Cegjegyzek = adatok[4];
            Penztar.Adoszam = adatok[5];
            Penztar.BankNeve = adatok[6];
        }

        public static void PenztarAdatMent(string ps,string cim, string rovidn, string cegn, string cegjegy,string adoszam,string bankNev)
        {
            StreamWriter ment = new StreamWriter("penztaradatok.csv");
            string sor = ps + ";" + cim + ";" + rovidn + ";" + cegn + ";" + cegjegy + ";" + adoszam+";"+bankNev;
                ment.WriteLine(sor);
            ment.Close();
        }

        public static void RendszerKonfigBetolt()
        {
            string[] adatok = File.ReadAllLines("rendszerkonfig.csv")[0].Split(';');
            Rendszerkonfig.Ipcim = adatok[0];
            Rendszerkonfig.Dbnev = adatok[1];
            Rendszerkonfig.Felh = adatok[2];
            Rendszerkonfig.Jel = adatok[3];
        }
        public static void RenszerKonfigMent(string ip, string DB,string felh, string jel)
        {
            StreamWriter ment = new StreamWriter("rendszerkonfig.csv");
            string sor = ip + ";" + DB + ";" + felh + ";" + jel;
            ment.WriteLine(sor);
            ment.Close();
        }
    }
}
