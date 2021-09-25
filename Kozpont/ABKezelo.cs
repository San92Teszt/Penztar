using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Kozpont
{
    static class ABKezelo
    {
        static MySqlCommand comm;
        static MySqlConnection conn;
        static ABKezelo()
        {
            conn = new MySqlConnection("Server=" + Rendszerkonfig.Ipcim + ";Database=" + Rendszerkonfig.Dbnev + ";Uid=" + Rendszerkonfig.Felh + ";Pwd=" + Rendszerkonfig.Jel);

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
    }
}
