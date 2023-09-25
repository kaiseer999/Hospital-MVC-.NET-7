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
        public DbSet<Medico> Medico => Set<Medico>();
        public DbSet<CitaMedica> CitaMedica => Set<CitaMedica>();
        public DbSet<RecetaMedica> RecetaMedica => Set<RecetaMedica>();




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

            modelBuilder.Entity<Medico>()
          .HasOne(m => m.CitaMedica)
          .WithOne(c => c.Medico)
          .HasForeignKey<CitaMedica>(c => c.IdMedico)
          .IsRequired();
           
            modelBuilder.Entity<Usuario>()
        .HasOne(u => u.CitaMedica)
        .WithOne(c => c.Usuario)
        .HasForeignKey<CitaMedica>(c => c.IdUsuario)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
         

            modelBuilder.Entity<Usuario>()
        .HasOne(u => u.Medico)
        .WithOne(m => m.Usuario)
        .HasForeignKey<Medico>(m => m.IdUsuario)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                    .HasOne(u => u.recetaMedica)   
                    .WithOne(r => r.Usuario)        
                    .HasForeignKey<RecetaMedica>(r => r.IdUsuario);




            base.OnModelCreating(modelBuilder);
        }




    }
}
