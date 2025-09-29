using Data;
using DTOs;
using Academia.Entidades;

namespace Services
{
    public class ComisionService
    {
        public IEnumerable<ComisionDTO> GetAll()
        {
            var comisionRepository = new ComisionRepository();
            var comisiones = comisionRepository.GetAll();

            return comisiones.Select(comision => new ComisionDTO
            {
                IdComision = comision.IdComision,
                DescripcionComision = comision.DescripcionComision,
                AnioEspecialidad = comision.AnioEspecialidad,
                IdPlan = comision.IdPlan,
                DescripcionPlan = comision.Plan?.Descripcion,
                DescripcionEspecialidad = comision.Plan?.Especialidad?.Descripcion
            }).ToList();
        }
        public ComisionDTO Get(int id)
        {
            var comisionRepository = new ComisionRepository();
            Comision? comision = comisionRepository.Get(id);

            if (comision == null)
            {
                return null;
            }

            return new ComisionDTO
            {
                IdComision = comision.IdComision,
                DescripcionComision = comision.DescripcionComision,
                AnioEspecialidad = comision.AnioEspecialidad,
                IdPlan = comision.IdPlan,
                DescripcionPlan = comision.Plan?.Descripcion,
                DescripcionEspecialidad = comision.Plan?.Especialidad?.Descripcion
            };
        }
        public ComisionDTO Add(ComisionDTO dto)
        {
            var comisionRepository = new ComisionRepository();

            // Validar que existe el plan
            if (!comisionRepository.PlanExists(dto.IdPlan))
            {
                throw new ArgumentException($"No existe el plan con ID {dto.IdPlan}");
            }

            // Validar que un año de especialidad y un plan no estén duplicados
            if (comisionRepository.PlanAndAnioEspecialidadExist(dto.AnioEspecialidad, dto.IdPlan))
            {
                throw new ArgumentException($"Ya existe una comision con el año de especialidad '{dto.AnioEspecialidad}' y el plan con ID {dto.IdPlan}");
            }

            Comision comision = new Comision(dto.DescripcionComision, dto.AnioEspecialidad, dto.IdPlan);

            comisionRepository.Add(comision);

            dto.IdComision = comision.IdComision;

            return dto;
        }
        public bool Update(ComisionDTO dto)
        {
            var comisionRepository = new ComisionRepository();

            // Validar que existe el plan
            if (!comisionRepository.PlanExists(dto.IdPlan))
            {
                throw new ArgumentException($"No existe el plan con ID {dto.IdPlan}");
            }

            // Validar que un año de especialidad y un plan no estén duplicados
            if (comisionRepository.PlanAndAnioEspecialidadExist(dto.AnioEspecialidad, dto.IdPlan))
            {
                throw new ArgumentException($"Ya existe una comision con el año de especialidad '{dto.AnioEspecialidad}' y el plan con ID {dto.IdPlan}");
            }

            Comision comision = new Comision(dto.IdComision, dto.DescripcionComision, dto.AnioEspecialidad, dto.IdPlan);

            return comisionRepository.Update(comision);
        }
        public bool Delete(int id)
        {
            var comisionRepository = new ComisionRepository();
            var cantidadCursos = comisionRepository.CountCursosByComision(id);
            if (cantidadCursos > 0)
            {
                string mensaje = $"No se puede eliminar la comisión. ";
                if (cantidadCursos == 1)
                {
                    mensaje += $"Tiene un curso asignado.";
                }
                else
                {
                    mensaje += $"Tiene {cantidadCursos} cursos asignados.";
                }
                throw new InvalidOperationException(mensaje);
            }
            return comisionRepository.Delete(id);
        }
        public bool ExistPlanAndAnioEspecialidad(int anioEspecialidad, int idPlan, int? excludeId = null)
        {
            var comisionRepository = new ComisionRepository();
            return comisionRepository.PlanAndAnioEspecialidadExist(anioEspecialidad, idPlan, excludeId);
        }
    }
}
