namespace MediaTek86.vue
{
    partial class FrmAbsence
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstAbsences = new System.Windows.Forms.ListBox();
            this.dtpDebut = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.cboMotif = new System.Windows.Forms.ComboBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.lblDebut = new System.Windows.Forms.Label();
            this.lblFin = new System.Windows.Forms.Label();
            this.lblMotif = new System.Windows.Forms.Label();
            this.lblListe = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lstAbsences
            this.lstAbsences.FormattingEnabled = true;
            this.lstAbsences.Location = new System.Drawing.Point(12, 45);
            this.lstAbsences.Name = "lstAbsences";
            this.lstAbsences.Size = new System.Drawing.Size(380, 200);
            this.lstAbsences.TabIndex = 0;
            this.lstAbsences.SelectedIndexChanged += new System.EventHandler(this.lstAbsences_SelectedIndexChanged);

            // lblListe
            this.lblListe.AutoSize = true;
            this.lblListe.Location = new System.Drawing.Point(12, 25);
            this.lblListe.Name = "lblListe";
            this.lblListe.Size = new System.Drawing.Size(130, 13);
            this.lblListe.Text = "Liste des absences :";

            // lblDebut
            this.lblDebut.AutoSize = true;
            this.lblDebut.Location = new System.Drawing.Point(12, 265);
            this.lblDebut.Name = "lblDebut";
            this.lblDebut.Text = "Date de début :";

            // dtpDebut
            this.dtpDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDebut.Location = new System.Drawing.Point(120, 260);
            this.dtpDebut.Name = "dtpDebut";
            this.dtpDebut.Size = new System.Drawing.Size(150, 20);
            this.dtpDebut.TabIndex = 1;

            // lblFin
            this.lblFin.AutoSize = true;
            this.lblFin.Location = new System.Drawing.Point(12, 300);
            this.lblFin.Name = "lblFin";
            this.lblFin.Text = "Date de fin :";

            // dtpFin
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(120, 295);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(150, 20);
            this.dtpFin.TabIndex = 2;

            // lblMotif
            this.lblMotif.AutoSize = true;
            this.lblMotif.Location = new System.Drawing.Point(12, 335);
            this.lblMotif.Name = "lblMotif";
            this.lblMotif.Text = "Motif :";

            // cboMotif
            this.cboMotif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotif.FormattingEnabled = true;
            this.cboMotif.Location = new System.Drawing.Point(120, 330);
            this.cboMotif.Name = "cboMotif";
            this.cboMotif.Size = new System.Drawing.Size(200, 21);
            this.cboMotif.TabIndex = 3;

            // btnAjouter
            this.btnAjouter.Location = new System.Drawing.Point(12, 375);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(80, 30);
            this.btnAjouter.TabIndex = 4;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);

            // btnModifier
            this.btnModifier.Location = new System.Drawing.Point(100, 375);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(80, 30);
            this.btnModifier.TabIndex = 5;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);

            // btnSupprimer
            this.btnSupprimer.Location = new System.Drawing.Point(188, 375);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(80, 30);
            this.btnSupprimer.TabIndex = 6;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);

            // btnAnnuler
            this.btnAnnuler.Location = new System.Drawing.Point(276, 375);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(80, 30);
            this.btnAnnuler.TabIndex = 7;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);

            // FrmAbsence
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 430);
            this.Controls.Add(this.lstAbsences);
            this.Controls.Add(this.lblListe);
            this.Controls.Add(this.lblDebut);
            this.Controls.Add(this.dtpDebut);
            this.Controls.Add(this.lblFin);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.lblMotif);
            this.Controls.Add(this.cboMotif);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnAnnuler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAbsence";
            this.Text = "Gestion des Absences";
            this.Load += new System.EventHandler(this.FrmAbsence_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListBox lstAbsences;
        private System.Windows.Forms.DateTimePicker dtpDebut;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.ComboBox cboMotif;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Label lblDebut;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.Label lblMotif;
        private System.Windows.Forms.Label lblListe;
    }
}