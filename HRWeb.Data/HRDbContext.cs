using HRWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRWeb.Data
{
    public class HRDbContext : DbContext
    {
        public DbSet<Recruiter> Recruiters { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}