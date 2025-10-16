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
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<GrupoPermiso> GruposPermisos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Materia> Materias { get; set; }

        internal TPIContext()
        {
            // this.Database.EnsureDeleted(); // Solo en desarrollo
            // this.Database.EnsureCreated();
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
                entity.HasOne(e => e.Persona)
                    .WithMany()
                    .HasForeignKey(e => e.IdPersona)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(e => e.Grupo)
                    .WithMany()
                    .HasForeignKey(e => e.GrupoPermisoId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.ToTable("Permisos");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Habilitado)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.HasIndex(e => new { e.Nombre, e.Categoria })
                    .IsUnique();
            });

            modelBuilder.Entity<GrupoPermiso>(entity =>
            {
                entity.ToTable("GruposPermisos");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(e => e.Nombre)
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Habilitado)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.Property(e => e.FechaCreacion)
                    .IsRequired();
            });

            modelBuilder.Entity<GrupoPermiso>()
                .HasMany(g => g.Permisos)
                .WithMany(p => p.Grupos)
                .UsingEntity<Dictionary<string, object>>(
                    "GrupoPermisoPermiso",
                    j => j.HasOne<Permiso>().WithMany().HasForeignKey("PermisosId"),
                    j => j.HasOne<GrupoPermiso>().WithMany().HasForeignKey("GruposId"),
                    j =>
                    {
                        j.HasKey("GruposId", "PermisosId");
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

            // SEED DATA - Permisos iniciales
            var fechaCreacion = DateTime.Now;

            modelBuilder.Entity<Permiso>().HasData(
                // Permisos para Especialidades
                new { Id = 1, Nombre = "leer", Descripcion = "Ver especialidades", Categoria = "especialidades", Habilitado = true },
                new { Id = 2, Nombre = "agregar", Descripcion = "Crear especialidades", Categoria = "especialidades", Habilitado = true },
                new { Id = 3, Nombre = "actualizar", Descripcion = "Modificar especialidades", Categoria = "especialidades", Habilitado = true },
                new { Id = 4, Nombre = "eliminar", Descripcion = "Eliminar especialidades", Categoria = "especialidades", Habilitado = true },

                // Permisos para Planes
                new { Id = 5, Nombre = "leer", Descripcion = "Ver planes", Categoria = "planes", Habilitado = true },
                new { Id = 6, Nombre = "agregar", Descripcion = "Crear planes", Categoria = "planes", Habilitado = true },
                new { Id = 7, Nombre = "actualizar", Descripcion = "Modificar planes", Categoria = "planes", Habilitado = true },
                new { Id = 8, Nombre = "eliminar", Descripcion = "Eliminar planes", Categoria = "planes", Habilitado = true },

                // Permisos para Personas
                new { Id = 9, Nombre = "leer", Descripcion = "Ver personas", Categoria = "personas", Habilitado = true },
                new { Id = 10, Nombre = "agregar", Descripcion = "Crear personas", Categoria = "personas", Habilitado = true },
                new { Id = 11, Nombre = "actualizar", Descripcion = "Modificar personas", Categoria = "personas", Habilitado = true },
                new { Id = 12, Nombre = "eliminar", Descripcion = "Eliminar personas", Categoria = "personas", Habilitado = true },

                // Permisos para Usuarios
                new { Id = 13, Nombre = "leer", Descripcion = "Ver usuarios", Categoria = "usuarios", Habilitado = true },
                new { Id = 14, Nombre = "agregar", Descripcion = "Crear usuarios", Categoria = "usuarios", Habilitado = true },
                new { Id = 15, Nombre = "actualizar", Descripcion = "Modificar usuarios", Categoria = "usuarios", Habilitado = true },
                new { Id = 16, Nombre = "eliminar", Descripcion = "Eliminar usuarios", Categoria = "usuarios", Habilitado = true },

                // Permisos para Materias
                new { Id = 17, Nombre = "leer", Descripcion = "Ver materias", Categoria = "materias", Habilitado = true },
                new { Id = 18, Nombre = "agregar", Descripcion = "Crear materias", Categoria = "materias", Habilitado = true },
                new { Id = 19, Nombre = "actualizar", Descripcion = "Modificar materias", Categoria = "materias", Habilitado = true },
                new { Id = 20, Nombre = "eliminar", Descripcion = "Eliminar materias", Categoria = "materias", Habilitado = true },

                // Permisos para Cursos
                new { Id = 21, Nombre = "leer", Descripcion = "Ver cursos", Categoria = "cursos", Habilitado = true },
                new { Id = 22, Nombre = "agregar", Descripcion = "Crear cursos", Categoria = "cursos", Habilitado = true },
                new { Id = 23, Nombre = "actualizar", Descripcion = "Modificar cursos", Categoria = "cursos", Habilitado = true },
                new { Id = 24, Nombre = "eliminar", Descripcion = "Eliminar cursos", Categoria = "cursos", Habilitado = true },

                // Permisos para Comisiones
                new { Id = 25, Nombre = "leer", Descripcion = "Ver comisiones", Categoria = "comisiones", Habilitado = true },
                new { Id = 26, Nombre = "agregar", Descripcion = "Crear comisiones", Categoria = "comisiones", Habilitado = true },
                new { Id = 27, Nombre = "actualizar", Descripcion = "Modificar comisiones", Categoria = "comisiones", Habilitado = true },
                new { Id = 28, Nombre = "eliminar", Descripcion = "Eliminar comisiones", Categoria = "comisiones", Habilitado = true }
            );

            // SEED DATA - Grupos de permisos iniciales
            modelBuilder.Entity<GrupoPermiso>().HasData(
                new { Id = 1, Nombre = "Administrador", Descripcion = "Acceso completo al sistema", Habilitado = true, FechaCreacion = fechaCreacion },
                new { Id = 2, Nombre = "Docente", Descripcion = "Acceso a cursos y alumnos", Habilitado = true, FechaCreacion = fechaCreacion },
                new { Id = 3, Nombre = "Alumno", Descripcion = "Acceso limitado de consulta", Habilitado = true, FechaCreacion = fechaCreacion }
            );
        }
        private void SeedPermisosAGrupos()
        {
            try
            {
                // Verificar si ya existen las relaciones
                if (!GruposPermisos.Any(g => g.Permisos.Any()) &&
                    GruposPermisos.Any() &&
                    Permisos.Any())
                {
                    // Cargar grupos y permisos
                    var grupoAdmin = GruposPermisos.Include(g => g.Permisos)
                        .FirstOrDefault(g => g.Nombre == "Administrador");
                    var grupoDocente = GruposPermisos.Include(g => g.Permisos)
                        .FirstOrDefault(g => g.Nombre == "Docente");
                    var grupoAlumno = GruposPermisos.Include(g => g.Permisos)
                        .FirstOrDefault(g => g.Nombre == "Alumno");
                    var todosPermisos = Permisos.ToList();

                    if (grupoAdmin != null && grupoDocente != null && grupoAlumno != null && todosPermisos.Any())
                    {
                        // Asignar TODOS los permisos al Administrador
                        foreach (var permiso in todosPermisos)
                        {
                            if (!grupoAdmin.Permisos.Contains(permiso))
                            {
                                grupoAdmin.AgregarPermiso(permiso);
                            }
                        }

                        // Asignar permisos al Docente
                        var permisosDocente = todosPermisos.Where(p =>
                            p.Categoria == "cursos" ||
                            p.Categoria == "comisiones" ||
                            (p.Categoria == "personas" && p.Nombre == "leer") ||
                            (p.Categoria == "materias" && p.Nombre == "leer")
                        ).ToList();

                        foreach (var permiso in permisosDocente)
                        {
                            if (!grupoDocente.Permisos.Contains(permiso))
                            {
                                grupoDocente.AgregarPermiso(permiso);
                            }
                        }

                        // Asignar permisos al Alumno (solo lectura)
                        var permisosAlumno = todosPermisos.Where(p =>
                            p.Nombre == "leer" &&
                            (p.Categoria == "cursos" || p.Categoria == "materias" || p.Categoria == "comisiones")
                        ).ToList();

                        foreach (var permiso in permisosAlumno)
                        {
                            if (!grupoAlumno.Permisos.Contains(permiso))
                            {
                                grupoAlumno.AgregarPermiso(permiso);
                            }
                        }

                        SaveChanges();
                    }
                }
            }
            catch
            {
                // Si hay algún error en el seed, lo ignoramos
                // Esto evita problemas en la inicialización
            }
        }
    }
}
