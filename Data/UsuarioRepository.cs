using Academia.Entidades;
using Microsoft.EntityFrameworkCore;
// using Microsoft.Data.SqlClient;

namespace Data
{
    public class UsuarioRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }
        public Usuario? Get(int id)
        {
            using var context = CreateContext();
            return context.Usuarios
                .Include(u => u.Persona)
                .Include(u => u.Grupo)
                    .ThenInclude(g => g.Permisos.Where(p => p.Habilitado))
                .FirstOrDefault(u => u.Id == id);
        }
        public Usuario? GetByUsername(string username)
        {
            using var context = CreateContext();
            return context.Usuarios
                .Include(u => u.Persona)
                .Include(u => u.Grupo)
                    .ThenInclude(g => g.Permisos.Where(p => p.Habilitado))
                .FirstOrDefault(u => u.NombreUsuario == username && u.Habilitado);
        }
        public IEnumerable<Usuario> GetAll()
        {
            using var context = CreateContext();
            return context.Usuarios
                .Include(u => u.Persona)
                .Include(u => u.Grupo)
                    .ThenInclude(g => g.Permisos.Where(p => p.Habilitado))
                .ToList();
        }
        public void Add(Usuario usuario)
        {
            using var context = CreateContext();
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }
        public bool Update(Usuario usuario)
        {
            using var context = CreateContext();
            var existingUsuario = context.Usuarios.Find(usuario.Id);
            if (existingUsuario != null)
            {
                existingUsuario.SetNombreUsuario(usuario.NombreUsuario);
                if (!string.IsNullOrWhiteSpace(usuario.Clave))
                {
                    existingUsuario.SetClave(usuario.Clave);
                }
                existingUsuario.SetHabilitado(usuario.Habilitado);
                existingUsuario.SetIdPersona(usuario.IdPersona);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            using var context = CreateContext();
            var usuario = context.Usuarios.Find(id);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool NombreUsuarioExists(string nombreUsuario, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Usuarios.Where(u => u.NombreUsuario.ToLower() == nombreUsuario.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(u => u.Id != excludeId.Value);
            }
            return query.Any();
        }
        public bool PersonaExists(int idPersona)
        {
            using var context = CreateContext();
            return context.Personas.Any(p => p.IdPersona == idPersona);
        }
        public IEnumerable<Usuario> GetByCriteria(UsuarioCriteria criteria)
        {
            using var context = CreateContext();

            var query = context.Usuarios
                .Include(u => u.Persona)
                .Include(u => u.Grupo)
                    .ThenInclude(g => g.Permisos.Where(p => p.Habilitado))
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(criteria.Texto))
            {
                string searchTerm = criteria.Texto.ToLower();
                query = query.Where(u =>
                    u.NombreUsuario.ToLower().Contains(searchTerm) ||
                    (u.Persona != null &&
                        (u.Persona.Nombre.ToLower().Contains(searchTerm) ||
                         u.Persona.Apellido.ToLower().Contains(searchTerm) ||
                         u.Persona.Legajo.ToString().Contains(searchTerm)))
                );
            }

            return query.OrderBy(u => u.NombreUsuario).ToList();
        }
    }
}