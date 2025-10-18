using Academia.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AlumnoInscripcionRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public AlumnoInscripcion? Get(int id)
        {
            using var context = CreateContext();
            return context.AlumnoInscripciones
                .Include(ai => ai.Alumno)
                .Include(ai => ai.Curso)
                    .ThenInclude(c => c.Comision)
                .Include(ai => ai.Curso)
                    .ThenInclude(c => c.Materia)
                .FirstOrDefault(ai => ai.IdInscripcion == id);
        }

        public IEnumerable<AlumnoInscripcion> GetAll()
        {
            using var context = CreateContext();
            return context.AlumnoInscripciones
                .Include(ai => ai.Alumno)
                .Include(ai => ai.Curso)
                    .ThenInclude(c => c.Comision)
                .Include(ai => ai.Curso)
                    .ThenInclude(c => c.Materia)
                .ToList();
        }

        public void Add(AlumnoInscripcion alumnoInscripcion)
        {
            using var context = CreateContext();
            context.AlumnoInscripciones.Add(alumnoInscripcion);
            context.SaveChanges();
        }

        public bool Update(AlumnoInscripcion alumnoInscripcion)
        {
            using var context = CreateContext();
            var existingAlumnoInscripcion = context.AlumnoInscripciones.Find(alumnoInscripcion.IdInscripcion);
            if (existingAlumnoInscripcion != null)
            {
                existingAlumnoInscripcion.SetCondicion(alumnoInscripcion.Condicion);
                existingAlumnoInscripcion.SetNota(alumnoInscripcion.Nota);
                existingAlumnoInscripcion.SetIdAlumno(alumnoInscripcion.IdAlumno);
                existingAlumnoInscripcion.SetIdCurso(alumnoInscripcion.IdCurso);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var alumnoInscripcion = context.AlumnoInscripciones.Find(id);
            if (alumnoInscripcion != null)
            {
                context.AlumnoInscripciones.Remove(alumnoInscripcion);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AlumnoCursoExists(int idAlumno, int idCurso, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.AlumnoInscripciones
                .Where(ai => ai.IdAlumno == idAlumno && ai.IdCurso == idCurso);
            if (excludeId.HasValue)
            {
                query = query.Where(ai => ai.IdInscripcion != excludeId.Value);
            }
            return query.Any();
        }

        public bool AlumnoExists(int idAlumno)
        {
            using var context = CreateContext();
            return context.Personas.Any(p => p.IdPersona == idAlumno && p.TipoPersona == 1);
        }

        public bool CursoExists(int idCurso)
        {
            using var context = CreateContext();
            return context.Cursos.Any(c => c.IdCurso == idCurso);
        }
    }
}
