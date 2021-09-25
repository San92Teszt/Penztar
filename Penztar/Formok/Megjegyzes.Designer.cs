
namespace Penztar
{
    partial class Megjegyzes
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
            this.txtMegjegyzes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMegjegyzes
            // 
            this.txtMegjegyzes.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.txtMegjegyzes.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMegjegyzes.Location = new System.Drawing.Point(12, 12);
            this.txtMegjegyzes.Multiline = true;
            this.txtMegjegyzes.Name = "txtMegjegyzes";
            this.txtMegjegyzes.ReadOnly = true;
            this.txtMegjegyzes.Size = new System.Drawing.Size(463, 191);
            this.txtMegjegyzes.TabIndex = 0;
            // 
            // Megjegyzes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(487, 215);
            this.Controls.Add(this.txtMegjegyzes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Megjegyzes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Megjegyzes";
            this.Load += new System.EventHandler(this.Megjegyzes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMegjegyzes;
    }
}