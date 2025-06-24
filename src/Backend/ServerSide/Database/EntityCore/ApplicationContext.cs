using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using ServerSide.Database.EntityCore.Models;

namespace ServerSide.Database.EntityCore
{


    internal class ApplicationContext : DbContext
    {
        private static readonly string? connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

        public DbSet<AccountsModel> accounts => Set<AccountsModel>();
        public DbSet<CharactersModel> characters => Set<CharactersModel>();
        public DbSet<BanList> ban_lists => Set<BanList>();
        public ApplicationContext() => Database.EnsureCreated();
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (connectionString == null)
                return;

            optionsBuilder.UseMySql(connectionString,
                new MySqlServerVersion(new Version(8,0,36)));
        }
    }
}
    