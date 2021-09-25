using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;

namespace Penztar
{
    class Nyomtatas
    {
        Tranzakcio tr;
        Mozgas m;
        delegate void NyomtatVegrehajt(int magassag);
        public Nyomtatas(Tranzakcio tr)
        {
            this.tr = tr;
        }
        public Nyomtatas(Mozgas m)
        {
            this.m = m;
        }
        public static string szamrolBeture(int szam)
        {
            string szambetu = szam.ToString();
            string husz = Convert.ToInt32(szambetu[szambetu.Length - 1].ToString()) == 0 && Convert.ToInt32(szambetu[szambetu.Length - 2].ToString()) == 2 ? "húsz" : "huszon";
            string tiz = Convert.ToInt32(szambetu[szambetu.Length - 1].ToString()) == 0 && Convert.ToInt32(szambetu[szambetu.Length - 2].ToString()) == 1 ? "tíz" : "tizen";
            string[] egyesek = new string[] { "", "egy", "kettő", "három", "négy", "öt", "hat", "hét", "nyolc", "kilenc" };
            string[] tizesek = new string[] { "", tiz, husz, "harminc", "negyven", "ötven", "hatvan", "hetven", "nyolcvan", "kilencven" };
            string[] szazasok = new string[] { "", "egyszáz", "kétszáz", "háromszáz", "négyszáz", "ötszáz", "hatszáz", "hétszáz", "nyolcszáz", "kilencszáz" };
            string szo = "";

            int hossz = szambetu.Length;
            switch (hossz)
            {
                case 1:
                    int egyes = Convert.ToInt32(Convert.ToString(szambetu[0]));
                    szo = egyesek[egyes];
                    break;
                case 2:
                    szo = tizesek[Convert.ToInt32(szambetu[0].ToString())] + egyesek[Convert.ToInt32(szambetu[1].ToString())];
                    break;
                case 3:
                    szo = szazasok[Convert.ToInt32(szambetu[0].ToString())] + tizesek[Convert.ToInt32(szambetu[1].ToString())] + egyesek[Convert.ToInt32(szambetu[2].ToString())];
                    break;
                case 4:
                    szo = egyesek[Convert.ToInt32(szambetu[0].ToString())] + "ezer" + szazasok[Convert.ToInt32(szambetu[1].ToString())] + tizesek[Convert.ToInt32(szambetu[2].ToString())] + egyesek[Convert.ToInt32(szambetu[3].ToString())];
                    break;
                case 5:
                    szo = tizesek[Convert.ToInt32(szambetu[0].ToString())] + egyesek[Convert.ToInt32(szambetu[1].ToString())] + "ezer" + szazasok[Convert.ToInt32(szambetu[2].ToString())] + tizesek[Convert.ToInt32(szambetu[3].ToString())] + egyesek[Convert.ToInt32(szambetu[4].ToString())];
                    break;
                case 6:
                    szo = szazasok[Convert.ToInt32(szambetu[0].ToString())] + tizesek[Convert.ToInt32(szambetu[1].ToString())] + egyesek[Convert.ToInt32(szambetu[2].ToString())] + "ezer" + szazasok[Convert.ToInt32(szambetu[3].ToString())] + tizesek[Convert.ToInt32(szambetu[4].ToString())] + egyesek[Convert.ToInt32(szambetu[5].ToString())];
                    break;
                case 7:
                    szo = egyesek[Convert.ToInt32(szambetu[0].ToString())] + "millió" + szazasok[Convert.ToInt32(szambetu[1].ToString())] + tizesek[Convert.ToInt32(szambetu[2].ToString())] + (egyesek[Convert.ToInt32(szambetu[3].ToString())] == "0" ? egyesek[Convert.ToInt32(szambetu[3].ToString())] : egyesek[Convert.ToInt32(szambetu[3].ToString())] + "ezer") + szazasok[Convert.ToInt32(szambetu[4].ToString())] + tizesek[Convert.ToInt32(szambetu[5].ToString())] + egyesek[Convert.ToInt32(szambetu[6].ToString())];

                    break;
                case 8:
                    szo = tizesek[Convert.ToInt32(szambetu[0].ToString())] + egyesek[Convert.ToInt32(szambetu[1].ToString())] + "millió" + szazasok[Convert.ToInt32(szambetu[2].ToString())] + tizesek[Convert.ToInt32(szambetu[3].ToString())] + egyesek[Convert.ToInt32(szambetu[4].ToString())] + "ezer" + szazasok[Convert.ToInt32(szambetu[5].ToString())] + tizesek[Convert.ToInt32(szambetu[6].ToString())] + egyesek[Convert.ToInt32(szambetu[7].ToString())];
                    break;
                default:
                    break;
            }
            if (szo.EndsWith("ezer") /*&& szo[szo.Length - 5] == 'ó'*/)
            {
                szo.Remove(szo.Length - 4, 4);
            }
            return szo;
        }

        internal void KiadasNyomtat(object sender, PrintPageEventArgs e)
        {
            int margo = 70;
            NyomtatVegrehajt x = (int magasság) =>
            {
                //őartnerpénztár lekérdezése
                List<string> penztarlista = ABKezelo.PenztarLekerdez();
                string partnerpenztar = penztarlista.Where(y => y.StartsWith(m.MasikPenztar.ToString())).ToList()[0];
                //CÍM
                e.Graphics.DrawString("Pénztármozgás", new Font(FontFamily.GenericSerif, 13, FontStyle.Bold), Brushes.Black, new PointF(330, magasság));
                string csík = "";
                for (int i = 0; i < 120; i++)
                {
                    csík += "=";
                } //Csík kirajzolása
                e.Graphics.DrawString(csík, new Font(FontFamily.GenericSerif, 7, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 25));
                //jobb szélső csíkok
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo+670, magasság + 35));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 45));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 55));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 65));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 75));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 85));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 95));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 105));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 115));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 125));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 135));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 145));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 155));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 165));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 175));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 185));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 195));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 205));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 215));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 225));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 235));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 245));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 255));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo + 670, magasság + 265));

                //Pénztár cég neve, cég neve
                e.Graphics.DrawString("|| Küldő:", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 35));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 45));
                e.Graphics.DrawString("|| " + Penztar.Cegnev, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 55));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 65));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 75));
                e.Graphics.DrawString("|| "+Penztar.Cim, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 85));
                e.Graphics.DrawString("|| " , new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 95));
                e.Graphics.DrawString("|| " , new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 105));

                //Középcsík
                e.Graphics.DrawString("|| Fogadó:", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 35));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 45));
                e.Graphics.DrawString("|| "+Penztar.Cegnev, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 55));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 65));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 75));
                e.Graphics.DrawString("|| "+partnerpenztar, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 85));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 95));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 105));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 115));
                e.Graphics.DrawString("||Szállító aláírása: ", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 205));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 215));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 225));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 235));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 245));
               
              
                //Csík kirajzolása
                e.Graphics.DrawString(csík, new Font(FontFamily.GenericSerif, 7, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 115));
                //Sorszám és dátum
                e.Graphics.DrawString("|| Sorszám:" + m.Sorszam, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 125));
                e.Graphics.DrawString("|| Dátum:" + m.Datum, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(380, magasság + 125));
                //Csík kirajzolása
                e.Graphics.DrawString(csík, new Font(FontFamily.GenericSerif, 7, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 135));
                //Jogcím
                e.Graphics.DrawString("|| Jogcím: Transzfer más pénztár számára" , new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 145));
                //Csík kirajzolása
                e.Graphics.DrawString(csík, new Font(FontFamily.GenericSerif,7, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 155));
                //összegzés
                e.Graphics.DrawString("|| Kifizetett összeg: " + m.Osszeg+" "+m.Tipus+" / Árfolyam: "+m.Arfolyam, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 165));
                e.Graphics.DrawString("|| azaz: " + szamrolBeture(m.Osszeg) , new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 185));
                //Csík kirajzolása
                e.Graphics.DrawString(csík, new Font(FontFamily.GenericSerif, 7, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 195));
                e.Graphics.DrawString("|| Ügyintéző aláírása, PH: ", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 205));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 215));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 225));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 235));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 245));
                e.Graphics.DrawString("||", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 255));
                e.Graphics.DrawString(csík, new Font(FontFamily.GenericSerif, 7, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 255));
                e.Graphics.DrawString("|| Megjegyzés: "+m.Megjegyzes, new Font(FontFamily.GenericSerif, 7, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 265));
                e.Graphics.DrawString(csík, new Font(FontFamily.GenericSerif, 7, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 275));

            };
            x(50);
            x(600);
           
        }

        public void SzamlaNyomtat(object sender, PrintPageEventArgs e)
        {
           
            int margo = 50;
            NyomtatVegrehajt x=(int magasság)=>{
                
                if (tr.Vetel)
                {
                    e.Graphics.DrawString("BIZONYLAT - VALUTAVÉTEL", new Font(FontFamily.GenericSerif, 13, FontStyle.Bold), Brushes.Black, new PointF(300, magasság));
                }
                else
                {
                    e.Graphics.DrawString("BIZONYLAT - VALUTAELADÁS", new Font(FontFamily.GenericSerif, 15, FontStyle.Bold), Brushes.Black, new PointF(300, magasság));
                }
                //közvetítő bank
                e.Graphics.DrawString("A(z) " + Penztar.BankNeve + " közvetítője/" + "Approved mediator of " + Penztar.BankNeve, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 45));
                //cég neve és címe
                e.Graphics.DrawString(Penztar.Cegnev + Environment.NewLine + Penztar.Cim, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 85));
                e.Graphics.DrawString("Sorszám: " + tr.Trsorszam + Environment.NewLine + "Időpont: " + tr.Datum.ToString(), new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(550, magasság + 85));
                //csík
                string csík = "";
                for (int i = 0; i < 260; i++)
                {
                    csík += '=';
                }
                e.Graphics.DrawString(csík, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(0, magasság + 115));
                //szolgáltatás
                e.Graphics.DrawString("Szolgáltatás: SZJ 67.13     Egyéb pénzügyi kiegészítő tevékenység     Tárgyi adómentes", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 130));
                //Mennyiség
                string valutamennyiseg = "Valuta neme: " + tr.Tipus.ToString() + "    |     Mennyiség: " + tr.Valuta + "     |    Árfolyama: " + tr.Arfolyam + "    |     Jutalék: 0%, összege 0 Ft" + "    |    Forintérték: " + tr.Forint + " ft";
                e.Graphics.DrawString(valutamennyiseg, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 160));

                //kiírás betűvel
                string kifizetett = "";
                int mennyi = 0;
                if (tr.Vetel)
                {
                    kifizetett = tr.Forint + " Forint";
                    mennyi = tr.Forint;
                }
                else
                {
                    kifizetett = tr.Valuta + " " + tr.Tipus.ToString();
                    mennyi = tr.Valuta;
                }
                e.Graphics.DrawString("Kifizezett összeg: " + kifizetett + Environment.NewLine+Environment.NewLine + "azaz: " + szamrolBeture(mennyi), new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 190));
                //Cégadatok
                e.Graphics.DrawString(Penztar.Cegnev + "\t\t\t" + Penztar.Cim + "\t\tAdószám: " + Penztar.Adoszam, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 250));
                //Aláírás és csík
                e.Graphics.DrawString("Ügyintéző aláírása, PH", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 275));
                e.Graphics.DrawString(csík, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(0, magasság + 320));
                //Ügyfél neve és szülnév
                string ugyfelnev = "";
                if (tr.Uf is Maganszemely)
                {
                    ugyfelnev = (tr.Uf as Maganszemely).Veznev + " " + (tr.Uf as Maganszemely).Kernev;
                }
                else
                {
                    ugyfelnev = (tr.Uf as Jogiszemely).Cegnev;
                }
                e.Graphics.DrawString("Ügyfél neve: " + ugyfelnev, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 355));
                if (tr.Uf is Maganszemely)
                {
                    e.Graphics.DrawString("Igazolvány száma: " + (tr.Uf as Maganszemely).Igszam, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 380));
                    e.Graphics.DrawString("Születési hely/idő: " + (tr.Uf as Maganszemely).Szulhely+"/"+ (tr.Uf as Maganszemely).Szulido.ToShortDateString(), new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 405));
                    e.Graphics.DrawString("Lakcím és lakcímkártya száma: " + (tr.Uf as Maganszemely).Irsz+" "+ (tr.Uf as Maganszemely).Helyseg+" "+ (tr.Uf as Maganszemely).Utcahaz + "/" + (tr.Uf as Maganszemely).Lakcimszam, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 430));

                }
                else
                {
                    e.Graphics.DrawString("Cég székhelye: " + (tr.Uf as Jogiszemely).Irsz+" "+ (tr.Uf as Jogiszemely).Helyseg+" "+ (tr.Uf as Jogiszemely).Utcahaz, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 380));
                    e.Graphics.DrawString("Cég adószáma: " + (tr.Uf as Jogiszemely).Adoszam, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 405));
                    e.Graphics.DrawString("Cég cégjegyzékszáma: " + (tr.Uf as Jogiszemely).Cegjegyzek, new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 430));
                }

                e.Graphics.DrawString("Az ügyfél büntetőjogi felelőssége tudatában kijelenti, hogy a fenti adatai a valóságnak megfelelnek", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 455));
                e.Graphics.DrawString("Ügyfél aláírása", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(margo, magasság + 480));
                

            };
            x(50);
            x(600);

        }
       
    }
}
