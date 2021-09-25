using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
namespace Penztar
{
    static class ABKezelo
    {
        static MySqlCommand comm;
        static MySqlConnection conn;
        static ABKezelo()
        {
            conn = new MySqlConnection("Server="+Rendszerkonfig.Ipcim+";Database="+Rendszerkonfig.Dbnev+";Uid="+Rendszerkonfig.Felh+";Pwd="+Rendszerkonfig.Jel);
      
            comm = new MySqlCommand();
            comm.Connection = conn;
            Megnyit();
        }
        public static void UjraKonfig()
        {
            conn.ConnectionString = "Server=" + Rendszerkonfig.Ipcim + ";Database=" + Rendszerkonfig.Dbnev + ";Uid=" + Rendszerkonfig.Felh + ";Pwd=" + Rendszerkonfig.Jel;
        }
        public static void Lezar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static string Megnyit()
        {
            try
            {
                conn.Open();
                return "Adatbázis elérhető";
            }
            catch (Exception)
            {
                return "Nincs adatbáziskapcsolat.";
              
            }
           
        }
        public static bool VanKapcsolat()
        {
            try
            {
                comm.CommandText = "USE penztar";
                comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

      
        public static Maganszemely LekerdezIgazolvany(string igszam)
        {
            Maganszemely uf=null;
            try
            {
                comm.CommandText = "SELECT * FROM ugyfel,maganszemely WHERE maganszemely.igszam=\'" + igszam+"\' AND maganszemely.ufszam=ugyfel.ufszam";
                using (MySqlDataReader olvas=comm.ExecuteReader())
                {
                    while (olvas.Read())
                    {
                        uf = new Maganszemely(Convert.ToInt32(olvas["ufszam"]), Convert.ToInt32(olvas["irsz"]), olvas["helyseg"].ToString(), olvas["utcahaz"].ToString(), olvas["veznev"].ToString(), olvas["kernev"].ToString(), olvas["igszam"].ToString(), olvas["lakcimszam"].ToString(), olvas["szulhely"].ToString(), DateTime.Parse(olvas["szulido"].ToString()));
                 
                    }
                    olvas.Close();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return uf;
        }
        public static Jogiszemely CegLekerdez(string cegnev)
        {
            Jogiszemely uf = null;
            try
            {
                comm.CommandText = "SELECT * FROM ugyfel,jogiszemely WHERE jogiszemely.cegnev=\'" + cegnev + "\' AND jogiszemely.ufszam=ugyfel.ufszam";
                using (MySqlDataReader olvas = comm.ExecuteReader())
                {
                    while (olvas.Read())
                    {
                        uf = new Jogiszemely(Convert.ToInt32(olvas["ufszam"]), Convert.ToInt32(olvas["irsz"]), olvas["helyseg"].ToString(), olvas["utcahaz"].ToString(), olvas["cegnev"].ToString(), olvas["adoszam"].ToString(), olvas["cegjegyzek"].ToString());

                    }
                    olvas.Close();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return uf;
        }

        public static bool Belepes(string nev, string kod, ref bool admin)
        {
            try
            {
                
                comm.Parameters.Clear();
                string kodkonvert = Security.SHA1Convert(kod);
                comm.CommandText = "SELECT * FROM felh WHERE nev=@nev AND jelszo=@jel";
                comm.Parameters.AddWithValue("@nev", nev);
                comm.Parameters.AddWithValue("jel", kodkonvert);
                using (MySqlDataReader olvas=comm.ExecuteReader())
                {
                    while (olvas.Read())
                    {
                        Felhasznalo.Felh = olvas["nev"].ToString();
                        
                        if (Convert.ToInt32(olvas["admin"])==1)
                        {
                            admin = true;
                        }
                        else
                        {
                            admin = false;
                        }
                        return true;
                    }
                    olvas.Close();
                }
                
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void EgyenlegBetolt()
        {
            try
            {
                comm.CommandText = "SELECT huf,eur,usd from penztaregyenleg WHERE psorszam=" + Penztar.PenztarSorszam;
                using (MySqlDataReader olvas=comm.ExecuteReader())
                {
                    while (olvas.Read())
                    {
                        Egyenlegek.Forint = Convert.ToInt32(olvas["huf"]);
                        Egyenlegek.Eur = Convert.ToInt32(olvas["eur"]);
                        Egyenlegek.Usd = Convert.ToInt32(olvas["usd"]);
                    }
                    olvas.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void EgyenlegModosit(ValutaTipus tip, int forint, int valuta)
        {
            try
            {
                
                switch (tip)
                {
                    case ValutaTipus.EUR:
                        comm.CommandText = "UPDATE penztaregyenleg SET eur=" + valuta + ", huf=" + forint + " WHERE psorszam=" + Penztar.PenztarSorszam;
                      
                        break;
                        
                    case ValutaTipus.USD:
                        comm.CommandText = "UPDATE penztaregyenleg SET usd=" + valuta + ", huf=" + forint + " WHERE psorszam=" + Penztar.PenztarSorszam;
                        break;
                }
                if (tip==null)
                {

                }
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void EgyenlegModosit(int osszeg, string nem)
        {
            try
            {

                comm.Parameters.Clear();
                switch (nem)
                {
                    case "huf":
                        comm.CommandText = "UPDATE penztaregyenleg SET huf=@ossz WHERE psorszam=@ssz";
                        break;
                    case "eur":
                        comm.CommandText = "UPDATE penztaregyenleg SET eur=@ossz WHERE psorszam=@ssz";
                        break;
                    case "usd":
                        comm.CommandText = "UPDATE penztaregyenleg SET usd=@ossz WHERE psorszam=@ssz";
                        break;
                    default:
                        break;
                }
                
               // comm.Parameters.AddWithValue("@nem", nem);
                comm.Parameters.AddWithValue("@ossz", osszeg);
                comm.Parameters.AddWithValue("ssz", Penztar.PenztarSorszam);
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
       

        public static void ArfLekerdez()
        {
            try
            {
                double veszeur = 0;
                double veszusd = 0;
                double eladeur = 0;
                double eladusd = 0;
                comm.CommandText = "SELECT * from vetelarf WHERE psorszam=" + Penztar.PenztarSorszam;
               
                MySqlDataReader olvasvetel = comm.ExecuteReader();
                while (olvasvetel.Read())
                {
                    veszeur = Convert.ToDouble(olvasvetel["eur"]);
                     veszusd = Convert.ToDouble(olvasvetel["usd"]);
                }
                
                olvasvetel.Close();
                comm.CommandText = "SELECT * from eladarf WHERE psorszam=" + Penztar.PenztarSorszam;
            
                MySqlDataReader olvaselad = comm.ExecuteReader();
                while (olvaselad.Read())
                {
                     eladeur = Convert.ToDouble(olvaselad["eur"]);
                     eladusd = Convert.ToDouble(olvaselad["usd"]);
                }
               
                olvaselad.Close();
                Arfolyam.Eur = new KeyValuePair<double, double>(veszeur, eladeur);
                Arfolyam.Usd = new KeyValuePair<double, double>(veszusd, eladusd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static void TrHozzaad(Tranzakcio tr)
        {
            try
            {
                string maidatum = "" + DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day + ".";
                comm.Parameters.Clear();
                comm.CommandText = "INSERT INTO tranzakcio VALUES (@psorsz,@trsorsz,@datum,@vetel,@forint,@valuta,@tipus,@arf,@storno,@ufszam,@felh)";
                comm.Parameters.AddWithValue("@psorsz", tr.PenztarSzam);
                comm.Parameters.AddWithValue("@trsorsz", tr.Trsorszam);
                comm.Parameters.AddWithValue("@datum", DateTime.Parse(maidatum));
                comm.Parameters.AddWithValue("@vetel", tr.Vetel == true ? 1 : 0);
                comm.Parameters.AddWithValue("@forint", tr.Forint);
                comm.Parameters.AddWithValue("@valuta", tr.Valuta);
                comm.Parameters.AddWithValue("@tipus", Convert.ToInt32(tr.Tipus));
                comm.Parameters.AddWithValue("@arf", tr.Arfolyam);
                comm.Parameters.AddWithValue("@storno", 0);
                comm.Parameters.AddWithValue("@ufszam", tr.Uf.Ufszam);
                comm.Parameters.AddWithValue("@felh", Felhasznalo.Felh);
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void KozepLekerdez()
        {
            try
            {
                comm.CommandText = "SELECT eur, usd FROM kozeparf";
                using (MySqlDataReader olvas=comm.ExecuteReader())
                {
                    while (olvas.Read())
                    {
                        Arfolyam.EurKozep = Convert.ToDouble(olvas["eur"]);
                        Arfolyam.UsdKozep = Convert.ToDouble(olvas["usd"]);
                    }
                    olvas.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void UgyfelHozzaad(Ugyfel u)
        {
            try
            {
                comm.Parameters.Clear();
                
                if (u is Maganszemely)
                {
                    bool van = false;
                    comm.CommandText = "SELECT * FROM maganszemely where igszam=\'" + (u as Maganszemely).Igszam + "\'";
                    MySqlDataReader olvas = comm.ExecuteReader();
                    while (olvas.Read())
                    {
                        van = true;
                    }
                    olvas.Close();
                    if (van)
                    {
                        throw new ArgumentException("Ezzel az igazolványszámmal már szerepel ügyfél az adatbázisban!");
                    }
                    else
                    {
                        comm.CommandText = "INSERT INTO ugyfel (ufszam, irsz,helyseg,utcahaz) VALUES (@ufsz,@irsz,@hely,@utcahaz)";
                        comm.Parameters.AddWithValue("@ufsz", u.Ufszam);
                        comm.Parameters.AddWithValue("@irsz", u.Irsz);
                        comm.Parameters.AddWithValue("@hely", u.Helyseg);
                        comm.Parameters.AddWithValue("@utcahaz", u.Utcahaz);
                        comm.ExecuteNonQuery();
                        comm.Parameters.Clear();
                        comm.CommandText = "INSERT INTO Maganszemely (ufszam,veznev,kernev,igszam,lakcimszam,szulhely,szulido) VALUES (@ufsz,@veznev,@kernev,@igsz,@lakc,@szulh,@szuli)";
                        comm.Parameters.AddWithValue("@ufsz", (u as Maganszemely).Ufszam);
                        comm.Parameters.AddWithValue("@veznev", (u as Maganszemely).Veznev);
                        comm.Parameters.AddWithValue("@kernev", (u as Maganszemely).Kernev);
                        comm.Parameters.AddWithValue("@igsz", (u as Maganszemely).Igszam);
                        comm.Parameters.AddWithValue("@lakc", (u as Maganszemely).Lakcimszam);
                        comm.Parameters.AddWithValue("@szulh", (u as Maganszemely).Szulhely);
                        comm.Parameters.AddWithValue("@szuli", (u as Maganszemely).Szulido);
                        comm.ExecuteNonQuery();
                    }
                }
                //JOGISZEMÉLY:
                else
                {
                    bool van = false;
                    comm.CommandText = "SELECT * FROM jogiszemely where cegnev=\'" + (u as Jogiszemely).Cegnev + "\' AND cegjegyzek=\'"+(u as Jogiszemely).Cegjegyzek+"\' AND adoszam=\'"+(u as Jogiszemely).Adoszam+"\'";
                    MySqlDataReader olvas = comm.ExecuteReader();
                    while (olvas.Read())
                    {
                        van = true;
                    }
                    olvas.Close();
                    if (van)
                    {
                        throw new ArgumentException("Ezzel az adatokkal már szerepel cég az adatbázisban!");
                    }
                    else
                    {
                        comm.CommandText = "INSERT INTO ugyfel (ufszam, irsz,helyseg,utcahaz) VALUES (@ufsz,@irsz,@hely,@utcahaz)";
                        comm.Parameters.AddWithValue("@ufsz", u.Ufszam);
                        comm.Parameters.AddWithValue("@irsz", u.Irsz);
                        comm.Parameters.AddWithValue("@hely", u.Helyseg);
                        comm.Parameters.AddWithValue("@utcahaz", u.Utcahaz);
                        comm.ExecuteNonQuery();
                        comm.Parameters.Clear();
                        comm.CommandText = "INSERT INTO Jogiszemely (ufszam,cegnev, cegjegyzek, adoszam) VALUES (@ufsz,@cegn,@cegj,@adosz)";
                        comm.Parameters.AddWithValue("@ufsz", (u as Jogiszemely).Ufszam);
                        comm.Parameters.AddWithValue("@cegn", (u as Jogiszemely).Cegnev);
                        comm.Parameters.AddWithValue("@cegj", (u as Jogiszemely).Cegjegyzek);
                        comm.Parameters.AddWithValue("@adosz", (u as Jogiszemely).Adoszam);
                
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int HanyUgyfel()
        {
            int hanyugyfel = 0;
            try
            {
                comm.CommandText = "SELECT COUNT(*) from ugyfel";
                using (MySqlDataReader olvas=comm.ExecuteReader())
                {
                    while (olvas.Read())
                    {
                        hanyugyfel = Convert.ToInt32(olvas["COUNT(*)"]);
                    }
                }
            }
            catch (Exception)
            {

                return hanyugyfel;
            }
            return hanyugyfel;
        }
        public static void AtvenniValoTorol(Mozgas m)
        {
            try
            {
                comm.Parameters.Clear();
                comm.CommandText = "DELETE FROM varakozo WHERE sorszam=@sorszam";
                comm.Parameters.AddWithValue("@sorszam", m.Sorszam);
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Mozgas>AtvennivaloBetolt()
        {
            try
            {
                List<Mozgas> mLista = new List<Mozgas>();
                comm.Parameters.Clear();
                comm.CommandText = "select * from varakozo WHERE fogado=@fog and atvette=@atvet AND kiadas=@kiad";
                comm.Parameters.AddWithValue("@fog", Penztar.PenztarSorszam);
                comm.Parameters.AddWithValue("@atvet", 0);
                comm.Parameters.AddWithValue("@kiad", 1);
                using (MySqlDataReader olvas=comm.ExecuteReader())
                {
                    while (olvas.Read())
                    {
                        mLista.Add(new Mozgas(Convert.ToInt32(olvas["kuldo"]),olvas["Penznem"].ToString(),Convert.ToDouble(olvas["Arfolyam"]),olvas["sorszam"].ToString(),DateTime.Parse(olvas["datum"].ToString()),Convert.ToInt32(olvas["kiadas"])==1?true:false, olvas["megjegyzes"].ToString(),Convert.ToInt32(olvas["osszeg"])));
                    }
                    olvas.Close();
                    return mLista;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void PenztarMozgasHozzaas(Mozgas m)
        {
            try
            {
                comm.Parameters.Clear();
                comm.CommandText = "insert into varakozo values (@kuldo,@fogado,@penznem,@arf,@sorszam,@atvette,@datum,@kiadas,@megj,@ossz)";
                comm.Parameters.AddWithValue("@kuldo", Penztar.PenztarSorszam);
                comm.Parameters.AddWithValue("@fogado", m.MasikPenztar);
                comm.Parameters.AddWithValue("@penznem", m.Tipus);
                comm.Parameters.AddWithValue("arf", m.Arfolyam);
                comm.Parameters.AddWithValue("sorszam", m.Sorszam);
                comm.Parameters.AddWithValue("@atvette", 0);
                comm.Parameters.AddWithValue("@datum", m.Datum);
                comm.Parameters.AddWithValue("@kiadas", m.Kiadas==true?1:0);
                comm.Parameters.AddWithValue("@megj", m.Megjegyzes);
                comm.Parameters.AddWithValue("@ossz",m.Osszeg);
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void PenztarmozgasSorszamGeneral(ref int kiad, ref int bevet)
        {
            try
            {
                
                comm.Parameters.Clear();
                string maidatum = "\'" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "\'";
                comm.CommandText = "SELECT COUNT(*) FROM varakozo WHERE kuldo=@kuldo AND datum=@maidat AND kiadas=@kiad";
                //minden, ami bevétel
                comm.Parameters.AddWithValue("@kuldo", Penztar.PenztarSorszam);
                comm.Parameters.AddWithValue("@maidat",  DateTime.Parse(DateTime
                    .Now.ToShortDateString()));
                comm.Parameters.AddWithValue("@kiad", 0);
                using (MySqlDataReader olvas=comm.ExecuteReader())
                {
                    while (olvas.Read())
                    {
                        bevet = Convert.ToInt32(olvas["COUNT(*)"])+1;
                    }
                    olvas.Close();
                }
                //minden, ami kiadás
                comm.CommandText = "SELECT COUNT(*) FROM varakozo WHERE kuldo=@kuldo AND datum=@maidat AND kiadas=@kiad";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@kuldo", Penztar.PenztarSorszam);
                comm.Parameters.AddWithValue("@maidat", DateTime.Parse(DateTime
                    .Now.ToShortDateString()));
                comm.Parameters.AddWithValue("@kiad", 1);
                using (MySqlDataReader olvas = comm.ExecuteReader())
                {
                    while (olvas.Read())
                    {
                        kiad = Convert.ToInt32(olvas["COUNT(*)"])+1;
                    }
                    olvas.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Tranzakcio> TrMaiLekerdez()
        {
            try
            {

                List<Tranzakcio> trLista = new List<Tranzakcio>();
                string maidatum = "\'" + DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day + "\'";
                comm.CommandText = "SELECT * FROM tranzakcio WHERE psorszam=" + Penztar.PenztarSorszam + "  AND datum=" + maidatum;
                using (MySqlDataReader olvas=comm.ExecuteReader())
                {
                    while (olvas.Read())
                    {
                        trLista.Add(new Tranzakcio(0, olvas["trsorszam"].ToString(), DateTime.Parse(olvas["datum"].ToString()), (olvas["vetel"].ToString() == "1" ? true : false), Convert.ToInt32(olvas["forint"]), Convert.ToInt32(olvas["valuta"]), (ValutaTipus)Convert.ToInt32(olvas["valutatipus"]), Convert.ToDouble(olvas["arf"]), (olvas["storno"].ToString() == "1" ? true : false), new Maganszemely(Convert.ToInt32(olvas["ufszam"]),0,null,null,null,null,null,null,null,DateTime.Now)));
                    }
                    olvas.Close();
                }
                return trLista;


            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<string>PenztarLekerdez()
        {
            List<string> penztarLista = new List<string>();
            try
            {
                comm.CommandText = "SELECT * FROM penztar";
                using (MySqlDataReader olvas =comm.ExecuteReader())
                {
                    while (olvas.Read())
                    {
                        penztarLista.Add(olvas["sorszam"].ToString() + " - " + olvas["rovidnev"].ToString());
                    }
                    olvas.Close();
                }
                return penztarLista;
            }
            catch (Exception)
            {

                throw;
            }
         
        }
        public static int TrLekerdez(bool vetel)
        {
            int hanytr = 0; ;
            string maidatum = "\'"+DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day+ "\'";
            try
            {
               
                if (vetel)
                {
                    comm.CommandText = "SELECT COUNT(*) FROM tranzakcio WHERE psorszam="+Penztar.PenztarSorszam+" AND vetel=1 AND datum=" + maidatum;
                    using (MySqlDataReader olvas=comm.ExecuteReader())
                    {
                        while(olvas.Read())
                        {
                            hanytr = Convert.ToInt32(olvas["COUNT(*)"]);
                        }
                        olvas.Close();
                    }
                }
                else
                {
                    comm.CommandText = "SELECT COUNT(*) FROM tranzakcio WHERE psorszam=" + Penztar.PenztarSorszam + " AND vetel=0 AND datum=" + maidatum;
                    using (MySqlDataReader olvas = comm.ExecuteReader())
                    {
                        while (olvas.Read())
                        {
                            hanytr = Convert.ToInt32(olvas["COUNT(*)"]);
                        }
                        olvas.Close();
                    }
                }
            }
            catch (Exception)
            {

                return hanytr;
            }
            return hanytr;
            
        }

    }
}
