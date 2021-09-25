
namespace Penztar
{
    partial class RendszerkonfigFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSzerver = new System.Windows.Forms.TextBox();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.txtFelh = new System.Windows.Forms.TextBox();
            this.txtJel = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnMegse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Szerver";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adatbázis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Felhasználónév";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Jelszó";
            // 
            // txtSzerver
            // 
            this.txtSzerver.Location = new System.Drawing.Point(128, 21);
            this.txtSzerver.Name = "txtSzerver";
            this.txtSzerver.Size = new System.Drawing.Size(233, 27);
            this.txtSzerver.TabIndex = 4;
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(128, 52);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(233, 27);
            this.txtDB.TabIndex = 5;
            // 
            // txtFelh
            // 
            this.txtFelh.Location = new System.Drawing.Point(127, 85);
            this.txtFelh.Name = "txtFelh";
            this.txtFelh.Size = new System.Drawing.Size(233, 27);
            this.txtFelh.TabIndex = 6;
            // 
            // txtJel
            // 
            this.txtJel.Location = new System.Drawing.Point(128, 118);
            this.txtJel.Name = "txtJel";
            this.txtJel.Size = new System.Drawing.Size(233, 27);
            this.txtJel.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(127, 151);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 29);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "Mentés";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnMegse
            // 
            this.btnMegse.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMegse.Location = new System.Drawing.Point(266, 151);
            this.btnMegse.Name = "btnMegse";
            this.btnMegse.Size = new System.Drawing.Size(94, 29);
            this.btnMegse.TabIndex = 9;
            this.btnMegse.Text = "Mégse";
            this.btnMegse.UseVisualStyleBackColor = true;
            // 
            // RendszerkonfigFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.btnMegse);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtJel);
            this.Controls.Add(this.txtFelh);
            this.Controls.Add(this.txtDB);
            this.Controls.Add(this.txtSzerver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RendszerkonfigFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendszer beállításai";
            this.Load += new System.EventHandler(this.RendszerkonfigFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSzerver;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.TextBox txtFelh;
        private System.Windows.Forms.TextBox txtJel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnMegse;
    }
}