using Academia.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MateriaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }
        public Materia? Get(int id)
        {
            using var context = CreateContext();
            return context.Materias
                .Include(m => m.Plan)
                .ThenInclude(m => m.Especialidad)
                .FirstOrDefault(m => m.IdMateria == id);
        }
        public IEnumerable<Materia> GetAll()
        {
            using var context = CreateContext();
            return context.Materias
                .Include(m => m.Plan)
                .ThenInclude(m => m.Especialidad)
                .ToList();
        }
        public void Add(Materia materia)
        {
            using var context = CreateContext();
            context.Materias.Add(materia);
            context.SaveChanges();
        }
        public bool Update(Materia materia)
        {
            using var context = CreateContext();
            var existingMateria = context.Materias.Find(materia.IdMateria);
            if (existingMateria != null)
            {
                existingMateria.SetDescripcionMateria(materia.DescripcionMateria);
                existingMateria.SetHorasSemanales(materia.HorasSemanales);
                existingMateria.SetHorasTotales(materia.HorasTotales);
                existingMateria.SetIdPlan(materia.IdPlan);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            using var context = CreateContext();
            var materia = context.Materias.Find(id);
            if (materia != null)
            {
                context.Materias.Remove(materia);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public int CountCursosByMateria(int idMateria)
        {
            using var context = CreateContext();
            return context.Cursos.Count(c => c.IdMateria == idMateria);
        }
        public bool PlanAndDescripcionMateriaExist(int idPlan, string descripcionMateria, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Materias
                .Where(m => m.DescripcionMateria.ToLower() == descripcionMateria.ToLower() && m.IdPlan == idPlan);
            if (excludeId.HasValue)
            {
                query = query.Where(m => m.IdMateria != excludeId.Value);
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
