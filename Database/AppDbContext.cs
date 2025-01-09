// File: Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using TBAG.Models;

namespace TBAG.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Save> Saves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database/database.db");
        }
    }
}