using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace GeoApp.Infrastructure
{
    public class Database
    {
        private NpgsqlConnection connection;
        private static Database instance;

        public Database(string host, int port, string username, string password, string database)
        {
            string connectionString = CreateConnectionString(host, port, username, password, database);
            connection = new NpgsqlConnection(connectionString);
            instance = this;
        }

        public static Database GetInstance()
        {
            return instance;
        }

        private string CreateConnectionString(string host, int port, string username, string password, string database)
        {
            return $"Host={host};Port={port};Username={username};Password={password};Database={database}";
        }

        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public NpgsqlConnection GetConnection()
        {
            return connection;
        }

        public DataTable Select(string query, Dictionary<string, object> parameters)
        {
            OpenConnection();

            NpgsqlCommand command = new NpgsqlCommand(query);

            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            command.Connection = GetConnection();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

            DataTable result = new DataTable();
            adapter.Fill(result);

            CloseConnection();

            return result;
        }

        public void Query(string query, Dictionary<string, object> parameters)
        {
            OpenConnection();

            NpgsqlCommand command = new NpgsqlCommand(query);

            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            command.Connection = GetConnection();
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public object QueryScalar(string query, Dictionary<string, object> parameters)
        {
            OpenConnection();
            using (var command = new NpgsqlCommand(query, connection))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                var result = command.ExecuteScalar();
                CloseConnection();
                return result;
            }
        }
    }
}
