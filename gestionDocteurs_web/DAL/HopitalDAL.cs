using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using gestionDocteurs_web.Models;

namespace gestionDocteurs_web.DAL
{
    public class HopitalDAL
    {
        private readonly string connectionString;
        private readonly Random random = new Random();

        public HopitalDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Hopital> GetAllHopitaux()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Hopital", connection);
                var reader = command.ExecuteReader();

                var hopitaux = new List<Hopital>();
                while (reader.Read())
                {
                    hopitaux.Add(new Hopital
                    {
                        Id = (string)reader["id"],
                        Nom = (string)reader["nom"],
                        Adresse = (string)reader["adresse"],
                    });
                }

                return hopitaux;
            }
        }

        public Hopital GetHopitalById(string hopitalId)
        {
            Hopital hopital = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Hopital WHERE id = @hopitalId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@hopitalId", hopitalId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            hopital = new Hopital
                            {
                                Id = reader["id"].ToString(),
                                Nom = reader["nom"].ToString(),
                                Adresse = reader["adresse"].ToString()
                            };
                        }
                    }
                }
            }
            return hopital;
        }

        public void AddHopital(Hopital hopital)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string id = GenerateRandomID();
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Hopital (id, nom, adresse) VALUES (@id, @nom, @adresse)", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nom", hopital.Nom);
                command.Parameters.AddWithValue("@adresse", hopital.Adresse);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateHopital(Hopital hopital)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Hopital SET nom = @nom, adresse = @adresse WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", hopital.Id);
                command.Parameters.AddWithValue("@nom", hopital.Nom);
                command.Parameters.AddWithValue("@adresse", hopital.Adresse);

                command.ExecuteNonQuery();
            }
        }

        public int DeleteHopital(int hopitalId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Get all docteurs for the hopital
                List<Docteur> docteurs = GetAllDocteursForHopital(hopitalId);

                // Delete each docteur one by one
                foreach (Docteur docteur in docteurs)
                {
                    string deleteDocteurQuery = "DELETE FROM Docteur WHERE id = @id";
                    SqlCommand deleteDocteurCommand = new SqlCommand(deleteDocteurQuery, connection);
                    deleteDocteurCommand.Parameters.AddWithValue("@id", docteur.Id);

                    deleteDocteurCommand.ExecuteNonQuery();
                }

                // Delete the hopital
                string deleteHopitalQuery = "DELETE FROM Hopital WHERE id = @id";
                SqlCommand deleteHopitalCommand = new SqlCommand(deleteHopitalQuery, connection);
                deleteHopitalCommand.Parameters.AddWithValue("@id", hopitalId);

                int rowsAffected = deleteHopitalCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public List<Docteur> GetAllDocteursForHopital(int hopitalId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Docteur WHERE hopital_id = @hopitalId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@hopitalId", hopitalId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Docteur> docteurs = new List<Docteur>();

                        while (reader.Read())
                        {
                            Docteur docteur = new Docteur
                            {
                                Id = (string)reader["id"],
                                Nom = (string)reader["nom"],
                                Prenom = (string)reader["prenom"],
                                HopitalId = (string)reader["hopital_id"],
                                Specialite = (string)reader["specialite"]
                            };

                            docteurs.Add(docteur);
                        }

                        return docteurs;
                    }
                }
            }
        }


        public int GetDoctorCountForHopital(int hopitalId)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Docteur WHERE hopital_id = @hopitalId", connection);
                command.Parameters.AddWithValue("@hopitalId", hopitalId);
                count = (int)command.ExecuteScalar();
                connection.Close();
            }
            return count;
        }

        public string GenerateRandomID()
        {
            return random.Next(10000, 99999).ToString();
        }
    }

}