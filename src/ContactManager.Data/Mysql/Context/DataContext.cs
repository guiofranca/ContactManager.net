namespace ContactManager.Data.Mysql.Context;

using System.Reflection;
using ContactManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
    public DataContext() { }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<string>()
            .AreUnicode(false)
            .HaveColumnType("varchar")
            .HaveMaxLength(255);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json")
            .Build();
        
        var serverVersion = new MariaDbServerVersion(config["MariaDbServerVersion"]);
        optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"), serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder
        //     .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<Phone> Phones { get; set; }
}