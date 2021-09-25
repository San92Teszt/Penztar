using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace Penztar
{
    public partial class FomenuFrm : Form
    {
        string trsorszam;
        double arf;
        int vetelmennyi;
        int eladasmennyi;
        int hanyugyfel;
        Ugyfel m;
        List<Tranzakcio> trlista;
        public FomenuFrm(bool admin)
        {
            InitializeComponent();
            if (!admin)
            {
                toolStripRendszerkonfig.Enabled = false;
                toolStripPenztarBeallit.Enabled = false;
            }
         
            trlista = new List<Tranzakcio>();
            comboEladValutanem.DataSource = Enum.GetValues(typeof(ValutaTipus));
            comboEladValutanem.SelectedIndex = 0;
            comboVetelValutanem.DataSource = Enum.GetValues(typeof(ValutaTipus));
            comboVetelValutanem.SelectedIndex = 0;
            Fajlkezelo.PenztarAdatbetolt();
            AdatFrissites();
            UgyfelSzamlal();
            DGWFeltolt();
        }
        private void PenztarBeallit_Click(object sender, EventArgs e)
        {
            PenztarBeallitFrm diag = new PenztarBeallitFrm();
            diag.ShowDialog();
        }
        void DGWFeltolt()
        {
            if (dgwMaiTranzi.Columns.Count==0)
            {
                dgwMaiTranzi.Columns.Add("tSorsz", "TrSorszám");
                dgwMaiTranzi.Columns.Add("vetel", "Vétel");
                dgwMaiTranzi.Columns.Add("ftossz", "Forint");
                dgwMaiTranzi.Columns.Add("valuta", "Valuta");
                dgwMaiTranzi.Columns.Add("vtip", "ValutaTípus");
                dgwMaiTranzi.Columns.Add("arf", "Árfolyam");
                dgwMaiTranzi.Columns.Add("storno", "Sztornózva");
                dgwMaiTranzi.Columns.Add("ufszam", "Ügyfélszám");
            }
            dgwMaiTranzi.Rows.Clear();
            foreach (Tranzakcio item in trlista)
            {
                dgwMaiTranzi.Rows.Add(item.Trsorszam, item.Vetel == true ? "Vétel" : "Eladás", item.Forint, item.Valuta, item.Tipus.ToString(), item.Arfolyam, item.Storno == true ? "Igen" : "Nem", item.Uf.Ufszam);
            }
            
        }
        void UgyfelSzamlal()
        {
            hanyugyfel = ABKezelo.HanyUgyfel() + 1;
            txtUfSzam.Text = hanyugyfel.ToString();
        }
        void AdatFrissites()
        {
            vetelmennyi = ABKezelo.TrLekerdez(true)+1;
            eladasmennyi = ABKezelo.TrLekerdez(false)+1;
            trlista = ABKezelo.TrMaiLekerdez();
            if (radioEladas.Checked)
            {
                trsorszam = "VE" + Penztar.PenztarSorszam + "-" + string.Format("{0:000}", eladasmennyi) + "/" + DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day;
            }
            else
            {
                trsorszam = "VV" + Penztar.PenztarSorszam + "-" + string.Format("{0:000}", vetelmennyi) + "/" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;

            }
            
            this.Text = trsorszam;
            ABKezelo.EgyenlegBetolt();
            toolStripHUF.Text = "HUF: " + Egyenlegek.Forint.ToString();
            toolStripEUR.Text = "EUR: " + Egyenlegek.Eur.ToString()+ "€";
            toolStripUSD.Text = "USD: " + Egyenlegek.Usd.ToString() + "$";
           
            ABKezelo.ArfLekerdez();

            switch (comboVetelValutanem.SelectedIndex)
            {
                case 0:                  
                        lblVetelArf.Text = Arfolyam.Eur.Key.ToString();                                                          
                    break;
                case 1:
                                  
                        lblVetelArf.Text = Arfolyam.Usd.Key.ToString();
                    
                    break;
            }
            switch (comboEladValutanem.SelectedIndex)
            {
                case 0:
                    lblEladArf.Text = Arfolyam.Eur.Value.ToString();
                    break;
                case 1:
                    lblEladArf.Text = Arfolyam.Usd.Value.ToString();
                    break;
                default:
                    break;
            }

        }
        private void radioMagan_CheckedChanged(object sender, EventArgs e)
        {
            groupMagan.Enabled = true;
            groupJogi.Enabled = false;

        }

        private void radioJogi_CheckedChanged(object sender, EventArgs e)
        {
            AdatFrissites();
            
            groupMagan.Enabled = false;
            groupJogi.Enabled = true;
        }

        private void radioVetel_CheckedChanged(object sender, EventArgs e)
        {
            
            groupVetel.Enabled = true;
            groupEladas.Enabled = false;
            AdatFrissites();
           

        }

        private void radioEladas_CheckedChanged(object sender, EventArgs e)
        {
            groupVetel.Enabled = false;
            groupEladas.Enabled = true;
            AdatFrissites();
            
        }

        private void btnTrRendben_Click(object sender, EventArgs e)
        {
            try
            {
                
                bool hiba = UgyfelEllenorzes();
                if (!hiba)
                {
                    int ar = 0;
                    int valuta = 0;
                    Ugyfel u = null;
                    if (radioMagan.Checked)
                    {
                        u = new Maganszemely(Convert.ToInt32(txtUfSzam.Text), Convert.ToInt32(txtIrsz.Text), txtHelyseg.Text, txtCim.Text, txtVeznev.Text, txtKernev.Text, txtIgszam.Text, txtLakcszam.Text, txtSzulhely.Text, dateTimeSzulido.Value.Date);
                    }
                    else
                    {
                        u = new Jogiszemely(Convert.ToInt32(txtUfSzam.Text), Convert.ToInt32(txtIrsz.Text), txtHelyseg.Text, txtCim.Text, txtCegnev.Text, txtAdoszam.Text, txtCegjegyzek.Text);
                    }
                    Tranzakcio tr=null;
                    if (radioVetel.Checked)
                    {
                        if (Egyenlegek.Forint-Convert.ToInt32(lblVetelFizetendo.Text)>=0)
                        {
                            ar = Convert.ToInt32(lblVetelFizetendo.Text);
                            valuta = Convert.ToInt32(txtVetelosszeg.Text);
                            tr = new Tranzakcio(Penztar.PenztarSorszam, trsorszam, DateTime.Now, true, ar, valuta, (ValutaTipus)comboVetelValutanem.SelectedItem, Convert.ToDouble(lblVetelArf.Text), false, u);
                            int forintegyenleg = Egyenlegek.Forint - tr.Forint;
                            int valutaegyenleg = 0;
                            switch (tr.Tipus)
                            {
                                case ValutaTipus.EUR:
                                    valutaegyenleg = tr.Valuta + Egyenlegek.Eur;
                                    break;
                                case ValutaTipus.USD:
                                    valutaegyenleg = tr.Valuta + Egyenlegek.Usd;
                                    break;
                                default:
                                    break;
                            }
                            ABKezelo.EgyenlegModosit(tr.Tipus, forintegyenleg, valutaegyenleg);
                            ABKezelo.TrHozzaad(tr);
                            MessageBox.Show("Sikeres tranzakció");
                            AdatFrissites();
                            Nyomtatas ujSzamla = new Nyomtatas(tr);
                            PrintDocument pd = new PrintDocument();
                            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 830, 1170);
                            pd.PrintPage += ujSzamla.SzamlaNyomtat;
                            pd.Print();
                            DGWFeltolt();

                        }
                        else
                        {
                            MessageBox.Show("Nincs elég forintkészlet");
                        }


                    }
                    //ELADÁS
                    else
                    {
                        bool vanpenz = true;
                        if (comboEladValutanem.SelectedIndex==0)
                        {
                            if (Egyenlegek.Eur-Convert.ToInt32(txtEladOsszeg.Text)<0)
                            {
                              vanpenz = false;
                            }
                        }
                        else
                        {
                            if (Egyenlegek.Usd - Convert.ToInt32(txtEladOsszeg.Text) < 0)
                            {
                                vanpenz = false;
                            }
                        }
                        if (vanpenz)
                        {
                            ar = Convert.ToInt32(lblEladArForint.Text);
                            valuta = Convert.ToInt32(txtEladOsszeg.Text);
                            tr = new Tranzakcio(Penztar.PenztarSorszam, trsorszam, DateTime.Now, false, ar, valuta, (ValutaTipus)comboEladValutanem.SelectedItem, Convert.ToDouble(lblEladArf.Text), false, u);
                            int forintegyenleg = Egyenlegek.Forint + tr.Forint;
                            int valutaegyenleg = 0;
                            switch (tr.Tipus)
                            {
                                case ValutaTipus.EUR:
                                    valutaegyenleg = Egyenlegek.Eur - valuta;
                                    break;
                                case ValutaTipus.USD:
                                    valutaegyenleg = Egyenlegek.Usd - valuta;
                                    break;
                                default:
                                    break;
                            }
                            ABKezelo.EgyenlegModosit(tr.Tipus, forintegyenleg, valutaegyenleg);
                            ABKezelo.TrHozzaad(tr);
                            MessageBox.Show("Sikeres tranzakció");
                            AdatFrissites();
                            Nyomtatas ujSzamla = new Nyomtatas(tr);
                            PrintDocument pd = new PrintDocument();
                            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 830, 1170);
                            pd.PrintPage += ujSzamla.SzamlaNyomtat;
                            pd.Print();
                            DGWFeltolt();

                        }
                        else
                        {
                            MessageBox.Show("Nincs elég valutakészlet");
                        }
                        
                    }
                    
                }
                else
                {
                    MessageBox.Show("Minden adatot ki kell tölteni és az irányítószámnak számokból kell állnia!");
                }
            }
               
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
           
           
        }

        private void FomenuFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (splitContainer1.Enabled)
            {
                if (!ABKezelo.VanKapcsolat())
                {
                    splitContainer1.Enabled = false;
                    MessageBox.Show("Nincs adatbáziskapcsolat!", "Adatbázis hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripAllapot.Text = "Kapocslat állapota: Nincs kapcsolat";
                    toolStripPotty.ForeColor = Color.Red;
                }
                else
                {
                    AdatFrissites();
                    toolStripAllapot.Text = "Kapocslat állapota: Adatbázis elérhető";
                    toolStripPotty.ForeColor = Color.Green;
                   
                    
                }
             
            }
            else
            {
                if (ABKezelo.VanKapcsolat())
                {
                    
                    splitContainer1.Enabled = true;
                    toolStripAllapot.Text = "Kapocslat állapota: Adatbázis elérhető";
                    toolStripPotty.ForeColor = Color.Green;

                    ABKezelo.ArfLekerdez();
               
                }
                else
                {
                    ABKezelo.Megnyit();
                }
            }
            
        }

        private void comboVetelValutanem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ValutaTipus)comboVetelValutanem.SelectedItem==ValutaTipus.EUR)
            {
                lblVetelArf.Text = Arfolyam.Eur.Key.ToString();
            }
            else
            {
                lblVetelArf.Text = Arfolyam.Usd.Key.ToString();
            }
        }

        private void comboEladValutanem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ValutaTipus)comboEladValutanem.SelectedItem == ValutaTipus.EUR)
            {
                lblEladArf.Text = Arfolyam.Eur.Value.ToString();
            }
            else
            {
                lblEladArf.Text = Arfolyam.Usd.Value.ToString();
            }
        }

        private void txtVetelosszeg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double vetarf = Convert.ToDouble(lblVetelArf.Text);
                double beirtossz = Convert.ToDouble(txtVetelosszeg.Text);
                int eredmeny = Convert.ToInt32(vetarf * beirtossz);
                lblVetelFizetendo.Text = eredmeny.ToString();
            }
            catch (Exception ex)
            {
                txtVetelosszeg.Text = "0";
                lblVetelFizetendo.Text = "0";
                
            }
            
        }

        private void txtEladOsszeg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double elarf = Convert.ToDouble(lblEladArf.Text);
                double beirtossz = Convert.ToDouble(txtEladOsszeg.Text);
                int eredmeny = Convert.ToInt32(elarf * beirtossz);
                lblEladArForint.Text = eredmeny.ToString();
            }
            catch (Exception ex)
            {
                txtVetelosszeg.Text = "0";
                lblVetelFizetendo.Text = "0";

            }
        }

        private void txtKapottOsszeg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int eladosszeg = Convert.ToInt32(lblEladArForint.Text);
                int Kapottosszeg = Convert.ToInt32(txtKapottOsszeg.Text);
                lblVisszajaro.Text = (Kapottosszeg - eladosszeg).ToString();
            }
            catch (Exception)
            {

               
            }
        }

        private void groupMagan_Enter(object sender, EventArgs e)
        {

        }

        private void txtVeznev_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSzemigLekerdez_Click(object sender, EventArgs e)
        {
            Maganszemely u = ABKezelo.LekerdezIgazolvany(txtIgszam.Text);
            if (u==null)
            {
                MessageBox.Show("Nincs találat!");
            }
            else
            {
                txtUfSzam.Text = u.Ufszam.ToString();
                txtIrsz.Text = u.Irsz.ToString();
                txtHelyseg.Text = u.Helyseg;
                txtCim.Text = u.Utcahaz;
                txtVeznev.Text = u.Veznev;
                txtKernev.Text = u.Kernev;
                txtLakcszam.Text = u.Lakcimszam;
                txtSzulhely.Text = u.Szulhely;
                dateTimeSzulido.Value = u.Szulido;
            }
        }
        private void btnCegKeres_Click(object sender, EventArgs e)
        {
            Jogiszemely u = ABKezelo.CegLekerdez(txtCegnev.Text);
            if (u == null)
            {
                MessageBox.Show("Nincs találat!");
            }
            else
            {
                txtUfSzam.Text = u.Ufszam.ToString();
                txtIrsz.Text = u.Irsz.ToString();
                txtHelyseg.Text = u.Helyseg;
                txtCim.Text = u.Utcahaz;
                txtCegnev.Text = u.Cegnev;
                txtAdoszam.Text = u.Adoszam;
                txtCegjegyzek.Text = u.Cegjegyzek;
            }
        }
        bool UgyfelEllenorzes()
        {
            bool hiba = false;
            foreach (var item in splitContainer1.Panel1.Controls)
            {
                if (item is TextBox)
                {
                    if ((item as TextBox).Text.Length < 1)
                    {
                        hiba = true;
                    }
                }

            }
            if (radioMagan.Checked)
            {
                foreach (var item in groupMagan.Controls)
                {
                    if (item is TextBox)
                    {
                        if ((item as TextBox).Text.Length < 1)
                        {
                            hiba = true;
                        }
                    }

                }
            }
            else
            {
                foreach (var item in groupJogi.Controls)
                {
                    if (item is TextBox)
                    {
                        if ((item as TextBox).Text.Length < 1)
                        {
                            hiba = true;
                        }
                    }

                }
            }


            int szam = 0;
            if (Int32.TryParse(txtIrsz.Text, out szam) == false)
            {
                hiba = true;
            }
            return hiba;
        }
        private void btnUjUgyfel_Click(object sender, EventArgs e)
        {
            bool hiba = UgyfelEllenorzes();
            if (!hiba)
            {

                AdatFrissites();
                UgyfelSzamlal();
                try
                {
                    if (radioMagan.Checked)
                    {
                        m = new Maganszemely(Convert.ToInt32(txtUfSzam.Text), Convert.ToInt32(txtIrsz.Text), txtHelyseg.Text, txtCim.Text, txtVeznev.Text, txtKernev.Text, txtIgszam.Text, txtLakcszam.Text, txtSzulhely.Text, dateTimeSzulido.Value);
                    }
                    else
                    {
                        m = new Jogiszemely(Convert.ToInt32(txtUfSzam.Text), Convert.ToInt32(txtIrsz.Text), txtHelyseg.Text, txtCim.Text, txtCegnev.Text, txtAdoszam.Text, txtCegjegyzek.Text);
                    }
                    ABKezelo.UgyfelHozzaad(m);
                }
                catch (Exception)
                {

                    MessageBox.Show("Már van ilyen ügyfél a rendszerben");
                }
            }
            else
            {
                MessageBox.Show("Minden adatot ki kell tölteni és az irányítószámnak számokból kell állnia!");
            }
           
            
        }

        private void btnMindentTorol_Click(object sender, EventArgs e)
        {
            foreach (var item in splitContainer1.Panel1.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Clear();
                }
            }
            foreach (var item in groupMagan.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Clear();
                }
            }
            foreach (var item in groupJogi.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Clear();
                }
            }
        }

        private void btnKilep_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Valóban kilép a programból","Kilépés",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Close();
            }
        }
        private void KonfigBeallit_Click(object sender, EventArgs e)
        {
            RendszerkonfigFrm diag = new RendszerkonfigFrm();
            diag.ShowDialog();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void KiadBevet_Click(object sender, EventArgs e)
        {
            KiadasBevetelFrm diag = new KiadasBevetelFrm();
            diag.ShowDialog();
        }
    }
}
