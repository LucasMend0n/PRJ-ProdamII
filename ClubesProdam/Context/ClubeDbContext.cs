using ClubesProdam.model;
using Microsoft.EntityFrameworkCore;

namespace ClubesProdam.Context
{
    public class ClubeDbContext : DbContext
    {
        public ClubeDbContext(DbContextOptions<ClubeDbContext> options) : base(options)
        {}

        public DbSet<Estabelecimento> Estabelecimentos  { get; set; }
        public DbSet<Funcionario> Funcionarios  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}