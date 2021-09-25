using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Penztar
{
    public partial class BelepesFrm : Form
    {
        public BelepesFrm()
        {
            InitializeComponent();
            Fajlkezelo.RendszerKonfigBetolt();
        }

        private void Belepes_Load(object sender, EventArgs e)
        {

        }
        private void toolStripMenuBeallit_Click(object sender, EventArgs e)
        {
            RendszerkonfigFrm diag = new RendszerkonfigFrm();
            diag.ShowDialog();
        }
        private void btnBelep_Click(object sender, EventArgs e)
        {
            try
            {
                bool admin = false;
                bool belep = ABKezelo.Belepes(txtFelh.Text, txtJel.Text,ref admin);
                if (belep == true)
                {                
                    
                    FomenuFrm diag = new FomenuFrm(admin);
                    diag.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Hibás felhasználónév vagy jelszó");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Adatbázis hiba!");
            }
           
        }
        private void Megnyit(object sender, EventArgs e)
        {
            RendszerkonfigFrm diag = new RendszerkonfigFrm();
            diag.ShowDialog();
        }

        private void btnKilep_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuKonfig_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtJel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btnBelep_Click(sender, e);
            }
        }
    }
}
