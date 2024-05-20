using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class DesignTimeDbContextOptionsFactory : IDesignTimeDbContextFactory<AccountDbContext>
    {
        public AccountDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<AccountDbContext>();
            options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=ManagerDb;Trusted_Connection=True;");

            return new AccountDbContext(options.Options);
        }
    }
}
