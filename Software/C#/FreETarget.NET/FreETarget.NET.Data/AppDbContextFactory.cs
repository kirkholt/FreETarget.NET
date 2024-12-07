using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreETarget.NET.Data
{
    internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AppDbContext> optionsBuilder
                = new DbContextOptionsBuilder<AppDbContext>();

            /*
                        string provider = args.Length > 0 ? args[0] : "sqlite";
                        if (provider == "sqlite")
                        {
                            optionsBuilder.UseSqlite();
                        }
                        else if (provider == "sqlserver")
                        {
                            optionsBuilder.UseSqlServer();
                        }
                        else if (provider == "mysql")
                        {
                            //    optionsBuilder.UseMySql(("");
                        }
                        else if (provider == "npgsql")
                        {
                            optionsBuilder.UseNpgsql();
                        }
                        else
                        {
                            throw new ArgumentException("Invalid provider");
                        }
            */

            optionsBuilder.UseSqlite("Data Source=..\\FreETargetNet.db");
            //optionsBuilder.UseSqlServer();
            //optionsBuilder.UseMySql();
            //optionsBuilder.UseNpgsql();
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

