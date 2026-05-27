using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.modele;
using MediaTek86.controlleur;

namespace MediaTek86.vue
{
    public partial class FrmAbsence : Form
    {
        private AbsenceController absenceController = new AbsenceController();
        private int idPersonnel;
        private List<Absence> listeAbsences = new List<Absence>();
        private List<Motif> listeMotifs = new List<Motif>();
        private Absence absenceSelectionnee = null;

        public FrmAbsence(int idPersonnel)
        {
            InitializeComponent();
            this.idPersonnel = idPersonnel;
        }

        private void FrmAbsence_Load(object sender, EventArgs e)
        {
            listeMotifs = absenceController.GetAllMotifs();
            cboMotif.DataSource = listeMotifs;
            cboMotif.DisplayMember = "Libelle";
            cboMotif.ValueMember = "IdMotif";

            ChargerAbsences();

            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
        }

        private void ChargerAbsences()
        {
            listeAbsences = absenceController.GetAbsencesByPersonnel(idPersonnel);
            lstAbsences.DataSource = null;
            lstAbsences.DataSource = listeAbsences;
        }

        private void lstAbsences_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAbsences.SelectedIndex != -1)
            {
                absenceSelectionnee = (Absence)lstAbsences.SelectedItem;

                dtpDebut.Value = absenceSelectionnee.DateDebut;
                dtpFin.Value = absenceSelectionnee.DateFin;

                for (int i = 0; i < listeMotifs.Count; i++)
                {
                    if (listeMotifs[i].IdMotif == absenceSelectionnee.IdMotif)
                    {
                        cboMotif.SelectedIndex = i;
                        break;
                    }
                }

                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (cboMotif.SelectedItem == null)
            {
                MessageBox.Show("Veuillez choisir un motif");
                return;
            }

            DateTime dateDebut = dtpDebut.Value.Date;
            DateTime dateFin = dtpFin.Value.Date;
            Motif motifChoisi = (Motif)cboMotif.SelectedItem;

            bool ok = absenceController.AjouterAbsence(idPersonnel, dateDebut, dateFin, motifChoisi.IdMotif);

            if (ok == false)
            {
                MessageBox.Show("Impossible d'ajouter cette absence. La date de fin doit être après la date de début, et les dates ne doivent pas chevaucher une absence déjà existante.");
                return;
            }

            MessageBox.Show("Absence ajoutée !");
            ChargerAbsences();
            ViderChamps();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (absenceSelectionnee == null)
            {
                MessageBox.Show("Veuillez sélectionner une absence dans la liste");
                return;
            }

            DateTime nouvelleDateDebut = dtpDebut.Value.Date;
            DateTime nouvelleDateFin = dtpFin.Value.Date;
            Motif motifChoisi = (Motif)cboMotif.SelectedItem;
            DateTime ancienneDateDebut = absenceSelectionnee.DateDebut;

            bool ok = absenceController.ModifierAbsence(idPersonnel, ancienneDateDebut, nouvelleDateDebut, nouvelleDateFin, motifChoisi.IdMotif);

            if (ok == false)
            {
                MessageBox.Show("Impossible de modifier cette absence. Vérifiez les dates.");
                return;
            }

            MessageBox.Show("Absence modifiée !");
            ChargerAbsences();
            ViderChamps();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (absenceSelectionnee == null)
            {
                MessageBox.Show("Veuillez sélectionner une absence");
                return;
            }

            DialogResult rep = MessageBox.Show("Voulez-vous vraiment supprimer cette absence ?", "Confirmation", MessageBoxButtons.YesNo);

            if (rep == DialogResult.Yes)
            {
                bool ok = absenceController.SupprimerAbsence(idPersonnel, absenceSelectionnee.DateDebut);
                if (ok == true)
                {
                    MessageBox.Show("Absence supprimée");
                    ChargerAbsences();
                    ViderChamps();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression");
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            ViderChamps();
        }

        private void ViderChamps()
        {
            dtpDebut.Value = DateTime.Today;
            dtpFin.Value = DateTime.Today;
            cboMotif.SelectedIndex = 0;
            lstAbsences.ClearSelected();
            absenceSelectionnee = null;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
        }
    }
}