using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //definir PK
            modelBuilder.Entity<Ator_Filme>().HasKey(af => new
            {
                af.AtorId,
                af.FilmeId
            });

            modelBuilder.Entity<Ator_Filme>()
               .HasOne(f => f.Filme)//Ator_Filme tem um Filme
               .WithMany(af => af.Atores_Filmes)//Filme tem vários Atores_Filmes
               .HasForeignKey(af => af.FilmeId);//FK

            modelBuilder.Entity<Ator_Filme>()
                .HasOne(a => a.Ator)//Ator_Filme tem um Ator
                .WithMany(af => af.Atores_Filmes)//Ator tem vários Atores_Filmes
                .HasForeignKey(af => af.AtorId);//FK

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Ator_Filme> Atores_Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Diretor> Diretores { get; set; }
    }
}
