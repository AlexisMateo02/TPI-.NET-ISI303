using Academia.Entidades;
using Data;
using DTOs;

namespace Services
{
    public class PlanService
    {
        public IEnumerable<PlanDTO> GetAll()
        {
            var planRepository = new PlanRepository();
            var planes = planRepository.GetAll();
            return planes.Select(plan => new PlanDTO
            {
                IdPlan = plan.IdPlan,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad,
                DescripcionEspecialidad = plan.Especialidad?.Descripcion

            }).ToList();
        }
        public PlanDTO Get(int id)
        {
            var planRepository = new PlanRepository();
            Plan? plan = planRepository.Get(id);

            if (plan == null)
                return null;

            return new PlanDTO
            {
                IdPlan = plan.IdPlan,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad,
                DescripcionEspecialidad = plan.Especialidad?.Descripcion

            };
        }
        public PlanDTO Add(PlanDTO dto)
        {
            var planRepository = new PlanRepository();

            if (!planRepository.EspecialidadExists(dto.IdEspecialidad))
            {
                throw new ArgumentException($"No existe la especialidad con ID {dto.IdEspecialidad}");
            }

            if (planRepository.DescripcionExistsInEspecialidad(dto.Descripcion, dto.IdEspecialidad))
            {
                throw new ArgumentException($"Ya existe un plan con la descripción '{dto.Descripcion}' en la especialidad seleccionada");
            }

            Plan plan = new Plan(dto.Descripcion, dto.IdEspecialidad);
            planRepository.Add(plan);
            dto.IdPlan = plan.IdPlan;
            return dto;
        }
        public bool Update(PlanDTO dto)
        {
            var planRepository = new PlanRepository();

            if (!planRepository.EspecialidadExists(dto.IdEspecialidad))
            {
                throw new ArgumentException($"No existe la especialidad con ID {dto.IdEspecialidad}");
            }

            if (planRepository.DescripcionExistsInEspecialidad(dto.Descripcion, dto.IdEspecialidad))
            {
                throw new ArgumentException($"Ya existe un plan con la descripción '{dto.Descripcion}' en la especialidad seleccionada");
            }

            Plan plan = new Plan(dto.IdPlan, dto.Descripcion, dto.IdEspecialidad);
            return planRepository.Update(plan);
        }
        public bool Delete(int id)
        {
            var planRepository = new PlanRepository();
            var cantidadPersonas = planRepository.CountPersonasByPlan(id);
            if (cantidadPersonas > 0)
            {
                string mensaje = $"No se puede eliminar el plan. ";
                if (cantidadPersonas == 1)
                {
                    mensaje += $"Tiene una persona asignada.";
                }
                else
                {
                    mensaje += $"Tiene {cantidadPersonas} personas asignadas.";
                }
                throw new InvalidOperationException(mensaje);
            }
            var cantidadComisiones = planRepository.CountComisionesByPlan(id);
            if (cantidadComisiones > 0)
            {
                string mensaje = $"No se puede eliminar el plan. ";
                if (cantidadComisiones == 1)
                {
                    mensaje += $"Tiene una comisión asignada.";
                }
                else
                {
                    mensaje += $"Tiene {cantidadComisiones} comisiones asignadas.";
                }
                throw new InvalidOperationException(mensaje);
            }
            var cantidadMaterias = planRepository.CountMateriasByPlan(id);
            if (cantidadMaterias > 0)
            {
                string mensaje = $"No se puede eliminar el plan. ";
                if (cantidadMaterias == 1)
                {
                    mensaje += $"Tiene una materia asignada.";
                }
                else
                {
                    mensaje += $"Tiene {cantidadMaterias} materias asignadas.";
                }
                throw new InvalidOperationException(mensaje);
            }
            return planRepository.Delete(id);

        }
        public bool ExistsDescripcionInEspecialidad(string descripcion, int idEspecialidad, int? excludeId = null)
        {
            var planRepository = new PlanRepository();
            return planRepository.DescripcionExistsInEspecialidad(descripcion, idEspecialidad, excludeId);
        }
    }
}
