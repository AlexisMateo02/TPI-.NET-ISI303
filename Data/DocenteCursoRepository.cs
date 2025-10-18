using Academia.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DocenteCursoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public DocenteCurso? Get(int id)
        {
            using var context = CreateContext();
            return context.Dictados
                .Include(dc => dc.Docente)
                .Include(dc => dc.Curso)
                    .ThenInclude(c => c.Comision)
                .Include(dc => dc.Curso)
                    .ThenInclude(c => c.Materia)
                .FirstOrDefault(dc => dc.IdDictado == id);
        }

        public IEnumerable<DocenteCurso> GetAll()
        {
            using var context = CreateContext();
            return context.Dictados
                .Include(dc => dc.Docente)
                .Include(dc => dc.Curso)
                    .ThenInclude(c => c.Comision)
                .Include(dc => dc.Curso)
                    .ThenInclude(c => c.Materia)
                .ToList();
        }

        public void Add(DocenteCurso docenteCurso)
        {
            using var context = CreateContext();
            context.Dictados.Add(docenteCurso);
            context.SaveChanges();
        }

        public bool Update(DocenteCurso docenteCurso)
        {
            using var context = CreateContext();
            var existingDocenteCurso = context.Dictados.Find(docenteCurso.IdDictado);
            if (existingDocenteCurso != null)
            {
                existingDocenteCurso.SetCargo(docenteCurso.Cargo);
                existingDocenteCurso.SetIdDocente(docenteCurso.IdDocente);
                existingDocenteCurso.SetIdCurso(docenteCurso.IdCurso);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var docenteCurso = context.Dictados.Find(id);
            if (docenteCurso != null)
            {
                context.Dictados.Remove(docenteCurso);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DocenteCursoCargoExists(int idDocente, int idCurso, string cargo, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Dictados
                .Where(dc => dc.IdDocente == idDocente
                          && dc.IdCurso == idCurso
                          && dc.Cargo.ToLower() == cargo.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(dc => dc.IdDictado != excludeId.Value);
            }
            return query.Any();
        }

        public bool DocenteExists(int idDocente)
        {
            using var context = CreateContext();
            return context.Personas.Any(p => p.IdPersona == idDocente && p.TipoPersona == 2);
        }

        public bool CursoExists(int idCurso)
        {
            using var context = CreateContext();
            return context.Cursos.Any(c => c.IdCurso == idCurso);
        }
    }
}
