using System;
using System.Collections.Generic;
using MediaTek86.modele;
using MediaTek86.dal;

namespace MediaTek86.controlleur
{
    class AbsenceController
    {
        private AccesAbsence accesAbsence = new AccesAbsence();

        // retourne la liste des motifs pour le combobox
        public List<Motif> GetAllMotifs()
        {
            return accesAbsence.GetAllMotifs();
        }

        // retourne les absences dun personnel
        public List<Absence> GetAbsencesByPersonnel(int idPersonnel)
        {
            return accesAbsence.GetAbsencesByPersonnel(idPersonnel);
        }

        // ajoute une absence avec verification des dates et du chevauchement
        // retourne false si ya un probleme
        public bool AjouterAbsence(int idPersonnel, DateTime dateDebut, DateTime dateFin, int idMotif)
        {
            // la date de fin doit pas etre avant la date de debut
            if (dateFin < dateDebut)
            {
                return false;
            }
            // pour lajout on passe DateTime.MinValue comme ancienne date
            // comme ca la requete SQL va rien exclure
            bool chevauche = accesAbsence.VerifierChevauchement(idPersonnel, dateDebut, dateFin, DateTime.MinValue);
            if (chevauche == true)
            {
                return false;
            }
            Absence nouvelleAbsence = new Absence(idPersonnel, dateDebut, dateFin, idMotif);
            bool resultat = accesAbsence.AjouterAbsence(nouvelleAbsence);
            return resultat;
        }

        // modifie une absence avec verification
        public bool ModifierAbsence(int idPersonnel, DateTime ancienneDateDebut, DateTime nouvelleDateDebut, DateTime nouvelleDateFin, int idMotif)
        {
            if (nouvelleDateFin < nouvelleDateDebut)
            {
                return false;
            }
            // on passe lancienne date pour pas compter labsence quon modifie
            bool chevauche = accesAbsence.VerifierChevauchement(idPersonnel, nouvelleDateDebut, nouvelleDateFin, ancienneDateDebut);
            if (chevauche == true)
            {
                return false;
            }
            Absence absenceModifiee = new Absence(idPersonnel, nouvelleDateDebut, nouvelleDateFin, idMotif);
            bool resultat = accesAbsence.ModifierAbsence(absenceModifiee, ancienneDateDebut);
            return resultat;
        }

        // supprime une absence
        public bool SupprimerAbsence(int idPersonnel, DateTime dateDebut)
        {
            return accesAbsence.SupprimerAbsence(idPersonnel, dateDebut);
        }
    }
}
