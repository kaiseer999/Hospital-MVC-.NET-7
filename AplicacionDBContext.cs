using bloodyvalentinee.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace bloodyvalentinee
{
    public class AplicacionDBContext : DbContext
    {
        public AplicacionDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario => Set<Usuario>();
        public DbSet<Rol> Rol => Set<Rol>();
        public DbSet<InsGeneral> InsGeneral => Set<InsGeneral>();
        public DbSet<EPS> EPS => Set<EPS>();
        public DbSet<EnfermedadHereditaria> EnfermedadHereditaria => Set<EnfermedadHereditaria>();
        public DbSet<HistoriaClinica> HistoriaClinica => Set<HistoriaClinica>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            


            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.InsGeneral)
                .WithOne(ig => ig.Usuario)
                .HasForeignKey<InsGeneral>(ig => ig.IdUsuario)
                .IsRequired();

           

            modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Rol)
            .WithOne()
            .HasForeignKey<Usuario>(u => u.RolId);


           

            modelBuilder.Entity<HistoriaClinica>()
        .HasKey(hcu => hcu.IdHcu);

            modelBuilder.Entity<HistoriaClinica>()
                .HasOne(hcu => hcu.Usuario)
                .WithOne(u => u.HistoriaClinica)
                .HasForeignKey<HistoriaClinica>(hcu => hcu.IdUsuario);

         

          

            modelBuilder.Entity<HistoriaClinica>()
                .HasOne(hcu => hcu.InsGeneral)
                .WithOne(ig => ig.HistoriaClinica)
                .HasForeignKey<HistoriaClinica>(hcu => hcu.IdIgeneral);

            modelBuilder.Entity<HistoriaClinica>()
                .HasOne(hcu => hcu.EnfermedadHereditaria)
                .WithOne(eh => eh.HistoriaClinica)
                .HasForeignKey<HistoriaClinica>(hcu => hcu.IdEh);

         



            base.OnModelCreating(modelBuilder);
        }




    }
}
