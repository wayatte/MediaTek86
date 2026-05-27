namespace MediaTek86.modele
{
    class Motif
    {
        private int idMotif;
        private string libelle;

        public Motif(int idMotif, string libelle)
        {
            this.idMotif = idMotif;
            this.libelle = libelle;
        }

        public int IdMotif
        {
            get { return idMotif; }
            set { idMotif = value; }
        }

        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }

        // pour afficher dans le combobox
        public override string ToString()
        {
            return libelle;
        }
    }
}