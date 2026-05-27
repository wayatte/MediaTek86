using System;

namespace MediaTek86.modele
{
    class Absence
    {
        private int idPersonnel;
        private DateTime dateDebut;
        private DateTime dateFin;
        private int idMotif;
        private string libelleMotif;

        public Absence(int idPersonnel, DateTime dateDebut, DateTime dateFin, int idMotif, string libelleMotif = "")
        {
            this.idPersonnel = idPersonnel;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            this.idMotif = idMotif;
            this.libelleMotif = libelleMotif;
        }

        public int IdPersonnel
        {
            get { return idPersonnel; }
            set { idPersonnel = value; }
        }

        public DateTime DateDebut
        {
            get { return dateDebut; }
            set { dateDebut = value; }
        }

        public DateTime DateFin
        {
            get { return dateFin; }
            set { dateFin = value; }
        }

        public int IdMotif
        {
            get { return idMotif; }
            set { idMotif = value; }
        }

        public string LibelleMotif
        {
            get { return libelleMotif; }
            set { libelleMotif = value; }
        }

        // pour afficher dans la listbox
        public override string ToString()
        {
            return "du " + dateDebut.ToString("dd/MM/yyyy") + " au " + dateFin.ToString("dd/MM/yyyy") + " - " + libelleMotif;
        }
    }
}
