using Academia.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CursoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }
        public Curso? Get(int id)
        {
            using var context = CreateContext();
            return context.Cursos
                .Include(c => c.Comision)
                .Include(c => c.Materia)
                .FirstOrDefault(m => m.IdCurso == id);
        }
        public IEnumerable<Curso> GetAll()
        {
            using var context = CreateContext();
            return context.Cursos
                .Include(c => c.Comision)
                .Include(c => c.Materia)
                .ToList();
        }
        public void Add(Curso curso)
        {
            using var context = CreateContext();
            context.Cursos.Add(curso);
            context.SaveChanges();
        }
        public bool Update(Curso curso)
        {
            using var context = CreateContext();
            var existingCurso = context.Cursos.Find(curso.IdCurso);
            if (existingCurso != null)
            {
                existingCurso.SetAnioCalendario(curso.AnioCalendario);
                existingCurso.SetCupo(curso.Cupo);
                existingCurso.SetIdComision(curso.IdComision);
                existingCurso.SetIdMateria(curso.IdMateria);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            using var context = CreateContext();
            var curso = context.Cursos.Find(id);
            if (curso != null)
            {
                context.Cursos.Remove(curso);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool ComisionMateriaAndAnioCalendarioExist(int idComision, int idMateria, int anioCalendario, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Cursos
                .Where(c => c.AnioCalendario == anioCalendario && c.IdComision == idComision && c.IdMateria == idMateria);
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.IdCurso != excludeId.Value);
            }
            return query.Any();
        }
        public bool ComisionExists(int idComision)
        {
            using var context = CreateContext();
            return context.Comisiones.Any(c => c.IdComision == idComision);
        }
        public bool MateriaExists(int idMateria)
        {
            using var context = CreateContext();
            return context.Materias.Any(m => m.IdMateria == idMateria);
        }
    }
}
