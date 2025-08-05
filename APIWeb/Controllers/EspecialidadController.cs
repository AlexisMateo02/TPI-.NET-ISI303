using APIWeb.Context;
using APIWeb.Models;
using APIWeb.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIWeb.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EspecialidadController : Controller
    {
        private readonly MyDbContext _context;
        public EspecialidadController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetEspecialidad")]
        public ActionResult<IEnumerable<Especialidad>> GetAll()
        {
            return _context.Especialidades.ToList();
        }

        [HttpGet("{IdEspecialidad}")]
        public ActionResult<Especialidad> GetById(int IdEspecialidad)
        {
            var especialidad = _context.Especialidades.Find(IdEspecialidad);
            if (especialidad == null)
            {
                return NotFound();
            }
            return especialidad;
        }

        [HttpPost]
        public ActionResult<Especialidad> Create(EspecialidadDTO especialidadDTO)
        {
            var especialidad = new Especialidad
            {
                DescEspecialidad = especialidadDTO.DescEspecialidad
            };
            _context.Especialidades.Add(especialidad);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { IdEspecialidad = especialidad.IdEspecialidad }, especialidad);
        }

        [HttpPut("{IdEspecialidad}")]
        public ActionResult Update(int IdEspecialidad, EspecialidadDTO especialidadDTO)
        {
            var especialidad = _context.Especialidades.Find(IdEspecialidad);
            if (especialidad == null)
            {
                return NotFound();
            }
            especialidad.DescEspecialidad = especialidadDTO.DescEspecialidad;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{IdEspecialidad}")]
        public ActionResult<Especialidad> Delete(int IdEspecialidad)
        {
            var especialidad = _context.Especialidades.Find(IdEspecialidad);
            if (especialidad == null)
            {
                return NotFound();
            }
            _context.Especialidades.Remove(especialidad);
            _context.SaveChanges();
            return especialidad;
        }
    }
}
