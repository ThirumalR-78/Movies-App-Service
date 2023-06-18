
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PocketCinemaAPIService.Models;

public class DBContextClass : DbContext
{
    public DBContextClass(DbContextOptions<DBContextClass> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure the SQL Server connection
        //optionsBuilder.UseSqlServer("Server=localhost:3306;Database=testing;User=root;Password=root;Trusted_Connection=True;MultipleActiveResultSets=true");
        string connectionString = "server=localhost;port=3306; Database = moviesdb; User = root; Password = root; ";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
    // Add more DbSet properties for other models/entities
    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }

}
