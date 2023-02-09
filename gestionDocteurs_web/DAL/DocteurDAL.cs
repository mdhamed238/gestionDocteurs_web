using gestionDocteurs_web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace gestionDocteurs_web.DAL
{
    public class DocteurDAL
    {
        private readonly string connectionString;
        private readonly Random random = new Random();
        private HopitalDAL hopitalDAL;

        public DocteurDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Docteur> GetAllDocteurs()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Docteur", connection);
                var reader = command.ExecuteReader();

                var docteurs = new List<Docteur>();
                while (reader.Read())
                {
                    hopitalDAL = new HopitalDAL(connectionString);
                    string hopitalId = (string)reader["hopital_id"];
                    var hopital = hopitalDAL.GetHopitalById(hopitalId);
                    docteurs.Add(new Docteur
                    {
                        Id = (string)reader["id"],
                        Nom = (string)reader["nom"],
                        Prenom = (string)reader["prenom"],
                        Specialite = (string)reader["specialite"],
                        HopitalId = (string)reader["hopital_id"],
                        hopital = hopital
                    });;
                }

                return docteurs;
            }
        }

        public Docteur GetDocteurById(int docteurId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM Docteur WHERE Id = @DocteurId", connection))
                {
                    command.Parameters.AddWithValue("@DocteurId", docteurId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Docteur
                            {
                                Id = reader.GetString(0),
                                Nom = reader.GetString(1),
                                Prenom = reader.GetString(2),
                                Specialite = reader.GetString(3),
                                HopitalId = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return null;
        }


        public List<Docteur> GetDocteursByHopitalId(int hopitalId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Docteur WHERE hopital_id = @hopitalId", connection);
                command.Parameters.AddWithValue("@hopitalId", hopitalId);
                var reader = command.ExecuteReader();

                var docteurs = new List<Docteur>();
                while (reader.Read())
                {
                    docteurs.Add(new Docteur
                    {
                        Id = (string)reader["id"],
                        Nom = (string)reader["nom"],
                        Prenom = (string)reader["prenom"],
                        Specialite = (string)reader["specialite"],
                        HopitalId = (string)reader["hopital_id"],
                    });
                }

                return docteurs;
            }
        }

        public void AddDocteur(Docteur docteur)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string id = GenerateRandomID();
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Docteur (id, nom, prenom, specialite, hopital_id) VALUES (@id, @nom, @prenom, @specialite, @hopitalId)", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nom", docteur.Nom);
                command.Parameters.AddWithValue("@prenom", docteur.Prenom);
                command.Parameters.AddWithValue("@specialite", docteur.Specialite);
                command.Parameters.AddWithValue("@hopitalId", docteur.HopitalId);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateDocteur(Docteur docteur)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Docteur SET nom = @nom, prenom = @prenom, specialite = @specialite, hopital_id = @hopitalId WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", docteur.Id);
                command.Parameters.AddWithValue("@nom", docteur.Nom);
                command.Parameters.AddWithValue("@prenom", docteur.Prenom);
                command.Parameters.AddWithValue("@specialite", docteur.Specialite);
                command.Parameters.AddWithValue("@hopitalId", docteur.HopitalId);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteDocteur(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Docteur WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public string GenerateRandomID()
        {
            return random.Next(10000, 99999).ToString();
        }
    }

}