using Academia.Entidades;
using Data;
using DTOs;

namespace Services
{
    public class EspecialidadService
    {
        public IEnumerable<EspecialidadDTO> GetAll()
        {
            var especialidadRepository = new EspecialidadRepository();
            var especialidades = especialidadRepository.GetAll();

            return especialidades.Select(especialidad => new EspecialidadDTO
            {
                Id = especialidad.Id,
                Descripcion = especialidad.Descripcion
            }).ToList();
        }
        public EspecialidadDTO Get(int id)
        {
            var especialidadRepository = new EspecialidadRepository();
            Especialidad? especialidad = especialidadRepository.Get(id);

            if (especialidad == null)
                return null;

            return new EspecialidadDTO
            {
                Id = especialidad.Id,
                Descripcion = especialidad.Descripcion
            };
        }
        public EspecialidadDTO Add(EspecialidadDTO dto)
        {
            var especialidadRepository = new EspecialidadRepository();

            Especialidad especialidad = new Especialidad(dto.Descripcion);

            especialidadRepository.Add(especialidad);

            dto.Id = especialidad.Id;

            return dto;
        }
        public bool Update(EspecialidadDTO dto)
        {
            var especialidadRepository = new EspecialidadRepository();

            Especialidad especialidad = new Especialidad(dto.Id, dto.Descripcion);
            return especialidadRepository.Update(especialidad);
        }
        public bool Delete(int id)
        {
            var especialidadRepository = new EspecialidadRepository();
            var cantidadPlanes = especialidadRepository.CountPlanesByEspecialidad(id);
            if (cantidadPlanes > 0)
            {
                string mensaje = $"No se puede eliminar la especialidad. ";
                if (cantidadPlanes == 1)
                {
                    mensaje += $"Tiene un plan asociado.";
                }
                else
                {
                    mensaje += $"Tiene {cantidadPlanes} planes asociados.";
                }
                throw new InvalidOperationException(mensaje);
            }
            return especialidadRepository.Delete(id);
        }
    }
}
