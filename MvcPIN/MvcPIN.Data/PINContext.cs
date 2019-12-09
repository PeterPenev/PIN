using Microsoft.EntityFrameworkCore;
using MvcPIN.Models;

namespace MvcPIN.Data
{
    public class PINContext : DbContext
    {
        public PINContext()
        {

        }

        public PINContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<PIN> PINs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

        }
    }
}
