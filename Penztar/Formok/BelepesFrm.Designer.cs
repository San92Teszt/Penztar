
using System;

namespace Penztar
{
    partial class BelepesFrm
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
            this.txtFelh = new System.Windows.Forms.TextBox();
            this.txtJel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBelep = new System.Windows.Forms.Button();
            this.btnKilep = new System.Windows.Forms.Button();
            this.menuKonfig = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuBeallit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKonfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFelh
            // 
            this.txtFelh.Location = new System.Drawing.Point(104, 34);
            this.txtFelh.Name = "txtFelh";
            this.txtFelh.Size = new System.Drawing.Size(125, 27);
            this.txtFelh.TabIndex = 0;
            // 
            // txtJel
            // 
            this.txtJel.Location = new System.Drawing.Point(104, 70);
            this.txtJel.Name = "txtJel";
            this.txtJel.PasswordChar = 'X';
            this.txtJel.Size = new System.Drawing.Size(125, 27);
            this.txtJel.TabIndex = 1;
            this.txtJel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJel_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Felhasználó";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jelszó";
            // 
            // btnBelep
            // 
            this.btnBelep.Location = new System.Drawing.Point(12, 113);
            this.btnBelep.Name = "btnBelep";
            this.btnBelep.Size = new System.Drawing.Size(94, 29);
            this.btnBelep.TabIndex = 4;
            this.btnBelep.Text = "Belépés";
            this.btnBelep.UseVisualStyleBackColor = true;
            this.btnBelep.Click += new System.EventHandler(this.btnBelep_Click);
            // 
            // btnKilep
            // 
            this.btnKilep.Location = new System.Drawing.Point(135, 113);
            this.btnKilep.Name = "btnKilep";
            this.btnKilep.Size = new System.Drawing.Size(94, 29);
            this.btnKilep.TabIndex = 5;
            this.btnKilep.Text = "Kilépés";
            this.btnKilep.UseVisualStyleBackColor = true;
            this.btnKilep.Click += new System.EventHandler(this.btnKilep_Click);
            // 
            // menuKonfig
            // 
            this.menuKonfig.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuKonfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuBeallit});
            this.menuKonfig.Location = new System.Drawing.Point(0, 0);
            this.menuKonfig.Name = "menuKonfig";
            this.menuKonfig.Size = new System.Drawing.Size(249, 28);
            this.menuKonfig.TabIndex = 6;
            this.menuKonfig.Text = "Beállítások";
            this.menuKonfig.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuKonfig_ItemClicked);
            // 
            // toolStripMenuBeallit
            // 
            this.toolStripMenuBeallit.Name = "toolStripMenuBeallit";
            this.toolStripMenuBeallit.Size = new System.Drawing.Size(95, 24);
            this.toolStripMenuBeallit.Text = "Beállítások";
            this.toolStripMenuBeallit.Click += toolStripMenuBeallit_Click;
            // 
            // BelepesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 158);
            this.Controls.Add(this.btnKilep);
            this.Controls.Add(this.btnBelep);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJel);
            this.Controls.Add(this.txtFelh);
            this.Controls.Add(this.menuKonfig);
            this.MainMenuStrip = this.menuKonfig;
            this.Name = "BelepesFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Belepes";
            this.Load += new System.EventHandler(this.Belepes_Load);
            this.menuKonfig.ResumeLayout(false);
            this.menuKonfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       



        #endregion

        private System.Windows.Forms.TextBox txtFelh;
        private System.Windows.Forms.TextBox txtJel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBelep;
        private System.Windows.Forms.Button btnKilep;
        private System.Windows.Forms.MenuStrip menuKonfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuBeallit;
    }
}