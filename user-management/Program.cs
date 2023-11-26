using System.Configuration;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using UserManagement.Data;
using UserManagement.Data.Repositories.Users;

namespace user_management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");

            builder
                .Services
                .AddDbContext<Context>(
                    options =>
                        options.UseMySql(
                            connectionString,
                            new MySqlServerVersion(new Version(8, 0, 35)),
                            null
                        )
                );

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
