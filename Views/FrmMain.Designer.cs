namespace MVCWinFormsMasterDetail
{
    partial class FrmMain
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
            this.btnGrupyPracownicze = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGrupyPracownicze
            // 
            this.btnGrupyPracownicze.Location = new System.Drawing.Point(12, 12);
            this.btnGrupyPracownicze.Name = "btnGrupyPracownicze";
            this.btnGrupyPracownicze.Size = new System.Drawing.Size(250, 63);
            this.btnGrupyPracownicze.TabIndex = 0;
            this.btnGrupyPracownicze.Text = "Grupy Pracownicze";
            this.btnGrupyPracownicze.UseVisualStyleBackColor = true;
            this.btnGrupyPracownicze.Click += new System.EventHandler(this.btnGrupyPracownicze_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGrupyPracownicze);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGrupyPracownicze;
    }
}

