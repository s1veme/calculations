using System;
using System.Collections.Generic;
using System.Diagnostics;
using GeoApp.Infrastructure.Repositories.User;

namespace GeoApp.Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly Database _database;

        public UserRepository(Database database)
        {
            _database = database;
        }

        public Domain.User GetUserByEmail(string email)
        {
            var query = "SELECT * FROM users WHERE email = @Email";
            var parameters = new Dictionary<string, object> { { "@Email", email } };
            var dataTable = _database.Select(query, parameters);

            if (dataTable.Rows.Count == 0)
            {
                return null;
            }

            var row = dataTable.Rows[0];
            return new UserModel
            {
                ID = Convert.ToInt32(row["id"]),
                Email = row["email"].ToString(),
                Password = row["password"].ToString(),
                PhoneNumber = row["phone_number"].ToString(),
                Role = row["role"].ToString()
            }.ToDomain();
        }

        public void AddUser(Domain.User user)
        {
            var query = "INSERT INTO users (email, password, phone_number, role) VALUES (@Email, @Password, @PhoneNumber, CAST(@Role AS user_role))";
            var parameters = new Dictionary<string, object>
            {
                { "@Email", user.Email },
                { "@Password", user.Password },
                { "@PhoneNumber", user.PhoneNumber },
                { "@Role", user.Role }
            };

            _database.Query(query, parameters);
        }
    }
}