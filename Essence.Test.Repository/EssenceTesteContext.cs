using Essence.Test.RepositoryCore.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essence.Test.RepositoryCore
{
    public class EssenceTesteContext : DbContext
    {
        public EssenceTesteContext()
        { }

        public EssenceTesteContext(DbContextOptions<EssenceTesteContext> opcoes)
            : base(opcoes)
        { }

        public DbSet<Amigo> Amigos { get; set; }

        private void ConfiguraAmigo(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<Amigo>(etd =>
            {
                etd.ToTable("Amigo");
                etd.HasKey(c => c.AmigoId);
                etd.Property(c => c.Nome);
                etd.Property(c => c.Latitude);
                etd.Property(c => c.Longitude);
            });
        }

        protected override void OnModelCreating(ModelBuilder construtorDeModelos)
        {
            //construtorDeModelos.ForSqlServerUseIdentityColumns();
            //construtorDeModelos.HasDefaultSchema("EssenceTeste");

            ConfiguraAmigo(construtorDeModelos);

            base.OnModelCreating(construtorDeModelos);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(EssenceTesteContextFactory.GetConnectionString());
        }
    }
}
