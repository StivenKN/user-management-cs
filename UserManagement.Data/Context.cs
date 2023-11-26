using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagement.Model;

namespace UserManagement.Data
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
