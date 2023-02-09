using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using gestionDocteurs_web.Models;

namespace gestionDocteurs_web.DAL
{
    public class LoginDAL
    {
        private readonly string connectionString;
        private readonly Random random = new Random();

        public LoginDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Login LoginUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE username = @username AND password = @password", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Login
                    {
                        Id = (string)reader["id"],
                        Username = (string)reader["username"],
                        Password = (string)reader["password"],
                    };
                }

                return null;
            }
        }

        public void CreateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string id = GenerateRandomID();
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Login (id, username, password) VALUES (@id, @username, @password)", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteUser(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM Login WHERE username = @username", connection);
                command.Parameters.AddWithValue("@username", username);

                command.ExecuteNonQuery();
            }
        }

        public void ChangePassword(string username, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Login SET password = @newPassword WHERE username = @username", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@newPassword", newPassword);

                command.ExecuteNonQuery();
            }
        }

        public string GenerateRandomID()
        {
            return random.Next(10000, 99999).ToString();
        }
    }

}