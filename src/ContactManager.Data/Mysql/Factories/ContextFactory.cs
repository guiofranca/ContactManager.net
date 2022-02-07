namespace ContactManager.Data.Mysql.Factories;

using ContactManager.Data.Mysql.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

        return new DataContext(optionsBuilder.Options);
    }
}