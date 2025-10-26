using Data;
using DTOs;
using Academia.Entidades;

namespace Services
{
    public class DocenteCursoService
    {
        public IEnumerable<DocenteCursoDTO> GetAll()
        {
            var docenteCursoRepository = new DocenteCursoRepository();
            var docenteCursos = docenteCursoRepository.GetAll();

            return docenteCursos.Select(dc => new DocenteCursoDTO
            {
                IdDictado = dc.IdDictado,
                Cargo = dc.Cargo,
                IdDocente = dc.IdDocente,
                Legajo = dc.Docente?.Legajo,
                NombrePersona = dc.Docente?.Nombre,
                ApellidoPersona = dc.Docente?.Apellido,
                IdCurso = dc.IdCurso,
                AnioCalendario = dc.Curso?.AnioCalendario,
                IdComision = dc.Curso?.IdComision,
                DescripcionComision = dc.Curso?.Comision?.DescripcionComision,
                IdMateria = dc.Curso?.IdMateria,
                DescripcionMateria = dc.Curso?.Materia?.DescripcionMateria
            }).ToList();
        }

        public DocenteCursoDTO Get(int id)
        {
            var docenteCursoRepository = new DocenteCursoRepository();
            DocenteCurso? docenteCurso = docenteCursoRepository.Get(id);

            if (docenteCurso == null)
            {
                return null;
            }

            return new DocenteCursoDTO
            {
                IdDictado = docenteCurso.IdDictado,
                Cargo = docenteCurso.Cargo,
                IdDocente = docenteCurso.IdDocente,
                Legajo = docenteCurso.Docente?.Legajo,
                NombrePersona = docenteCurso.Docente?.Nombre,
                ApellidoPersona = docenteCurso.Docente?.Apellido,
                IdCurso = docenteCurso.IdCurso,
                AnioCalendario = docenteCurso.Curso?.AnioCalendario,
                IdComision = docenteCurso.Curso?.IdComision,
                DescripcionComision = docenteCurso.Curso?.Comision?.DescripcionComision,
                IdMateria = docenteCurso.Curso?.IdMateria,
                DescripcionMateria = docenteCurso.Curso?.Materia?.DescripcionMateria
            };
        }

        public DocenteCursoDTO Add(DocenteCursoDTO dto)
        {
            var docenteCursoRepository = new DocenteCursoRepository();

            // Validar que existe el docente y es tipo docente
            if (!docenteCursoRepository.DocenteExists(dto.IdDocente))
            {
                throw new ArgumentException($"No existe un docente con ID {dto.IdDocente}");
            }

            // Validar que existe el curso
            if (!docenteCursoRepository.CursoExists(dto.IdCurso))
            {
                throw new ArgumentException($"No existe el curso con ID {dto.IdCurso}");
            }

            // Validar que solo haya un titular por curso
            if (dto.Cargo.ToLower() == "titular" && docenteCursoRepository.TitularExistsInCurso(dto.IdCurso))
            {
                throw new ArgumentException($"Ya existe un docente titular en el curso ID {dto.IdCurso}. Solo puede haber un titular por curso.");
            }

            // Validar que no esté duplicado (mismo docente, curso y cargo)
            if (docenteCursoRepository.DocenteCursoExists(dto.IdDocente, dto.IdCurso))
            {
                throw new ArgumentException($"Ya existe un dictado con el docente ID {dto.IdDocente} y " +
                    $"el curso ID {dto.IdCurso}");
            }

            DocenteCurso docenteCurso = new DocenteCurso(dto.Cargo, dto.IdDocente, dto.IdCurso);

            docenteCursoRepository.Add(docenteCurso);

            dto.IdDictado = docenteCurso.IdDictado;

            return dto;
        }

        public bool Update(DocenteCursoDTO dto)
        {
            var docenteCursoRepository = new DocenteCursoRepository();

            // Validar que existe el docente y es tipo docente
            if (!docenteCursoRepository.DocenteExists(dto.IdDocente))
            {
                throw new ArgumentException($"No existe un docente con ID {dto.IdDocente}");
            }

            // Validar que existe el curso
            if (!docenteCursoRepository.CursoExists(dto.IdCurso))
            {
                throw new ArgumentException($"No existe el curso con ID {dto.IdCurso}");
            }

            // Validar que solo haya un titular por curso
            if (dto.Cargo.ToLower() == "titular" && docenteCursoRepository.TitularExistsInCurso(dto.IdCurso))
            {
                throw new ArgumentException($"Ya existe un docente titular en el curso ID {dto.IdCurso}. Solo puede haber un titular por curso.");
            }

            // Validar que no esté duplicado (excluyendo el dictado actual)
            if (docenteCursoRepository.DocenteCursoExists(dto.IdDocente, dto.IdCurso, dto.IdDictado))
            {
                throw new ArgumentException($"Ya existe otro dictado con el docente ID {dto.IdDocente} y " +
                    $"el curso ID {dto.IdCurso}");
            }

            DocenteCurso docenteCurso = new DocenteCurso(dto.IdDictado, dto.Cargo, dto.IdDocente, dto.IdCurso);

            return docenteCursoRepository.Update(docenteCurso);
        }

        public bool Delete(int id)
        {
            var docenteCursoRepository = new DocenteCursoRepository();
            return docenteCursoRepository.Delete(id);
        }

        public bool ExistsDocenteCurso(int idDocente, int idCurso, int? excludeId = null)
        {
            var docenteCursoRepository = new DocenteCursoRepository();
            return docenteCursoRepository.DocenteCursoExists(idDocente, idCurso, excludeId);
        }
    }
}
