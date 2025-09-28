using Academia.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PersonaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }
        public Persona? Get(int id)
        {
            using var context = CreateContext();
            return context.Personas
                .Include(p => p.Plan)
                .ThenInclude(p => p.Especialidad)
                .FirstOrDefault(p => p.IdPersona == id);
        }
        public IEnumerable<Persona> GetByTipoPersona(int tipoPersona)
        {
            using var context = CreateContext();
            return context.Personas
                .Include(p => p.Plan)
                .ThenInclude(p => p.Especialidad)
                .Where(p => p.TipoPersona == tipoPersona)
                .ToList();
        }
        public IEnumerable<Persona> GetAll()
        {
            using var context = CreateContext();
            return context.Personas
                .Include(p => p.Plan)
                .ThenInclude(p => p.Especialidad)
                .ToList();
        }
        public void Add(Persona persona)
        {
            using var context = CreateContext();
            context.Personas.Add(persona);
            context.SaveChanges();
        }
        public bool Update(Persona persona)
        {
            using var context = CreateContext();
            var existingPersona = context.Personas.Find(persona.IdPersona);
            if (existingPersona != null)
            {
                existingPersona.SetNombre(persona.Nombre);
                existingPersona.SetApellido(persona.Apellido);
                existingPersona.SetDireccion(persona.Direccion);
                existingPersona.SetEmail(persona.Email);
                existingPersona.SetTelefono(persona.Telefono);
                existingPersona.SetFechaNacimiento(persona.FechaNacimiento);
                existingPersona.SetLegajo(persona.Legajo);
                existingPersona.SetTipoPersona(persona.TipoPersona);
                existingPersona.SetIdPlan(persona.IdPlan);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            using var context = CreateContext();
            var persona = context.Personas.Find(id);
            if (persona != null)
            {
                context.Personas.Remove(persona);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public int CountUsuariosByPersona(int idPersona)
        {
            using var context = CreateContext();
            return context.Usuarios.Count(u => u.IdPersona == idPersona);
        }
        public bool EmailExists(string email, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Personas.Where(p => p.Email.ToLower() == email.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(p => p.IdPersona != excludeId.Value);
            }
            return query.Any();
        }
        public bool LegajoExists(int legajo, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Personas.Where(p => p.Legajo == legajo);
            if (excludeId.HasValue)
            {
                query = query.Where(p => p.IdPersona != excludeId.Value);
            }
            return query.Any();
        }
        public bool PlanExists(int idPlan)
        {
            using var context = CreateContext();
            return context.Planes.Any(p => p.IdPlan == idPlan);
        }
    }
}
