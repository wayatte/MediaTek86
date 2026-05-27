using System;
using System.Collections.Generic;
using MediaTek86.modele;
using MySql.Data.MySqlClient;

namespace MediaTek86.dal
{
    class AccesAbsence
    {
        // recupere tous les motifs de la table motif
        public List<Motif> GetAllMotifs()
        {
            List<Motif> listeMotifs = new List<Motif>();
            try
            {
                MySqlConnection connexion = bddmanager.BddManager.GetInstance().GetConnexion();
                string requete = "SELECT idmotif, libelle FROM motif";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("idmotif");
                    string libelle = reader.GetString("libelle");
                    Motif unMotif = new Motif(id, libelle);
                    listeMotifs.Add(unMotif);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listeMotifs;
        }

        // recupere les absences dun personnel avec le libelle du motif
        public List<Absence> GetAbsencesByPersonnel(int idPersonnel)
        {
            List<Absence> listeAbsences = new List<Absence>();
            try
            {
                MySqlConnection connexion = bddmanager.BddManager.GetInstance().GetConnexion();
                // jointure entre absence et motif pour avoir le libelle
                string requete = "SELECT a.idpersonnel, a.datedebut, a.datefin, a.idmotif, m.libelle " +
                                 "FROM absence a, motif m " +
                                 "WHERE a.idmotif = m.idmotif " +
                                 "AND a.idpersonnel = @idpersonnel";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                cmd.Parameters.AddWithValue("@idpersonnel", idPersonnel);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idP = reader.GetInt32("idpersonnel");
                    DateTime debut = reader.GetDateTime("datedebut");
                    DateTime fin = reader.GetDateTime("datefin");
                    int idMotif = reader.GetInt32("idmotif");
                    string libelle = reader.GetString("libelle");
                    Absence uneAbsence = new Absence(idP, debut, fin, idMotif, libelle);
                    listeAbsences.Add(uneAbsence);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listeAbsences;
        }

        // verifie si les dates chevauchent une absence existante
        // ancienneDateDebut : pour la modif on exclut labsence qu on est en train de modifier
        // pour un ajout on passe DateTime.MinValue
        public bool VerifierChevauchement(int idPersonnel, DateTime dateDebut, DateTime dateFin, DateTime ancienneDateDebut)
        {
            bool chevauchement = false;
            try
            {
                MySqlConnection connexion = bddmanager.BddManager.GetInstance().GetConnexion();
                // deux periodes se chevauchent si : debut1 <= fin2 ET fin1 >= debut2
                string requete = "SELECT COUNT(*) FROM absence " +
                                 "WHERE idpersonnel = @idpersonnel " +
                                 "AND @dateDebut <= datefin " +
                                 "AND @dateFin >= datedebut " +
                                 "AND datedebut != @ancienneDate";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                cmd.Parameters.AddWithValue("@idpersonnel", idPersonnel);
                cmd.Parameters.AddWithValue("@dateDebut", dateDebut.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@dateFin", dateFin.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ancienneDate", ancienneDateDebut.ToString("yyyy-MM-dd"));
                int nb = (int)(long)cmd.ExecuteScalar();
                if (nb > 0)
                {
                    chevauchement = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return chevauchement;
        }

        // ajoute une absence dans la bdd
        public bool AjouterAbsence(Absence absence)
        {
            bool ok = false;
            try
            {
                MySqlConnection connexion = bddmanager.BddManager.GetInstance().GetConnexion();
                string requete = "INSERT INTO absence (idpersonnel, datedebut, datefin, idmotif) " +
                                 "VALUES (@idpersonnel, @datedebut, @datefin, @idmotif)";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                cmd.Parameters.AddWithValue("@idpersonnel", absence.IdPersonnel);
                cmd.Parameters.AddWithValue("@datedebut", absence.DateDebut.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@datefin", absence.DateFin.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@idmotif", absence.IdMotif);
                int nb = cmd.ExecuteNonQuery();
                if (nb == 1)
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ok;
        }

        // modifie une absence - on identifie labsence avec idpersonnel + ancienne date debut
        public bool ModifierAbsence(Absence absence, DateTime ancienneDateDebut)
        {
            bool ok = false;
            try
            {
                MySqlConnection connexion = bddmanager.BddManager.GetInstance().GetConnexion();
                string requete = "UPDATE absence SET datedebut = @datedebut, datefin = @datefin, idmotif = @idmotif " +
                                 "WHERE idpersonnel = @idpersonnel AND datedebut = @ancienneDateDebut";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                cmd.Parameters.AddWithValue("@datedebut", absence.DateDebut.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@datefin", absence.DateFin.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@idmotif", absence.IdMotif);
                cmd.Parameters.AddWithValue("@idpersonnel", absence.IdPersonnel);
                cmd.Parameters.AddWithValue("@ancienneDateDebut", ancienneDateDebut.ToString("yyyy-MM-dd"));
                int nb = cmd.ExecuteNonQuery();
                if (nb == 1)
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ok;
        }

        // supprime une absence
        public bool SupprimerAbsence(int idPersonnel, DateTime dateDebut)
        {
            bool ok = false;
            try
            {
                MySqlConnection connexion = bddmanager.BddManager.GetInstance().GetConnexion();
                string requete = "DELETE FROM absence WHERE idpersonnel = @idpersonnel AND datedebut = @datedebut";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                cmd.Parameters.AddWithValue("@idpersonnel", idPersonnel);
                cmd.Parameters.AddWithValue("@datedebut", dateDebut.ToString("yyyy-MM-dd"));
                int nb = cmd.ExecuteNonQuery();
                if (nb == 1)
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ok;
        }
    }
}
