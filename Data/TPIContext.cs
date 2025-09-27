using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Academia.Entidades;

namespace Data
{
    public class TPIContext : DbContext
    {
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Persona> Personas { get; set; }

        internal TPIContext()
        {
            //this.Database.EnsureDeleted(); // Solo en desarrollo
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.HasIndex(e => e.NombreUsuario)
                    .IsUnique();
                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Habilitado)
                    .IsRequired()
                    .HasDefaultValue(true);
                entity.Property(e => e.FechaAlta)
                    .IsRequired();
                entity.HasOne(e => e.Persona)
                    .WithMany()
                    .HasForeignKey(e => e.IdPersona)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);

            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500);
            });


            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.IdPlan);
                entity.Property(e => e.IdPlan)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500);
                entity.Property(e => e.IdEspecialidad)
                    .IsRequired();
                entity.HasOne(e => e.Especialidad)
                    .WithMany()
                    .HasForeignKey(e => e.IdEspecialidad)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);
                entity.Property(e => e.IdPersona)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.HasIndex(e => e.Email)
                    .IsUnique();
                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.Property(e => e.FechaNacimiento)
                    .IsRequired();
                entity.Property(e => e.Legajo)
                    .IsRequired();
                entity.HasIndex(e => e.Legajo)
                    .IsUnique();
                entity.Property(e => e.TipoPersona)
                    .IsRequired();
                entity.Property(e => e.IdPlan)
                    .IsRequired();
                entity.HasOne(e => e.Plan)
                    .WithMany()
                    .HasForeignKey(e => e.IdPlan)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
