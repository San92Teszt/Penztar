
namespace Penztar
{
    partial class KiadasBevetelFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KiadasBevetelFrm));
            this.tableKozeparf = new System.Windows.Forms.TableLayoutPanel();
            this.lblUSD = new System.Windows.Forms.Label();
            this.lblEUR = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboValuta = new System.Windows.Forms.ComboBox();
            this.comboPenztar = new System.Windows.Forms.ComboBox();
            this.txtOsszeg = new System.Windows.Forms.TextBox();
            this.txtArf = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnMegse = new System.Windows.Forms.Button();
            this.btnAtvisz = new System.Windows.Forms.Button();
            this.dgwAtvesz = new System.Windows.Forms.DataGridView();
            this.btnAtvesz = new System.Windows.Forms.Button();
            this.txtMegjegyzes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFrissit = new System.Windows.Forms.Button();
            this.groupBevesz = new System.Windows.Forms.GroupBox();
            this.btnMegjegyzes = new System.Windows.Forms.Button();
            this.groupKiad = new System.Windows.Forms.GroupBox();
            this.notifyMegjegyzes = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableKozeparf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAtvesz)).BeginInit();
            this.groupBevesz.SuspendLayout();
            this.groupKiad.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableKozeparf
            // 
            this.tableKozeparf.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableKozeparf.ColumnCount = 2;
            this.tableKozeparf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableKozeparf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableKozeparf.Controls.Add(this.lblUSD, 1, 1);
            this.tableKozeparf.Controls.Add(this.lblEUR, 0, 1);
            this.tableKozeparf.Controls.Add(this.label1, 0, 0);
            this.tableKozeparf.Controls.Add(this.label2, 1, 0);
            this.tableKozeparf.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableKozeparf.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.tableKozeparf.Location = new System.Drawing.Point(263, 70);
            this.tableKozeparf.Name = "tableKozeparf";
            this.tableKozeparf.RowCount = 2;
            this.tableKozeparf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableKozeparf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableKozeparf.Size = new System.Drawing.Size(161, 71);
            this.tableKozeparf.TabIndex = 0;
            // 
            // lblUSD
            // 
            this.lblUSD.AutoSize = true;
            this.lblUSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUSD.Location = new System.Drawing.Point(84, 36);
            this.lblUSD.Name = "lblUSD";
            this.lblUSD.Size = new System.Drawing.Size(18, 20);
            this.lblUSD.TabIndex = 4;
            this.lblUSD.Text = "0";
            // 
            // lblEUR
            // 
            this.lblEUR.AutoSize = true;
            this.lblEUR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEUR.Location = new System.Drawing.Point(4, 36);
            this.lblEUR.Name = "lblEUR";
            this.lblEUR.Size = new System.Drawing.Size(18, 20);
            this.lblEUR.TabIndex = 3;
            this.lblEUR.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "EUR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(84, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "USD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Valutanem";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pénztár";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Összeg";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Árfolyam";
            // 
            // comboValuta
            // 
            this.comboValuta.FormattingEnabled = true;
            this.comboValuta.Items.AddRange(new object[] {
            "HUF",
            "EUR",
            "USD"});
            this.comboValuta.Location = new System.Drawing.Point(106, 36);
            this.comboValuta.Name = "comboValuta";
            this.comboValuta.Size = new System.Drawing.Size(151, 28);
            this.comboValuta.TabIndex = 7;
            // 
            // comboPenztar
            // 
            this.comboPenztar.FormattingEnabled = true;
            this.comboPenztar.Location = new System.Drawing.Point(106, 79);
            this.comboPenztar.Name = "comboPenztar";
            this.comboPenztar.Size = new System.Drawing.Size(151, 28);
            this.comboPenztar.TabIndex = 8;
            // 
            // txtOsszeg
            // 
            this.txtOsszeg.Location = new System.Drawing.Point(106, 124);
            this.txtOsszeg.Name = "txtOsszeg";
            this.txtOsszeg.Size = new System.Drawing.Size(151, 27);
            this.txtOsszeg.TabIndex = 9;
            // 
            // txtArf
            // 
            this.txtArf.Location = new System.Drawing.Point(106, 171);
            this.txtArf.Name = "txtArf";
            this.txtArf.Size = new System.Drawing.Size(151, 27);
            this.txtArf.TabIndex = 10;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(22, 315);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 29);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "Kiadás";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnMegse
            // 
            this.btnMegse.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMegse.Location = new System.Drawing.Point(131, 315);
            this.btnMegse.Name = "btnMegse";
            this.btnMegse.Size = new System.Drawing.Size(94, 29);
            this.btnMegse.TabIndex = 12;
            this.btnMegse.Text = "Mégse";
            this.btnMegse.UseVisualStyleBackColor = true;
            // 
            // btnAtvisz
            // 
            this.btnAtvisz.Location = new System.Drawing.Point(266, 147);
            this.btnAtvisz.Name = "btnAtvisz";
            this.btnAtvisz.Size = new System.Drawing.Size(161, 51);
            this.btnAtvisz.TabIndex = 13;
            this.btnAtvisz.Text = "Árfolyam másolása\r\n<---";
            this.btnAtvisz.UseVisualStyleBackColor = true;
            this.btnAtvisz.Click += new System.EventHandler(this.btnAtvisz_Click);
            // 
            // dgwAtvesz
            // 
            this.dgwAtvesz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwAtvesz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwAtvesz.Location = new System.Drawing.Point(15, 26);
            this.dgwAtvesz.Name = "dgwAtvesz";
            this.dgwAtvesz.RowHeadersWidth = 51;
            this.dgwAtvesz.RowTemplate.Height = 29;
            this.dgwAtvesz.Size = new System.Drawing.Size(655, 288);
            this.dgwAtvesz.TabIndex = 14;
            this.dgwAtvesz.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwAtvesz_CellContentClick);
            // 
            // btnAtvesz
            // 
            this.btnAtvesz.Location = new System.Drawing.Point(15, 323);
            this.btnAtvesz.Name = "btnAtvesz";
            this.btnAtvesz.Size = new System.Drawing.Size(476, 36);
            this.btnAtvesz.TabIndex = 15;
            this.btnAtvesz.Text = "Kijelölt tétel átvétele";
            this.btnAtvesz.UseVisualStyleBackColor = true;
            this.btnAtvesz.Click += new System.EventHandler(this.btnAtvesz_Click);
            // 
            // txtMegjegyzes
            // 
            this.txtMegjegyzes.Location = new System.Drawing.Point(19, 236);
            this.txtMegjegyzes.Multiline = true;
            this.txtMegjegyzes.Name = "txtMegjegyzes";
            this.txtMegjegyzes.Size = new System.Drawing.Size(405, 73);
            this.txtMegjegyzes.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Megjegyzés";
            // 
            // btnFrissit
            // 
            this.btnFrissit.Location = new System.Drawing.Point(497, 323);
            this.btnFrissit.Name = "btnFrissit";
            this.btnFrissit.Size = new System.Drawing.Size(113, 36);
            this.btnFrissit.TabIndex = 18;
            this.btnFrissit.Text = "Frissít";
            this.btnFrissit.UseVisualStyleBackColor = true;
            this.btnFrissit.Click += new System.EventHandler(this.btnFrissit_Click);
            // 
            // groupBevesz
            // 
            this.groupBevesz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBevesz.Controls.Add(this.btnMegjegyzes);
            this.groupBevesz.Controls.Add(this.dgwAtvesz);
            this.groupBevesz.Controls.Add(this.btnFrissit);
            this.groupBevesz.Controls.Add(this.btnAtvesz);
            this.groupBevesz.Location = new System.Drawing.Point(460, 12);
            this.groupBevesz.Name = "groupBevesz";
            this.groupBevesz.Size = new System.Drawing.Size(690, 368);
            this.groupBevesz.TabIndex = 19;
            this.groupBevesz.TabStop = false;
            this.groupBevesz.Text = "Bevételezés";
            // 
            // btnMegjegyzes
            // 
            this.btnMegjegyzes.Image = ((System.Drawing.Image)(resources.GetObject("btnMegjegyzes.Image")));
            this.btnMegjegyzes.Location = new System.Drawing.Point(632, 320);
            this.btnMegjegyzes.Name = "btnMegjegyzes";
            this.btnMegjegyzes.Size = new System.Drawing.Size(38, 39);
            this.btnMegjegyzes.TabIndex = 19;
            this.btnMegjegyzes.Tag = "Megjegyzés megtekintése";
            this.btnMegjegyzes.UseVisualStyleBackColor = true;
            this.btnMegjegyzes.Click += new System.EventHandler(this.btnMegjegyzes_Click);
            // 
            // groupKiad
            // 
            this.groupKiad.Controls.Add(this.comboValuta);
            this.groupKiad.Controls.Add(this.tableKozeparf);
            this.groupKiad.Controls.Add(this.label7);
            this.groupKiad.Controls.Add(this.label3);
            this.groupKiad.Controls.Add(this.txtMegjegyzes);
            this.groupKiad.Controls.Add(this.label4);
            this.groupKiad.Controls.Add(this.btnAtvisz);
            this.groupKiad.Controls.Add(this.label5);
            this.groupKiad.Controls.Add(this.btnMegse);
            this.groupKiad.Controls.Add(this.label6);
            this.groupKiad.Controls.Add(this.btnOK);
            this.groupKiad.Controls.Add(this.comboPenztar);
            this.groupKiad.Controls.Add(this.txtArf);
            this.groupKiad.Controls.Add(this.txtOsszeg);
            this.groupKiad.Location = new System.Drawing.Point(4, 12);
            this.groupKiad.Name = "groupKiad";
            this.groupKiad.Size = new System.Drawing.Size(450, 368);
            this.groupKiad.TabIndex = 20;
            this.groupKiad.TabStop = false;
            this.groupKiad.Text = "Kiadás";
            // 
            // notifyMegjegyzes
            // 
            this.notifyMegjegyzes.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyMegjegyzes.Text = "notifyIcon1";
            this.notifyMegjegyzes.Visible = true;
            // 
            // KiadasBevetelFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 397);
            this.Controls.Add(this.groupKiad);
            this.Controls.Add(this.groupBevesz);
            this.Name = "KiadasBevetelFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KiadasBevetelFrm";
            this.Load += new System.EventHandler(this.KiadasBevetelFrm_Load);
            this.tableKozeparf.ResumeLayout(false);
            this.tableKozeparf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAtvesz)).EndInit();
            this.groupBevesz.ResumeLayout(false);
            this.groupKiad.ResumeLayout(false);
            this.groupKiad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableKozeparf;
        private System.Windows.Forms.Label lblUSD;
        private System.Windows.Forms.Label lblEUR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboValuta;
        private System.Windows.Forms.ComboBox comboPenztar;
        private System.Windows.Forms.TextBox txtOsszeg;
        private System.Windows.Forms.TextBox txtArf;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnMegse;
        private System.Windows.Forms.Button btnAtvisz;
        private System.Windows.Forms.DataGridView dgwAtvesz;
        private System.Windows.Forms.Button btnAtvesz;
        private System.Windows.Forms.TextBox txtMegjegyzes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFrissit;
        private System.Windows.Forms.GroupBox groupBevesz;
        private System.Windows.Forms.GroupBox groupKiad;
        private System.Windows.Forms.NotifyIcon notifyMegjegyzes;
        private System.Windows.Forms.Button btnMegjegyzes;
    }
}