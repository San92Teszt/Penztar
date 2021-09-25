using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Penztar
{
    public partial class KiadasBevetelFrm : Form
    {
        string jelenlegiSorszam = "";
        int hanykiad=0;
        int hanybevet=0;
        List<string> penztarak;
        List<Mozgas> mLista;
        Mozgas m;
        public KiadasBevetelFrm()
        {
            InitializeComponent();
            ABKezelo.KozepLekerdez();
            lblEUR.Text = Arfolyam.EurKozep.ToString();
            lblUSD.Text = Arfolyam.UsdKozep.ToString();
            penztarak = ABKezelo.PenztarLekerdez();
            comboPenztar.DataSource = penztarak;
            comboValuta.SelectedIndex = 0;
            ABKezelo.PenztarmozgasSorszamGeneral(ref hanykiad, ref hanybevet);
            
            dgwAtveszFeltolt();
        }

        private void KiadasBevetelFrm_Load(object sender, EventArgs e)
        {

        }

        void dgwAtveszFeltolt()
        {
            mLista = ABKezelo.AtvennivaloBetolt();
            if (dgwAtvesz.Columns.Count==0)
            {
                dgwAtvesz.Columns.Add("kuldo","Küldő");
                dgwAtvesz.Columns.Add("osszeg", "Összeg");
                dgwAtvesz.Columns.Add("penznem", "Pénznem");
                dgwAtvesz.Columns.Add("arfolyam", "Árfolyam");
                dgwAtvesz.Columns.Add("sorsz", "Sorszám");
                dgwAtvesz.Columns.Add("datum", "Dátum");

            }
            
                dgwAtvesz.Rows.Clear();
            foreach (Mozgas item in mLista)
            {
                dgwAtvesz.Rows.Add(item.MasikPenztar,item.Osszeg, item.Tipus, item.Arfolyam, item.Sorszam, item.Datum);
            }
            
        }

        private void radioBevetel_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void radioKiad_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string valuta="";
            bool vanpenz = true;
            switch (comboValuta.SelectedIndex)
            {
                case 0:
                    valuta = "HUF";
                    if (Egyenlegek.Forint - Convert.ToInt32
                    (txtOsszeg.Text)>=0)
                    {
                        Egyenlegek.Forint = Egyenlegek.Forint - Convert.ToInt32
                        (txtOsszeg.Text);
                        ABKezelo.EgyenlegModosit(Egyenlegek.Forint, "huf");
                    }
                    else
                    {
                        vanpenz = false;
                    }
                   
                   
                    break;
                case 1:
                    valuta = "EUR";
                    if (Egyenlegek.Eur - Convert.ToInt32(txtOsszeg.Text)>=0)
                    {
                        Egyenlegek.Eur = Egyenlegek.Eur - Convert.ToInt32(txtOsszeg.Text);
                        ABKezelo.EgyenlegModosit(Egyenlegek.Eur, "eur");
                    }
                    else
                    {
                        vanpenz = false;
                    }
                    break;
                case 2:
                    valuta = "USD";
                    if (Egyenlegek.Usd - Convert.ToInt32(txtOsszeg.Text)>=0)
                    {
                        Egyenlegek.Usd = Egyenlegek.Usd - Convert.ToInt32(txtOsszeg.Text);
                        ABKezelo.EgyenlegModosit(Egyenlegek.Usd, "usd");
                    }
                    else
                    {
                        vanpenz = false;
                    }

                    break;
                default:
                    break;
            }

            if (vanpenz)
            {
                ABKezelo.PenztarmozgasSorszamGeneral(ref hanykiad, ref hanybevet);

                jelenlegiSorszam = "VK" + Penztar.PenztarSorszam + "-" + hanykiad.ToString("000") + "/" + DateTime.Now.ToShortDateString();
                this.Text = jelenlegiSorszam;

                m = new Mozgas((comboPenztar.SelectedIndex + 1), valuta, Convert.ToDouble(txtArf.Text), jelenlegiSorszam, DateTime.Now, true, txtMegjegyzes.Text, Convert.ToInt32(txtOsszeg.Text));

                ABKezelo.PenztarMozgasHozzaas(m);

                Nyomtatas ujSzamla = new Nyomtatas(m);
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 830, 1170);
                pd.PrintPage += ujSzamla.KiadasNyomtat;
                pd.Print();
                MessageBox.Show("Sikeres tranzakció");
            }
            else
            {
                MessageBox.Show("Nincs elég pénz a készleten!");
            }
           
        }

        private void btnAtvisz_Click(object sender, EventArgs e)
        {
            switch (comboValuta.SelectedIndex)
            {
                case 0:
                    txtArf.Text = "0";
                    break;
                case 1:
                    txtArf.Text = lblEUR.Text;
                    break;
                case 2:
                    txtArf.Text = lblUSD.Text;
                    break;
                default:
                    break;
            }
        }

        private void btnFrissit_Click(object sender, EventArgs e)
        {
            dgwAtveszFeltolt();
        }

        private void btnAtvesz_Click(object sender, EventArgs e)
        {
            try
            {
                ABKezelo.PenztarmozgasSorszamGeneral(ref hanykiad, ref hanybevet);
                jelenlegiSorszam = "VB" + Penztar.PenztarSorszam + "-" + hanybevet.ToString("000") + "/" + DateTime.Now.ToShortDateString();
                this.Text = jelenlegiSorszam;
                Mozgas atmeneti = null;
                if (dgwAtvesz.SelectedRows.Count == 1)
                {
                    string kivettSorszam = dgwAtvesz.SelectedRows[0].Cells[4].FormattedValue.ToString();
                    atmeneti = mLista.Where(x => x.Sorszam == kivettSorszam).ToList()[0];
                }
                ABKezelo.AtvenniValoTorol(atmeneti);
                switch (atmeneti.Tipus)
                {
                    case "HUF":
                        Egyenlegek.Forint = Egyenlegek.Forint + atmeneti.Osszeg;
                        ABKezelo.EgyenlegModosit(Egyenlegek.Forint, "huf");
                        break;
                    case "EUR":
                        Egyenlegek.Eur = Egyenlegek.Eur + atmeneti.Osszeg;
                        ABKezelo.EgyenlegModosit(Egyenlegek.Eur, "eur");
                        break;
                    case "USD":
                        Egyenlegek.Usd = Egyenlegek.Usd + atmeneti.Osszeg;
                        ABKezelo.EgyenlegModosit(Egyenlegek.Usd, "usd");
                        break;
                }
                dgwAtveszFeltolt();
            }
            catch (Exception)
            {

                MessageBox.Show("Nincs átvehető tétel!");
            }
           
        }

       

        private void btnMegjegyzes_Click(object sender, EventArgs e)
        {
            if (dgwAtvesz.SelectedRows.Count == 1)
            {
                try
                {
                    int hanyadik = dgwAtvesz.SelectedRows[0].Index;
                    string megjegyzes = mLista[hanyadik].Megjegyzes;
                    Megjegyzes diag = new Megjegyzes(this.Left, megjegyzes);
                    diag.ShowDialog();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Nincs megjeleníthető megjegyzés");
                }

            }
        }

        private void dgwAtvesz_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
