using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Penztar
{
    public partial class Megjegyzes : Form
    {
        public Megjegyzes(int bal, string szoveg)
        {
            InitializeComponent();
            this.Location = new Point(bal, 400);
            txtMegjegyzes.Text = szoveg;
        }

        private void Megjegyzes_Load(object sender, EventArgs e)
        {
            
        }
    }
}
