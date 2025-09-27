using Academia.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

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
            const string sql = @"
                SELECT 
                    u.Id, 
                    u.NombreUsuario, 
                    u.Clave, 
                    u.Habilitado, 
                    u.FechaAlta,
                    u.IdPersona,
                    p.Legajo,
                    p.Nombre,
                    p.Apellido
                FROM Usuarios u
                LEFT JOIN Personas p ON u.IdPersona = p.IdPersona
                WHERE u.NombreUsuario LIKE @SearchTerm
                ORDER BY u.NombreUsuario";

            var usuarios = new List<Usuario>();
            string connectionString = new TPIContext().Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Usuario usuario;
                if (!reader.IsDBNull(5)) // IdPersona
                {
                    int idPersona = reader.GetInt32(5);
                    usuario = new Usuario(
                        reader.GetInt32(0),    // Id
                        reader.GetString(1),   // NombreUsuario  
                        reader.GetString(2),   // Clave
                        reader.GetBoolean(3),  // Habilitado
                        reader.GetDateTime(4), // FechaAlta
                        idPersona              // IdPersona
                    );
                }
                else
                {
                    usuario = new Usuario(
                        reader.GetInt32(0),    // Id
                        reader.GetString(1),   // NombreUsuario
                        reader.GetString(2),   // Clave
                        reader.GetBoolean(3),  // Habilitado
                        reader.GetDateTime(4)  // FechaAlta
                    );
                }
                usuarios.Add(usuario);
            }

            return usuarios;
        }
    }
}