using Academia.Entidades;
using Data;
using DTOs;
//using Academia.Entidades;

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

            var fechaAlta = DateTime.Now;
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
            return especialidadRepository.Delete(id);
        }
    }
}
