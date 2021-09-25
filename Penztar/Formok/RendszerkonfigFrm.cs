using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Penztar
{
    public partial class RendszerkonfigFrm : Form
    {
        public RendszerkonfigFrm()
        {
            InitializeComponent();
        }

        private void RendszerkonfigFrm_Load(object sender, EventArgs e)
        {
            txtDB.Text = Rendszerkonfig.Dbnev;
            txtFelh.Text = Rendszerkonfig.Felh;
            txtJel.Text = Rendszerkonfig.Jel;
            txtSzerver.Text = Rendszerkonfig.Ipcim;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Fajlkezelo.RenszerKonfigMent(txtSzerver.Text, txtDB.Text, txtFelh.Text, txtJel.Text);
            Fajlkezelo.RendszerKonfigBetolt();
            ABKezelo.Lezar();
            ABKezelo.UjraKonfig();
            ABKezelo.Megnyit();
        }
    }
}
