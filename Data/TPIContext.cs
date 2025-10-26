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
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<DocenteCurso> Dictados { get; set; }
        public DbSet<AlumnoInscripcion> AlumnoInscripciones { get; set; }

        internal TPIContext()
        {
            // this.Database.EnsureCreated();
            // DataSeeder.Seed(this);
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
                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Habilitado)
                    .IsRequired()
                    .HasDefaultValue(true);
                entity.Property(e => e.FechaAlta)
                    .IsRequired();
                entity.Property(e => e.Rol)
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

            modelBuilder.Entity<Comision>(entity =>
            {
                entity.HasKey(e => e.IdComision);
                entity.Property(e => e.IdComision)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.DescripcionComision)
                    .IsRequired()
                    .HasMaxLength(500);
                entity.Property(e => e.AnioEspecialidad)
                    .IsRequired();
                entity.Property(e => e.IdPlan)
                    .IsRequired();
                entity.HasIndex(e => new { e.AnioEspecialidad, e.IdPlan })
                    .IsUnique();
                entity.HasOne(e => e.Plan)
                    .WithMany()
                    .HasForeignKey(e => e.IdPlan)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso);
                entity.Property(e => e.IdCurso)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.AnioCalendario)
                    .IsRequired();
                entity.Property(e => e.Cupo)
                    .IsRequired();
                entity.Property(e => e.IdComision)
                    .IsRequired();
                entity.HasOne(e => e.Comision)
                    .WithMany()
                    .HasForeignKey(e => e.IdComision)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.IdMateria)
                    .IsRequired();
                entity.HasOne(e => e.Materia)
                    .WithMany()
                    .HasForeignKey(e => e.IdMateria)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(e => new { e.AnioCalendario, e.IdComision, e.IdMateria })
                    .IsUnique();
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.IdMateria);
                entity.Property(e => e.IdMateria)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.DescripcionMateria)
                    .IsRequired()
                    .HasMaxLength(500);
                entity.Property(e => e.HorasSemanales)
                    .IsRequired();
                entity.Property(e => e.HorasTotales)
                     .IsRequired();
                entity.Property(e => e.IdPlan)
                    .IsRequired();
                entity.HasOne(e => e.Plan)
                    .WithMany()
                    .HasForeignKey(e => e.IdPlan)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(e => new { e.DescripcionMateria, e.IdPlan })
                    .IsUnique();
            });

            modelBuilder.Entity<DocenteCurso>(entity =>
            {
                entity.HasKey(e => e.IdDictado);
                entity.Property(e => e.IdDictado)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.IdDocente)
                    .IsRequired();
                entity.HasOne(e => e.Docente)
                    .WithMany()
                    .HasForeignKey(e => e.IdDocente)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.IdCurso)
                    .IsRequired();
                entity.HasOne(e => e.Curso)
                    .WithMany()
                    .HasForeignKey(e => e.IdCurso)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(e => new { e.IdDocente, e.IdCurso })
                    .IsUnique();
            });

            modelBuilder.Entity<AlumnoInscripcion>(entity =>
            {
                entity.HasKey(e => e.IdInscripcion);
                entity.Property(e => e.IdInscripcion)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Condicion)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Nota)
                    .IsRequired(false);
                entity.Property(e => e.IdAlumno)
                    .IsRequired();
                entity.HasOne(e => e.Alumno)
                    .WithMany()
                    .HasForeignKey(e => e.IdAlumno)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.IdCurso)
                    .IsRequired();
                entity.HasOne(e => e.Curso)
                    .WithMany()
                    .HasForeignKey(e => e.IdCurso)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(e => new { e.IdAlumno, e.IdCurso })
                    .IsUnique();
            });
        }
    }
}
