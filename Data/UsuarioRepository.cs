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
        public void Add(Usuario usuario)
        {
            using var context = CreateContext();
            context.Usuarios.Add(usuario);
            context.SaveChanges();
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
        public Usuario? Get(int id)
        {
            using var context = CreateContext();
            return context.Usuarios
                .FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<Usuario> GetAll()
        {
            using var context = CreateContext();
            return context.Usuarios
                .ToList();
        }
        public bool Update(Usuario usuario)
        {
            using var context = CreateContext();
            var existingUsuario = context.Usuarios.Find(usuario.Id);
            if (existingUsuario != null)
            {
                existingUsuario.SetNombre(usuario.Nombre);
                existingUsuario.SetClave(usuario.Clave);
                existingUsuario.SetHabilitado(usuario.Habilitado);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool NombreExists(string nombre, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Usuarios.Where(u => u.Nombre.ToLower() == nombre.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(u => u.Id != excludeId.Value);
            }
            return query.Any();
        }
        public IEnumerable<Usuario> GetByCriteria(UsuarioCriteria criteria)
        {
            const string sql = @"
                SELECT u.Id, u.Nombre, u.Clave, u.Habilitado, u.FechaAlta
                FROM Usuarios u
                WHERE u.Nombre LIKE @SearchTerm
                ORDER BY u.Nombre";

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
                var usuario = new Usuario(
                    reader.GetInt32(0),    // Id
                    reader.GetString(1),   // Nombre
                    reader.GetString(2),   // Clave
                    reader.GetBoolean(3),   // Habilitado
                    reader.GetDateTime(4)  // FechaAlta
                );

                usuarios.Add(usuario);
            }

            return usuarios;
        }
    }
}