using Academia.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PlanRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }
        public IEnumerable<Plan> GetAll()
        {
            using var context = CreateContext();
            return context.Planes
                .Include(e => e.Especialidad)
                .ToList();
        }
        public Plan? Get(int id)
        {
            using var context = CreateContext();
            return context.Planes
                .Include(e => e.Especialidad)
                .FirstOrDefault(e => e.IdPlan == id);
        }
        public void Add(Plan plan)
        {
            using var context = CreateContext();
            context.Planes.Add(plan);
            context.SaveChanges();
        }
        public bool Update(Plan plan)
        {
            using var context = CreateContext();
            var existingPlan = context.Planes.Find(plan.IdPlan);
            if (existingPlan != null)
            {
                existingPlan.SetDescripcion(plan.Descripcion);
                existingPlan.SetIdEspecialidad(plan.IdEspecialidad);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            using var context = CreateContext();
            var plan = context.Planes.Find(id);
            if (plan != null)
            {
                context.Planes.Remove(plan);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public int CountPersonasByPlan(int idPlan)
        {
            using var context = CreateContext();
            return context.Personas.Count(p => p.IdPlan == idPlan);
        }
        public int CountComisionesByPlan(int idPlan)
        {
            using var context = CreateContext();
            return context.Comisiones.Count(c => c.IdPlan == idPlan);
        }
        public int CountMateriasByPlan(int idPlan)
        {
            using var context = CreateContext();
            return context.Materias.Count(m => m.IdPlan == idPlan);
        }
        public bool DescripcionExistsInEspecialidad(string descripcion, int idEspecialidad, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Planes
                .Where(p => p.Descripcion.ToLower() == descripcion.ToLower()
                            && p.IdEspecialidad == idEspecialidad);
            if (excludeId.HasValue)
            {
                query = query.Where(p => p.IdPlan != excludeId.Value);
            }
            return query.Any();
        }
        public bool EspecialidadExists(int idEspecialidad)
        {
            using var context = CreateContext();
            return context.Especialidades.Any(e => e.Id == idEspecialidad);
        }
    }
}
