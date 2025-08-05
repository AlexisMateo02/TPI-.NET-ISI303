using Microsoft.EntityFrameworkCore;
using APIWeb.Models;

namespace APIWeb.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            // Constructor para la inyección de dependencias
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
    }
}
