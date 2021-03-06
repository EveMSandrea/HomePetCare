using Microsoft.EntityFrameworkCore;
using RazorPagesMascotas.Models;


namespace HomePetCare.App.Persistencia
{
    public class AppContext : DbContext 
    {
        public DbSet<Persona> Personas { get; set;}
        public DbSet<Veterinario> Veterinarios { get; set;}
        public DbSet<Propietario> Propietarios { get; set;}
        public DbSet<Mascota> Mascotas { get; set;}
        public DbSet<Visita> Visita { get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =HomePetCareData");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mascota>().ToTable(nameof(Mascotas))
                .HasOne(m => m.Propietario);
        }
    }
}

