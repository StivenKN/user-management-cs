using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using UserManagement.Model;

namespace UserManagement.Data.Repositories.Users
{
    public class UserRepository(Context context) : IUserRepository
    {
        private readonly Context _context = context;

        public async Task<bool> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            return true;
        }

        public async Task<User> GetUserByID(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user ?? throw new DataException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<bool> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
