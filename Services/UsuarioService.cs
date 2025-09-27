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
                NombreUsuario = usuario.NombreUsuario,
                Clave = usuario.Clave,
                Habilitado = usuario.Habilitado,
                FechaAlta = usuario.FechaAlta,
                IdPersona = usuario.IdPersona,
                Legajo = usuario.Persona?.Legajo,
                NombrePersona = usuario.Persona?.Nombre,
                ApellidoPersona = usuario.Persona?.Apellido
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
                NombreUsuario = usuario.NombreUsuario,
                Clave = usuario.Clave,
                Habilitado = usuario.Habilitado,
                FechaAlta = usuario.FechaAlta,
                IdPersona = usuario.IdPersona,
                Legajo = usuario.Persona?.Legajo,
                NombrePersona = usuario.Persona?.Nombre,
                ApellidoPersona = usuario.Persona?.Apellido
            };
        }

        public UsuarioDTO Add(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            // Validar que el nombre de usuario no esté duplicado
            if (usuarioRepository.NombreUsuarioExists(dto.NombreUsuario))
            {
                throw new ArgumentException($"Ya existe un usuario con el nombre '{dto.NombreUsuario}'.");
            }

            // Validar que existe la persona
            if (dto.IdPersona.HasValue && !usuarioRepository.PersonaExists(dto.IdPersona.Value))
            {
                throw new ArgumentException($"No existe la persona con el ID {dto.IdPersona.Value}");
            }

            var fechaAlta = DateTime.Now;
            Usuario usuario;
            if (dto.IdPersona.HasValue)
            {
                usuario = new Usuario(dto.NombreUsuario, dto.Clave, fechaAlta, dto.IdPersona.Value);
            }
            else
            {
                usuario = new Usuario(dto.NombreUsuario, dto.Clave, fechaAlta);
            }

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
            if (usuarioRepository.NombreUsuarioExists(dto.NombreUsuario, dto.Id))
            {
                throw new ArgumentException($"Ya existe otro usuario con el nombre '{dto.NombreUsuario}'.");
            }

            // Validar que existe la persona
            if (dto.IdPersona.HasValue && !usuarioRepository.PersonaExists(dto.IdPersona.Value))
            {
                throw new ArgumentException($"No existe la persona con el ID {dto.IdPersona.Value}");
            }

            Usuario usuario;
            if (dto.IdPersona.HasValue)
                usuario = new Usuario(dto.Id, dto.NombreUsuario, dto.Clave, dto.Habilitado, dto.FechaAlta, dto.IdPersona.Value);
            else
                usuario = new Usuario(dto.Id, dto.NombreUsuario, dto.Clave, dto.Habilitado, dto.FechaAlta);

            return usuarioRepository.Update(usuario);
        }

        public bool Delete(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            return usuarioRepository.Delete(id);
        }
        // Método para validación desde Forms
        public bool ExistsNombreUsuario(string nombreUsuario, int? excludeId = null)
        {
            var usuarioRepository = new UsuarioRepository();
            return usuarioRepository.NombreUsuarioExists(nombreUsuario, excludeId);
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
                NombreUsuario = u.NombreUsuario,
                Clave = u.Clave,
                Habilitado = u.Habilitado,
                FechaAlta = u.FechaAlta,
                IdPersona = u.IdPersona,
                Legajo = u.Persona?.Legajo,
                NombrePersona = u.Persona?.Nombre,
                ApellidoPersona = u.Persona?.Apellido
            });
        }
    }
}
