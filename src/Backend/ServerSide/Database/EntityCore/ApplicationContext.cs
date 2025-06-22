using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerSide.Database.EntityCore.Models;

namespace ServerSide.Database.EntityCore
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Accounts> accounts => Set<Accounts>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;Database=greenyear;username=root;password=;", 
                new MySqlServerVersion(new Version(8,0,36)));
        }
    }
}
