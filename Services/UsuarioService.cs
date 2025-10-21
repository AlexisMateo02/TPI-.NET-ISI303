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
                Rol = usuario.Rol,
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
                Rol = usuario.Rol,
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
                usuario = new Usuario(dto.NombreUsuario, dto.Clave, fechaAlta, dto.Rol, dto.IdPersona.Value);
            }
            else
            {
                usuario = new Usuario(dto.NombreUsuario, dto.Clave, fechaAlta, dto.Rol);
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

            // 1. Obtener usuario existente para validaciones
            var usuarioExistente = usuarioRepository.Get(dto.Id);
            if (usuarioExistente == null)
                return false;

            // 2. Validar nombre de usuario duplicado (excluyendo el actual)
            if (usuarioRepository.NombreUsuarioExists(dto.NombreUsuario, dto.Id))
            {
                throw new ArgumentException($"Ya existe otro usuario con el nombre '{dto.NombreUsuario}'.");
            }

            // 3. Validar que existe la persona (si se proporciona)
            if (dto.IdPersona.HasValue && !usuarioRepository.PersonaExists(dto.IdPersona.Value))
            {
                throw new ArgumentException($"No existe la persona con el ID {dto.IdPersona.Value}");
            }

            // 4. Decidir qué método del repositorio usar
            bool resultado;

            if (!string.IsNullOrWhiteSpace(dto.Clave))
            {
                // ✅ Hay nueva contraseña: usar método que actualiza contraseña
                resultado = usuarioRepository.UpdateConNuevaContrasenia(
                    dto.Id,
                    dto.NombreUsuario,
                    dto.Habilitado,
                    dto.Rol,
                    dto.IdPersona,
                    dto.Clave // ← TEXTO PLANO desde el formulario
                );
            }
            else
            {
                // ✅ NO hay nueva contraseña: crear objeto Usuario SIN tocar Clave
                var usuarioParaActualizar = new Usuario(
                    dto.Id,
                    dto.NombreUsuario,
                    usuarioExistente.Clave, // ← Hash viejo (NO se usará en Update)
                    dto.Habilitado,
                    usuarioExistente.FechaAlta,
                    dto.Rol
                );

                if (dto.IdPersona.HasValue)
                {
                    usuarioParaActualizar.SetIdPersona(dto.IdPersona.Value);
                }

                resultado = usuarioRepository.Update(usuarioParaActualizar);
            }

            return resultado;
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
                Rol = u.Rol,
                IdPersona = u.IdPersona,
                Legajo = u.Persona?.Legajo,
                NombrePersona = u.Persona?.Nombre,
                ApellidoPersona = u.Persona?.Apellido
            });
        }

        public bool CambiarContrasenia(int idUsuario, string claveActual, string nuevaClave)
        {
            var usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.Get(idUsuario);

            if (usuario == null)
                return false;

            if (!usuario.ValidateClave(claveActual))
                throw new ArgumentException("La contraseña actual es incorrecta.");

            return usuarioRepository.CambiarContrasenia(idUsuario, nuevaClave);
        }
    }
}
