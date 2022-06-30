using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class DataBase
    {
        private string provider;
        private string connectionString;

        public DataBase()
        {
            this.provider = ConfigurationManager.AppSettings["Provider"];
            this.connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public int CheckUserAuth(string email, string password)
        {
            string sql = "SELECT id FROM [user_auth] WHERE email = @email AND password = @password";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Convert.ToInt32(reader["id"]);
                        }
                    }
                }
            }

            return -1;
        }

        public Model.User FindUser(int auth_id)
        {
            string sql = "SELECT id, avatar, name, surname FROM [user] WHERE auth_id = @auth_id";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@auth_id", auth_id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Model.User(Convert.ToInt32(reader["id"]),
                                Convert.ToString(reader["name"]),
                                Convert.ToString(reader["surname"]),
                                Convert.ToString(reader["avatar"]));
                        }
                    }
                }
            }

            return null;
        }

        public List<Model.Message> GetMessages(int id)
        {
            string sql = "SELECT u1.surname AS 'sender', u2.surname AS 'retriever', m.text, m.id FROM [message] m " +
                "INNER JOIN [user] u1 ON m.sender_id = u1.id " +
                "INNER JOIN [user] u2 ON m.receiver_id = u2.id " +
                "WHERE u1.id = @id " +
                "OR u2.id = @id";
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        List<Model.Message> messages = new List<Model.Message>();
                        while (reader.Read())
                        {
                            messages.Add(new Model.Message(Convert.ToString(reader["sender"]),
                                Convert.ToString(reader["retriever"]),
                                Convert.ToString(reader["text"]),
                                Convert.ToInt32(reader["id"])));
                        }
                        return messages;
                    }
                }
            }
        }

        public void EditMessage(int id, string text)
        {
            string sql = "UPDATE [message] SET text = @text WHERE id = @id";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@text", text);
                        command.ExecuteNonQuery();
                    }
                    //transaction.Commit();
                }
                catch (Exception)
                {
                    //transaction.Rollback();
                }
            }
        }

        public void DeleteMessage(int id)
        {
            string sql = "DELETE FROM [message] WHERE id = @id";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddUser(string name, string surname, string avatar, string email, string password)
        {
            using (SqlCommand command = new SqlCommand("AddUser", new SqlConnection(connectionString)))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@surname", surname);
                command.Parameters.AddWithValue("@avatar", avatar);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Model.User> GetUsers()
        {
            string sql = "SELECT id, name, surname, avatar FROM [user]";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        List<Model.User> users = new List<Model.User>();
                        while (reader.Read())
                        {
                            users.Add(new Model.User(Convert.ToInt32(reader["id"]),
                                Convert.ToString(reader["name"]),
                                Convert.ToString(reader["surname"]),
                                Convert.ToString(reader["avatar"])));
                        }
                        return users;
                    }
                }
            }
        }

        public void WriteMessage(int sender_id, int receiver_id, string text)
        {
            string sql = "INSERT INTO [message] (sender_id, receiver_id, text) VALUES (@sender_id, @receiver_id, @text)";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@sender_id", sender_id);
                    command.Parameters.AddWithValue("@receiver_id", receiver_id);
                    command.Parameters.AddWithValue("@text", text);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
