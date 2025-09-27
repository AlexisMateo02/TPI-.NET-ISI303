using Data;
using DTOs;
using Academia.Entidades;

namespace Services
{
    public class PersonaService
    {
        public IEnumerable<PersonaDTO> GetAll()
        {
            var personaRepository = new PersonaRepository();
            var personas = personaRepository.GetAll();

            return personas.Select(persona => new PersonaDTO
            {
                IdPersona = persona.IdPersona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                Email = persona.Email,
                Telefono = persona.Telefono,
                FechaNacimiento = persona.FechaNacimiento,
                Legajo = persona.Legajo,
                TipoPersona = persona.TipoPersona,
                IdPlan = persona.IdPlan,
                DescripcionPlan = persona.Plan?.Descripcion,
                DescripcionEspecialidad = persona.Plan?.Especialidad?.Descripcion
            }).ToList();
        }
        public PersonaDTO Get(int id)
        {
            var personaRepository = new PersonaRepository();
            Persona? persona = personaRepository.Get(id);

            if (persona == null)
            {
                return null;
            }

            return new PersonaDTO
            {
                IdPersona = persona.IdPersona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                Email = persona.Email,
                Telefono = persona.Telefono,
                FechaNacimiento = persona.FechaNacimiento,
                Legajo = persona.Legajo,
                TipoPersona = persona.TipoPersona,
                IdPlan = persona.IdPlan,
                DescripcionPlan = persona.Plan?.Descripcion,
                DescripcionEspecialidad = persona.Plan?.Especialidad?.Descripcion
            };
        }
        public PersonaDTO Add(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();

            // Validar que existe el plan
            if (!personaRepository.PlanExists(dto.IdPlan))
            {
                throw new ArgumentException($"No existe el plan con ID {dto.IdPlan}");
            }

            // Validar que el email no esté duplicado
            if (personaRepository.EmailExists(dto.Email))
            {
                throw new ArgumentException($"Ya existe una persona con el email '{dto.Email}'");
            }

            // Validar que el legajo no esté duplicado
            if (personaRepository.LegajoExists(dto.Legajo))
            {
                throw new ArgumentException($"Ya existe una persona con el legajo '{dto.Legajo}'");
            }

            Persona persona = new Persona(dto.Nombre, dto.Apellido, dto.Direccion, dto.Email, dto.Telefono,
                dto.FechaNacimiento, dto.Legajo, dto.TipoPersona, dto.IdPlan);

            personaRepository.Add(persona);

            dto.IdPersona = persona.IdPersona;

            return dto;
        }
        public bool Update(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();

            // Validar que existe el plan
            if (!personaRepository.PlanExists(dto.IdPlan))
            {
                throw new ArgumentException($"No existe el plan con ID {dto.IdPlan}");
            }

            // Validar que el email no esté duplicado (excluyendo la persona actual)
            if (personaRepository.EmailExists(dto.Email, dto.IdPersona))
            {
                throw new ArgumentException($"Ya existe otra persona con el email '{dto.Email}'");
            }

            // Validar que el legajo no esté duplicado (excluyendo la persona actual)
            if (personaRepository.LegajoExists(dto.Legajo, dto.IdPersona))
            {
                throw new ArgumentException($"Ya existe otra persona con el legajo '{dto.Legajo}'");
            }

            Persona persona = new Persona(dto.IdPersona, dto.Nombre, dto.Apellido, dto.Direccion, dto.Email,
                dto.Telefono, dto.FechaNacimiento, dto.Legajo, dto.TipoPersona, dto.IdPlan);

            return personaRepository.Update(persona);
        }
        public bool Delete(int id)
        {
            var personaRepository = new PersonaRepository();
            var cantidadUsuarios = personaRepository.CountUsuariosByPersona(id);
            if (cantidadUsuarios > 0)
            {
                string mensaje = $"No se puede eliminar la persona. ";
                if (cantidadUsuarios == 1)
                {
                    mensaje += $"Tiene un usuario asociado.";
                }
                else
                {
                    mensaje += $"Tiene {cantidadUsuarios} planes asociados.";
                }
                throw new InvalidOperationException(mensaje);
            }
            return personaRepository.Delete(id);
        }

        // Métodos para validación desde formularios
        public bool ExistsEmail(string email, int? excludeId = null)
        {
            var personaRepository = new PersonaRepository();
            return personaRepository.EmailExists(email, excludeId);
        }

        public bool ExistsLegajo(int legajo, int? excludeId = null)
        {
            var personaRepository = new PersonaRepository();
            return personaRepository.LegajoExists(legajo, excludeId);
        }

        // Métodos específicos por tipo de persona
        public IEnumerable<PersonaDTO> GetAlumnos()
        {
            var personaRepository = new PersonaRepository();
            var alumnos = personaRepository.GetByTipoPersona(1); // Asumiendo 1 = Alumno

            return alumnos.Select(persona => new PersonaDTO
            {
                IdPersona = persona.IdPersona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                Email = persona.Email,
                Telefono = persona.Telefono,
                FechaNacimiento = persona.FechaNacimiento,
                Legajo = persona.Legajo,
                TipoPersona = persona.TipoPersona,
                IdPlan = persona.IdPlan,
                DescripcionPlan = persona.Plan?.Descripcion,
                DescripcionEspecialidad = persona.Plan?.Especialidad?.Descripcion
            }).ToList();
        }

        public IEnumerable<PersonaDTO> GetDocentes()
        {
            var personaRepository = new PersonaRepository();
            var docentes = personaRepository.GetByTipoPersona(2); // Asumiendo 2 = Docente

            return docentes.Select(persona => new PersonaDTO
            {
                IdPersona = persona.IdPersona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                Email = persona.Email,
                Telefono = persona.Telefono,
                FechaNacimiento = persona.FechaNacimiento,
                Legajo = persona.Legajo,
                TipoPersona = persona.TipoPersona,
                IdPlan = persona.IdPlan,
                DescripcionPlan = persona.Plan?.Descripcion,
                DescripcionEspecialidad = persona.Plan?.Especialidad?.Descripcion
            }).ToList();
        }
    }
}
