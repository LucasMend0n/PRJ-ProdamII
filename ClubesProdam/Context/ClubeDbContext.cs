using ClubesProdam.model;
using Microsoft.EntityFrameworkCore;

namespace ClubesProdam.Context
{
    public class ClubeDbContext : DbContext
    {
        public ClubeDbContext(DbContextOptions<ClubeDbContext> options) : base(options)
        {}

        public DbSet<Estabelecimento> Estabelecimentos  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}