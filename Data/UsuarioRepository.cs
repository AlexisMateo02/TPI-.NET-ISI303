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
                .FirstOrDefault(u => u.Id == id);
        }
        public Usuario? GetByUsername(string username)
        {
            using var context = CreateContext();
            return context.Usuarios
                .Include(u => u.Persona)
                .FirstOrDefault(u => u.NombreUsuario == username && u.Habilitado);
        }
        public IEnumerable<Usuario> GetAll()
        {
            using var context = CreateContext();
            return context.Usuarios
                .Include(u => u.Persona)
                .ToList();
        }
        public void Add(Usuario usuario)
        {
            using var context = CreateContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public bool Update(Usuario usuario)
        {
            using var context = CreateContext();
            var existingUsuario = context.Usuarios.Find(usuario.Id);

            if (existingUsuario != null)
            {
                // ⚠️ SOLO actualizar campos NO sensibles
                existingUsuario.SetNombreUsuario(usuario.NombreUsuario);
                existingUsuario.SetHabilitado(usuario.Habilitado);
                existingUsuario.SetRol(usuario.Rol);
                existingUsuario.SetIdPersona(usuario.IdPersona);

                // ❌ NUNCA actualizar Clave aquí
                // ❌ NO hacer: existingUsuario.SetClave(usuario.Clave);

                context.SaveChanges();
                return true;
            }

            return false;
        }

        // Método SEPARADO para actualizar con nueva contraseña
        public bool UpdateConNuevaContrasenia(int idUsuario, string nombreUsuario, bool habilitado, int rol, int? idPersona, string nuevaClaveTextoPlano)
        {
            using var context = CreateContext();
            var existingUsuario = context.Usuarios.Find(idUsuario);

            if (existingUsuario != null)
            {
                existingUsuario.SetNombreUsuario(nombreUsuario);
                existingUsuario.SetHabilitado(habilitado);
                existingUsuario.SetRol(rol);
                existingUsuario.SetIdPersona(idPersona);

                // ✅ SOLO llamar a SetClave con TEXTO PLANO
                existingUsuario.SetClave(nuevaClaveTextoPlano);

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
        public Usuario? ComprobarUsuarioIngresado(string nombreUsuario, string clave)
        {
            using var context = CreateContext();
            var usuario = context.Usuarios
                .Include(u => u.Persona)
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Habilitado);

            if (usuario != null && usuario.ValidateClave(clave))
            {
                return usuario;
            }
            return null;
        }

        public bool CambiarContrasenia(int idUsuario, string nuevaClave)
        {
            using var context = CreateContext();

            var existingUsuario = context.Usuarios.Find(idUsuario);
            if (existingUsuario == null)
                return false;

            // Actualiza directamente la nueva contraseña (SetClave genera salt + hash)
            existingUsuario.SetClave(nuevaClave);

            context.SaveChanges();
            return true;
        }

    }
}