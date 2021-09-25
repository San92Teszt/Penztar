using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Penztar
{
    public partial class PenztarBeallitFrm : Form
    {
        public PenztarBeallitFrm()
        {
            InitializeComponent();
        }

        private void PenztarBeallitFrm_Load(object sender, EventArgs e)
        {
            txtAdoszam.Text = Penztar.Adoszam;
            txtCegjegyzek.Text = Penztar.Cegjegyzek;
            txtCegnev.Text = Penztar.Cegnev;
            txtPenztarCim.Text = Penztar.Cim;
            txtPenztarRovidnev.Text = Penztar.Rovidnev;
            txtSsz.Text = Penztar.PenztarSorszam.ToString();
            txtBanknev.Text = Penztar.BankNeve;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Fajlkezelo.PenztarAdatMent(txtSsz.Text, txtPenztarCim.Text, txtPenztarRovidnev.Text, txtCegnev.Text, txtCegjegyzek.Text, txtAdoszam.Text,txtBanknev.Text);
            Fajlkezelo.PenztarAdatbetolt();
        }
    }
}
