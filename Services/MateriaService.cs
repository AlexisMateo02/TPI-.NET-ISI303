using Data;
using DTOs;
using Academia.Entidades;

namespace Services
{
    public class MateriaService
    {
        public IEnumerable<MateriaDTO> GetAll()
        {
            var materiaRepository = new MateriaRepository();
            var materias = materiaRepository.GetAll();

            return materias.Select(materia => new MateriaDTO
            {
                IdMateria = materia.IdMateria,
                DescripcionMateria = materia.DescripcionMateria,
                HorasSemanales = materia.HorasSemanales,
                HorasTotales = materia.HorasTotales,
                IdPlan = materia.IdPlan,
                DescripcionPlan = materia.Plan?.Descripcion,
                DescripcionEspecialidad = materia.Plan?.Especialidad?.Descripcion
            }).ToList();
        }
        public MateriaDTO Get(int id)
        {
            var materiaRepository = new MateriaRepository();
            Materia? materia = materiaRepository.Get(id);

            if (materia == null)
            {
                return null;
            }

            return new MateriaDTO
            {
                IdMateria = materia.IdMateria,
                DescripcionMateria = materia.DescripcionMateria,
                HorasSemanales = materia.HorasSemanales,
                HorasTotales = materia.HorasTotales,
                IdPlan = materia.IdPlan,
                DescripcionPlan = materia.Plan?.Descripcion,
                DescripcionEspecialidad = materia.Plan?.Especialidad?.Descripcion
            };
        }
        public MateriaDTO Add(MateriaDTO dto)
        {
            var materiaRepository = new MateriaRepository();

            // Validar que existe el plan
            if (!materiaRepository.PlanExists(dto.IdPlan))
            {
                throw new ArgumentException($"No existe el plan con ID {dto.IdPlan}");
            }

            // Validar que una descripción de materia y un plan no estén duplicados
            if (materiaRepository.PlanAndDescripcionMateriaExist(dto.IdPlan, dto.DescripcionMateria))
            {
                throw new ArgumentException($"Ya existe una materia con la descripción '{dto.DescripcionMateria}' y el plan con ID {dto.IdPlan}");
            }

            Materia materia = new Materia(dto.DescripcionMateria, dto.HorasSemanales, dto.HorasTotales, dto.IdPlan);

            materiaRepository.Add(materia);

            dto.IdMateria = materia.IdMateria;

            return dto;
        }
        public bool Update(MateriaDTO dto)
        {
            var materiaRepository = new MateriaRepository();

            // Validar que existe el plan
            if (!materiaRepository.PlanExists(dto.IdPlan))
            {
                throw new ArgumentException($"No existe el plan con ID {dto.IdPlan}");
            }

            // Validar que una descripción de materia y un plan no estén duplicados
            if (materiaRepository.PlanAndDescripcionMateriaExist(dto.IdPlan, dto.DescripcionMateria))
            {
                throw new ArgumentException($"Ya existe una materia con la descripción '{dto.DescripcionMateria}' y el plan con ID {dto.IdPlan}");
            }

            Materia materia = new Materia(dto.IdMateria, dto.DescripcionMateria, dto.HorasSemanales, dto.HorasTotales, dto.IdPlan);

            return materiaRepository.Update(materia);
        }
        public bool Delete(int id)
        {
            var materiaRepository = new MateriaRepository();
            var cantidadCursos = materiaRepository.CountCursosByMateria(id);
            if (cantidadCursos > 0)
            {
                string mensaje = $"No se puede eliminar la materia. ";
                if (cantidadCursos == 1)
                {
                    mensaje += $"Tiene un curso asociado.";
                }
                else
                {
                    mensaje += $"Tiene {cantidadCursos} cursos asociados.";
                }
                throw new InvalidOperationException(mensaje);
            }
            return materiaRepository.Delete(id);
        }
        public bool ExistPlanAndDescripcionMateria(int idPlan, string descripcionMateria, int? excludeId = null)
        {
            var materiaRepository = new MateriaRepository();
            return materiaRepository.PlanAndDescripcionMateriaExist(idPlan, descripcionMateria, excludeId);
        }
    }
}
