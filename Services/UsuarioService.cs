using Data;
using DTOs;
using Academia.Entidades;


namespace Services
{
    public class UsuarioService
    {
        public IEnumerable<UsuarioDTO> GetAll()
        {
            var usuarioRepository = new UsuarioRepository();
            var usuarios = usuarioRepository.GetAll();

            return usuarios.Select(usuario => new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Clave = usuario.Clave,
                Habilitado = usuario.Habilitado,
                FechaAlta = usuario.FechaAlta
            }).ToList();
        }

        public UsuarioDTO Get(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            Usuario? usuario = usuarioRepository.Get(id);

            if (usuario == null)
                return null;

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Clave = usuario.Clave,
                Habilitado = usuario.Habilitado,
                FechaAlta = usuario.FechaAlta
            };
        }

        public UsuarioDTO Add(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            // Validar que el nombre de usuario no esté duplicado
            if (usuarioRepository.NombreExists(dto.Nombre))
            {
                throw new ArgumentException($"Ya existe un usuario con el nombre '{dto.Nombre}'.");
            }

            var fechaAlta = DateTime.Now;
            Usuario usuario = new Usuario(dto.Nombre, dto.Clave, fechaAlta);

            usuarioRepository.Add(usuario);

            dto.Id = usuario.Id;
            dto.FechaAlta = usuario.FechaAlta;
            dto.Habilitado = usuario.Habilitado;

            return dto;
        }

        public bool Update(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            // Validar que el nombre de usuario no esté duplicado (excluyendo el usuario actual)
            if (usuarioRepository.NombreExists(dto.Nombre, dto.Id))
            {
                throw new ArgumentException($"Ya existe otro usuario con el nombre '{dto.Nombre}'.");
            }

            Usuario usuario = new Usuario(dto.Id, dto.Nombre, dto.Clave, dto.Habilitado, dto.FechaAlta);
            return usuarioRepository.Update(usuario);
        }

        public bool Delete(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            return usuarioRepository.Delete(id);
        }
        // Método para validación desde Forms
        public bool ExistsNombre(string nombre, int? excludeId = null)
        {
            var usuarioRepository = new UsuarioRepository();
            return usuarioRepository.NombreExists(nombre, excludeId);
        }

        public IEnumerable<UsuarioDTO> GetByCriteria(UsuarioCriteriaDTO criteriaDTO)
        {
            var usuarioRepository = new UsuarioRepository();

            // Mapear DTO a Entidades
            var criteria = new UsuarioCriteria(criteriaDTO.Texto);

            // Llamar al repositorio
            var usuarios = usuarioRepository.GetByCriteria(criteria);

            // Mapear Entidades a DTO
            return usuarios.Select(u => new UsuarioDTO
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Clave = u.Clave,
                Habilitado = u.Habilitado,
                FechaAlta = u.FechaAlta
            });
        }
    }
}
