using Academia.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ComisionRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }
        public Comision? Get(int id)
        {
            using var context = CreateContext();
            return context.Comisiones
                .Include(p => p.Plan)
                .ThenInclude(p => p.Especialidad)
                .FirstOrDefault(c => c.IdComision == id);
        }
        public IEnumerable<Comision> GetAll()
        {
            using var context = CreateContext();
            return context.Comisiones
                .Include(p => p.Plan)
                .ThenInclude(p => p.Especialidad)
                .ToList();
        }
        public void Add(Comision comision)
        {
            using var context = CreateContext();
            context.Comisiones.Add(comision);
            context.SaveChanges();
        }
        public bool Update(Comision comision)
        {
            using var context = CreateContext();
            var existingComision = context.Comisiones.Find(comision.IdComision);
            if (existingComision != null)
            {
                existingComision.SetDescripcionComision(comision.DescripcionComision);
                existingComision.SetAnioEspecialidad(comision.AnioEspecialidad);
                existingComision.SetIdPlan(comision.IdPlan);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            using var context = CreateContext();
            var comision = context.Comisiones.Find(id);
            if (comision != null)
            {
                context.Comisiones.Remove(comision);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool PlanAndAnioEspecialidadExist(int anioEspecialidad, int idPlan, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Comisiones.Where(c => c.AnioEspecialidad == anioEspecialidad && c.IdPlan == idPlan);
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.IdComision != excludeId.Value);
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
