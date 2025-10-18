using Data;
using DTOs;
using Academia.Entidades;

namespace Services
{
    public class AlumnoInscripcionService
    {
        public IEnumerable<AlumnoInscripcionDTO> GetAll()
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            var alumnoInscripciones = alumnoInscripcionRepository.GetAll();

            return alumnoInscripciones.Select(ai => new AlumnoInscripcionDTO
            {
                IdInscripcion = ai.IdInscripcion,
                Condicion = ai.Condicion,
                Nota = ai.Nota,
                IdAlumno = ai.IdAlumno,
                Legajo = ai.Alumno?.Legajo,
                NombrePersona = ai.Alumno?.Nombre,
                ApellidoPersona = ai.Alumno?.Apellido,
                IdCurso = ai.IdCurso,
                AnioCalendario = ai.Curso?.AnioCalendario,
                IdComision = ai.Curso?.IdComision,
                DescripcionComision = ai.Curso?.Comision?.DescripcionComision,
                IdMateria = ai.Curso?.IdMateria,
                DescripcionMateria = ai.Curso?.Materia?.DescripcionMateria
            }).ToList();
        }

        public AlumnoInscripcionDTO Get(int id)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            AlumnoInscripcion? alumnoInscripcion = alumnoInscripcionRepository.Get(id);

            if (alumnoInscripcion == null)
            {
                return null;
            }

            return new AlumnoInscripcionDTO
            {
                IdInscripcion = alumnoInscripcion.IdInscripcion,
                Condicion = alumnoInscripcion.Condicion,
                Nota = alumnoInscripcion.Nota,
                IdAlumno = alumnoInscripcion.IdAlumno,
                Legajo = alumnoInscripcion.Alumno?.Legajo,
                NombrePersona = alumnoInscripcion.Alumno?.Nombre,
                ApellidoPersona = alumnoInscripcion.Alumno?.Apellido,
                IdCurso = alumnoInscripcion.IdCurso,
                AnioCalendario = alumnoInscripcion.Curso?.AnioCalendario,
                IdComision = alumnoInscripcion.Curso?.IdComision,
                DescripcionComision = alumnoInscripcion.Curso?.Comision?.DescripcionComision,
                IdMateria = alumnoInscripcion.Curso?.IdMateria,
                DescripcionMateria = alumnoInscripcion.Curso?.Materia?.DescripcionMateria
            };
        }

        public AlumnoInscripcionDTO Add(AlumnoInscripcionDTO dto)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();

            // Validar que existe el alumno y es tipo alumno
            if (!alumnoInscripcionRepository.AlumnoExists(dto.IdAlumno))
            {
                throw new ArgumentException($"No existe un alumno con ID {dto.IdAlumno}");
            }

            // Validar que existe el curso
            if (!alumnoInscripcionRepository.CursoExists(dto.IdCurso))
            {
                throw new ArgumentException($"No existe el curso con ID {dto.IdCurso}");
            }

            // Validar que no esté duplicado (mismo alumno y curso)
            if (alumnoInscripcionRepository.AlumnoCursoExists(dto.IdAlumno, dto.IdCurso))
            {
                throw new ArgumentException($"Ya existe una inscripción del alumno ID {dto.IdAlumno} " +
                    $"al curso ID {dto.IdCurso}");
            }

            AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion(dto.Condicion, dto.Nota, dto.IdAlumno, dto.IdCurso);

            alumnoInscripcionRepository.Add(alumnoInscripcion);

            dto.IdInscripcion = alumnoInscripcion.IdInscripcion;

            return dto;
        }

        public bool Update(AlumnoInscripcionDTO dto)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();

            // Validar que existe el alumno y es tipo alumno
            if (!alumnoInscripcionRepository.AlumnoExists(dto.IdAlumno))
            {
                throw new ArgumentException($"No existe un alumno con ID {dto.IdAlumno}");
            }

            // Validar que existe el curso
            if (!alumnoInscripcionRepository.CursoExists(dto.IdCurso))
            {
                throw new ArgumentException($"No existe el curso con ID {dto.IdCurso}");
            }

            // Validar que no esté duplicado (excluyendo la inscripción actual)
            if (alumnoInscripcionRepository.AlumnoCursoExists(dto.IdAlumno, dto.IdCurso, dto.IdInscripcion))
            {
                throw new ArgumentException($"Ya existe otra inscripción del alumno ID {dto.IdAlumno} " +
                    $"al curso ID {dto.IdCurso}");
            }

            AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion(dto.IdInscripcion, dto.Condicion, dto.Nota, dto.IdAlumno, dto.IdCurso);

            return alumnoInscripcionRepository.Update(alumnoInscripcion);
        }

        public bool Delete(int id)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            return alumnoInscripcionRepository.Delete(id);
        }

        public bool ExistsAlumnoCurso(int idAlumno, int idCurso, int? excludeId = null)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            return alumnoInscripcionRepository.AlumnoCursoExists(idAlumno, idCurso, excludeId);
        }
    }
}
