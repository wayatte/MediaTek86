using System;
using MySql.Data.MySqlClient;

namespace MediaTek86.bddmanager
{
    class BddManager
    {
        private static BddManager instance = null;
        private MySqlConnection connexion;

        // Constructeur privé pour empêcher l'instanciation directe (Singleton)
        private BddManager()
        {
            try
            {
                // Chaîne de connexion avec ton utilisateur et ta base
                string connectionString = "server=localhost;user id=dev_mediatek;password=MotDePasse123!;database=mediatek86;sslmode=none";
                connexion = new MySqlConnection(connectionString);
                connexion.Open();
            }
            catch (Exception ex)
            {
                // Un petit Console.WriteLine classique pour les erreurs
                Console.WriteLine("Erreur de connexion à la base : " + ex.Message);
            }
        }

        // Méthode pour récupérer l'instance unique
        public static BddManager GetInstance()
        {
            if (instance == null)
            {
                instance = new BddManager();
            }
            return instance;
        }

        // Méthode utilisée par AccesAbsence pour récupérer la connexion
        public MySqlConnection GetConnexion()
        {
            return connexion;
        }
    }
}