using Data;
using DTOs;
using Academia.Entidades;

namespace Services
{
    public class CursoService
    {
        public IEnumerable<CursoDTO> GetAll()
        {
            var cursoRepository = new CursoRepository();
            var cursos = cursoRepository.GetAll();

            return cursos.Select(curso => new CursoDTO
            {
                IdCurso = curso.IdCurso,
                AnioCalendario = curso.AnioCalendario,
                Cupo = curso.Cupo,
                IdComision = curso.IdComision,
                DescripcionComision = curso.Comision?.DescripcionComision,
                IdMateria = curso.IdMateria,
                DescripcionMateria = curso.Materia?.DescripcionMateria,
            }).ToList();
        }
        public CursoDTO Get(int id)
        {
            var cursoRepository = new CursoRepository();
            Curso? curso = cursoRepository.Get(id);

            if (curso == null)
            {
                return null;
            }

            return new CursoDTO
            {
                IdCurso = curso.IdCurso,
                AnioCalendario = curso.AnioCalendario,
                Cupo = curso.Cupo,
                IdComision = curso.IdComision,
                DescripcionComision = curso.Comision?.DescripcionComision,
                IdMateria = curso.IdMateria,
                DescripcionMateria = curso.Materia?.DescripcionMateria,
            };
        }
        public CursoDTO Add(CursoDTO dto)
        {
            var cursoRepository = new CursoRepository();

            // Validar que existe la comisión
            if (!cursoRepository.ComisionExists(dto.IdComision))
            {
                throw new ArgumentException($"No existe la comisión con ID {dto.IdComision}");
            }

            // Validar que existe la materia
            if (!cursoRepository.MateriaExists(dto.IdMateria))
            {
                throw new ArgumentException($"No existe la materia con ID {dto.IdMateria}");
            }

            // Validar que un año de calendario, una comisión y una materia no estén duplicados
            if (cursoRepository.ComisionMateriaAndAnioCalendarioExist(dto.IdComision, dto.IdMateria, dto.AnioCalendario))
            {
                throw new ArgumentException($"Ya existe una curso con el año '{dto.AnioCalendario}'," +
                    $" la comisión con ID {dto.IdComision} y la materia con ID {dto.IdMateria}");
            }

            Curso curso = new Curso(dto.AnioCalendario, dto.Cupo, dto.IdComision, dto.IdMateria);

            cursoRepository.Add(curso);

            dto.IdCurso = curso.IdCurso;

            return dto;
        }
        public bool Update(CursoDTO dto)
        {
            var cursoRepository = new CursoRepository();

            // Validar que existe la comisión
            if (!cursoRepository.ComisionExists(dto.IdComision))
            {
                throw new ArgumentException($"No existe la comisión con ID {dto.IdComision}");
            }

            // Validar que existe la materia
            if (!cursoRepository.MateriaExists(dto.IdMateria))
            {
                throw new ArgumentException($"No existe la materia con ID {dto.IdMateria}");
            }

            // Validar que un año de calendario, una comisión y una materia no estén duplicados
            if (cursoRepository.ComisionMateriaAndAnioCalendarioExist(dto.IdComision, dto.IdMateria, dto.AnioCalendario))
            {
                throw new ArgumentException($"Ya existe una curso con el año '{dto.AnioCalendario}'," +
                    $" la comisión con ID {dto.IdComision} y la materia con ID {dto.IdMateria}");
            }

            Curso curso = new Curso(dto.IdCurso, dto.AnioCalendario, dto.Cupo, dto.IdComision, dto.IdMateria);

            return cursoRepository.Update(curso);
        }
        public bool Delete(int id)
        {
            var cursoRepository = new CursoRepository();
            return cursoRepository.Delete(id);
        }
        public bool ExistComisionMateriaAndAnioCalendario(int idComision, int idMateria, int anioCalendario, int? excludeId = null)
        {
            var cursoRepository = new CursoRepository();
            return cursoRepository.ComisionMateriaAndAnioCalendarioExist(idComision, idMateria, anioCalendario, excludeId);
        }
    }
}
