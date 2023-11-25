using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using UserManagement.Model;

namespace UserManagement.Data.Repositories
{
    public class UserRepository(MySqlConnection mySqlConnection) : IUserRepository
    {
        private readonly MySqlConnection _query = mySqlConnection;

        public Task<bool> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = new List<User>();
            using var command = new MySqlCommand("SELECT * FROM users", _query);

            await _query.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                users.Add(
                    new User
                    {
                        Id = reader.GetInt32("id"),
                        UserFullName = reader.GetString("user_full_name"),
                        UserEmail = reader.GetString("user_email"),
                        UserPassword = reader.GetString("user_password"),
                        DbNamespace = reader.GetString("db_namespace"),
                        UserStatus = reader.GetString("user_status"),
                        IdUserApiKeyFk = reader.GetInt32("id_user_api_key_fk"),
                        IdUserRoleFk = reader.GetInt32("id_user_role_fk")
                    }
                );
            }

            return users;
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
