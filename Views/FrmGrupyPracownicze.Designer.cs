namespace MVCWinFormsMasterDetail
{
    partial class FrmGrupyPracownicze
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
            this.gbButtonsGrupyPracownicze = new System.Windows.Forms.GroupBox();
            this.btnRemoveGrupaPracownicza = new System.Windows.Forms.Button();
            this.btnEditGrupaPracownicza = new System.Windows.Forms.Button();
            this.btnAddGrupaPracownicza = new System.Windows.Forms.Button();
            this.gbEdit = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRemoveGrupaPracowniczaPozycja = new System.Windows.Forms.Button();
            this.btnEditGrupaPracowniczaPozycja = new System.Windows.Forms.Button();
            this.btnAddGrupaPracowniczaPozycja = new System.Windows.Forms.Button();
            this.lvPracownicy = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblIDGrupaPracownicza = new System.Windows.Forms.Label();
            this.tbIDGrupaPracownicza = new System.Windows.Forms.TextBox();
            this.tbNazwaGrupaPracownicza = new System.Windows.Forms.TextBox();
            this.lblNazwaGrupaPracownicza = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelGrupaPracownicza = new System.Windows.Forms.Button();
            this.btnSaveGrupaPracownicza = new System.Windows.Forms.Button();
            this.lvGrupyPracownicze = new System.Windows.Forms.ListView();
            this.gbButtonsGrupyPracownicze.SuspendLayout();
            this.gbEdit.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbButtonsGrupyPracownicze
            // 
            this.gbButtonsGrupyPracownicze.Controls.Add(this.btnRemoveGrupaPracownicza);
            this.gbButtonsGrupyPracownicze.Controls.Add(this.btnEditGrupaPracownicza);
            this.gbButtonsGrupyPracownicze.Controls.Add(this.btnAddGrupaPracownicza);
            this.gbButtonsGrupyPracownicze.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbButtonsGrupyPracownicze.Location = new System.Drawing.Point(0, 0);
            this.gbButtonsGrupyPracownicze.Name = "gbButtonsGrupyPracownicze";
            this.gbButtonsGrupyPracownicze.Size = new System.Drawing.Size(960, 60);
            this.gbButtonsGrupyPracownicze.TabIndex = 0;
            this.gbButtonsGrupyPracownicze.TabStop = false;
            // 
            // btnRemoveGrupaPracownicza
            // 
            this.btnRemoveGrupaPracownicza.Location = new System.Drawing.Point(264, 15);
            this.btnRemoveGrupaPracownicza.Name = "btnRemoveGrupaPracownicza";
            this.btnRemoveGrupaPracownicza.Size = new System.Drawing.Size(120, 30);
            this.btnRemoveGrupaPracownicza.TabIndex = 2;
            this.btnRemoveGrupaPracownicza.Text = "Remove";
            this.btnRemoveGrupaPracownicza.UseVisualStyleBackColor = true;
            this.btnRemoveGrupaPracownicza.Click += new System.EventHandler(this.btnRemoveGrupaPracownicza_Click);
            // 
            // btnEditGrupaPracownicza
            // 
            this.btnEditGrupaPracownicza.Location = new System.Drawing.Point(138, 15);
            this.btnEditGrupaPracownicza.Name = "btnEditGrupaPracownicza";
            this.btnEditGrupaPracownicza.Size = new System.Drawing.Size(120, 30);
            this.btnEditGrupaPracownicza.TabIndex = 1;
            this.btnEditGrupaPracownicza.Text = "Edit";
            this.btnEditGrupaPracownicza.UseVisualStyleBackColor = true;
            this.btnEditGrupaPracownicza.Click += new System.EventHandler(this.btnEditGrupaPracownicza_Click);
            // 
            // btnAddGrupaPracownicza
            // 
            this.btnAddGrupaPracownicza.Location = new System.Drawing.Point(12, 15);
            this.btnAddGrupaPracownicza.Name = "btnAddGrupaPracownicza";
            this.btnAddGrupaPracownicza.Size = new System.Drawing.Size(120, 30);
            this.btnAddGrupaPracownicza.TabIndex = 0;
            this.btnAddGrupaPracownicza.Text = "Add";
            this.btnAddGrupaPracownicza.UseVisualStyleBackColor = true;
            this.btnAddGrupaPracownicza.Click += new System.EventHandler(this.btnAddGrupaPracownicza_Click);
            // 
            // gbEdit
            // 
            this.gbEdit.Controls.Add(this.panel3);
            this.gbEdit.Controls.Add(this.lvPracownicy);
            this.gbEdit.Controls.Add(this.panel1);
            this.gbEdit.Controls.Add(this.panel2);
            this.gbEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbEdit.Location = new System.Drawing.Point(0, 60);
            this.gbEdit.Name = "gbEdit";
            this.gbEdit.Size = new System.Drawing.Size(960, 255);
            this.gbEdit.TabIndex = 1;
            this.gbEdit.TabStop = false;
            this.gbEdit.Text = "Edit:";
            this.gbEdit.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRemoveGrupaPracowniczaPozycja);
            this.panel3.Controls.Add(this.btnEditGrupaPracowniczaPozycja);
            this.panel3.Controls.Add(this.btnAddGrupaPracowniczaPozycja);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 172);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(954, 39);
            this.panel3.TabIndex = 7;
            // 
            // btnRemoveGrupaPracowniczaPozycja
            // 
            this.btnRemoveGrupaPracowniczaPozycja.Location = new System.Drawing.Point(201, 6);
            this.btnRemoveGrupaPracowniczaPozycja.Name = "btnRemoveGrupaPracowniczaPozycja";
            this.btnRemoveGrupaPracowniczaPozycja.Size = new System.Drawing.Size(90, 22);
            this.btnRemoveGrupaPracowniczaPozycja.TabIndex = 5;
            this.btnRemoveGrupaPracowniczaPozycja.Text = "Remove";
            this.btnRemoveGrupaPracowniczaPozycja.UseVisualStyleBackColor = true;
            this.btnRemoveGrupaPracowniczaPozycja.Click += new System.EventHandler(this.btnRemoveGrupaPracowniczaPozycja_Click);
            // 
            // btnEditGrupaPracowniczaPozycja
            // 
            this.btnEditGrupaPracowniczaPozycja.Location = new System.Drawing.Point(105, 6);
            this.btnEditGrupaPracowniczaPozycja.Name = "btnEditGrupaPracowniczaPozycja";
            this.btnEditGrupaPracowniczaPozycja.Size = new System.Drawing.Size(90, 22);
            this.btnEditGrupaPracowniczaPozycja.TabIndex = 4;
            this.btnEditGrupaPracowniczaPozycja.Text = "Edit";
            this.btnEditGrupaPracowniczaPozycja.UseVisualStyleBackColor = true;
            this.btnEditGrupaPracowniczaPozycja.Click += new System.EventHandler(this.btnEditGrupaPracowniczaPozycja_Click);
            // 
            // btnAddGrupaPracowniczaPozycja
            // 
            this.btnAddGrupaPracowniczaPozycja.Location = new System.Drawing.Point(9, 6);
            this.btnAddGrupaPracowniczaPozycja.Name = "btnAddGrupaPracowniczaPozycja";
            this.btnAddGrupaPracowniczaPozycja.Size = new System.Drawing.Size(90, 22);
            this.btnAddGrupaPracowniczaPozycja.TabIndex = 3;
            this.btnAddGrupaPracowniczaPozycja.Text = "Add";
            this.btnAddGrupaPracowniczaPozycja.UseVisualStyleBackColor = true;
            this.btnAddGrupaPracowniczaPozycja.Click += new System.EventHandler(this.btnAddGrupaPracowniczaPozycja_Click);
            // 
            // lvPracownicy
            // 
            this.lvPracownicy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPracownicy.FullRowSelect = true;
            this.lvPracownicy.GridLines = true;
            this.lvPracownicy.HideSelection = false;
            this.lvPracownicy.Location = new System.Drawing.Point(3, 89);
            this.lvPracownicy.Name = "lvPracownicy";
            this.lvPracownicy.Size = new System.Drawing.Size(954, 122);
            this.lvPracownicy.TabIndex = 4;
            this.lvPracownicy.UseCompatibleStateImageBehavior = false;
            this.lvPracownicy.View = System.Windows.Forms.View.Details;
            
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblIDGrupaPracownicza);
            this.panel1.Controls.Add(this.tbIDGrupaPracownicza);
            this.panel1.Controls.Add(this.tbNazwaGrupaPracownicza);
            this.panel1.Controls.Add(this.lblNazwaGrupaPracownicza);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 73);
            this.panel1.TabIndex = 5;
            // 
            // lblIDGrupaPracownicza
            // 
            this.lblIDGrupaPracownicza.AutoSize = true;
            this.lblIDGrupaPracownicza.Location = new System.Drawing.Point(16, 20);
            this.lblIDGrupaPracownicza.Name = "lblIDGrupaPracownicza";
            this.lblIDGrupaPracownicza.Size = new System.Drawing.Size(21, 13);
            this.lblIDGrupaPracownicza.TabIndex = 0;
            this.lblIDGrupaPracownicza.Text = "ID:";
            // 
            // tbIDGrupaPracownicza
            // 
            this.tbIDGrupaPracownicza.Location = new System.Drawing.Point(65, 17);
            this.tbIDGrupaPracownicza.Name = "tbIDGrupaPracownicza";
            this.tbIDGrupaPracownicza.Size = new System.Drawing.Size(137, 20);
            this.tbIDGrupaPracownicza.TabIndex = 1;
            // 
            // tbNazwaGrupaPracownicza
            // 
            this.tbNazwaGrupaPracownicza.Location = new System.Drawing.Point(65, 43);
            this.tbNazwaGrupaPracownicza.Name = "tbNazwaGrupaPracownicza";
            this.tbNazwaGrupaPracownicza.Size = new System.Drawing.Size(137, 20);
            this.tbNazwaGrupaPracownicza.TabIndex = 3;
            // 
            // lblNazwaGrupaPracownicza
            // 
            this.lblNazwaGrupaPracownicza.AutoSize = true;
            this.lblNazwaGrupaPracownicza.Location = new System.Drawing.Point(16, 46);
            this.lblNazwaGrupaPracownicza.Name = "lblNazwaGrupaPracownicza";
            this.lblNazwaGrupaPracownicza.Size = new System.Drawing.Size(43, 13);
            this.lblNazwaGrupaPracownicza.TabIndex = 2;
            this.lblNazwaGrupaPracownicza.Text = "Nazwa:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancelGrupaPracownicza);
            this.panel2.Controls.Add(this.btnSaveGrupaPracownicza);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 211);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(954, 41);
            this.panel2.TabIndex = 6;
            // 
            // btnCancelGrupaPracownicza
            // 
            this.btnCancelGrupaPracownicza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelGrupaPracownicza.Location = new System.Drawing.Point(825, 6);
            this.btnCancelGrupaPracownicza.Name = "btnCancelGrupaPracownicza";
            this.btnCancelGrupaPracownicza.Size = new System.Drawing.Size(120, 30);
            this.btnCancelGrupaPracownicza.TabIndex = 2;
            this.btnCancelGrupaPracownicza.Text = "Cancel";
            this.btnCancelGrupaPracownicza.UseVisualStyleBackColor = true;
            this.btnCancelGrupaPracownicza.Click += new System.EventHandler(this.btnCancelGrupaPracownicza_Click);
            // 
            // btnSaveGrupaPracownicza
            // 
            this.btnSaveGrupaPracownicza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveGrupaPracownicza.Location = new System.Drawing.Point(699, 6);
            this.btnSaveGrupaPracownicza.Name = "btnSaveGrupaPracownicza";
            this.btnSaveGrupaPracownicza.Size = new System.Drawing.Size(120, 30);
            this.btnSaveGrupaPracownicza.TabIndex = 1;
            this.btnSaveGrupaPracownicza.Text = "Save";
            this.btnSaveGrupaPracownicza.UseVisualStyleBackColor = true;
            this.btnSaveGrupaPracownicza.Click += new System.EventHandler(this.btnSaveGrupaPracownicza_Click);
            // 
            // lvGrupyPracownicze
            // 
            this.lvGrupyPracownicze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGrupyPracownicze.FullRowSelect = true;
            this.lvGrupyPracownicze.GridLines = true;
            this.lvGrupyPracownicze.HideSelection = false;
            this.lvGrupyPracownicze.Location = new System.Drawing.Point(0, 315);
            this.lvGrupyPracownicze.Name = "lvGrupyPracownicze";
            this.lvGrupyPracownicze.Size = new System.Drawing.Size(960, 323);
            this.lvGrupyPracownicze.TabIndex = 2;
            this.lvGrupyPracownicze.UseCompatibleStateImageBehavior = false;
            this.lvGrupyPracownicze.View = System.Windows.Forms.View.Details;
            this.lvGrupyPracownicze.SelectedIndexChanged += new System.EventHandler(this.lvGrupyPracownicze_SelectedIndexChanged);
            // 
            // FrmGrupyPracownicze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 638);
            this.Controls.Add(this.lvGrupyPracownicze);
            this.Controls.Add(this.gbEdit);
            this.Controls.Add(this.gbButtonsGrupyPracownicze);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "FrmGrupyPracownicze";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupy Pracownicze";
            this.gbButtonsGrupyPracownicze.ResumeLayout(false);
            this.gbEdit.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbButtonsGrupyPracownicze;
        private System.Windows.Forms.Button btnAddGrupaPracownicza;
        private System.Windows.Forms.Button btnEditGrupaPracownicza;
        private System.Windows.Forms.Button btnRemoveGrupaPracownicza;
        private System.Windows.Forms.GroupBox gbEdit;
        private System.Windows.Forms.ListView lvGrupyPracownicze;
        private System.Windows.Forms.ListView lvPracownicy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblIDGrupaPracownicza;
        private System.Windows.Forms.TextBox tbIDGrupaPracownicza;
        private System.Windows.Forms.TextBox tbNazwaGrupaPracownicza;
        private System.Windows.Forms.Label lblNazwaGrupaPracownicza;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelGrupaPracownicza;
        private System.Windows.Forms.Button btnSaveGrupaPracownicza;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRemoveGrupaPracowniczaPozycja;
        private System.Windows.Forms.Button btnEditGrupaPracowniczaPozycja;
        private System.Windows.Forms.Button btnAddGrupaPracowniczaPozycja;
    }
}