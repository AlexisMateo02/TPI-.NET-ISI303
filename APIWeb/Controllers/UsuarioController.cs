using APIWeb.Context;
using Academia.Entidades;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIWeb.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        private readonly MyDbContext _context;
        public UsuarioController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetUsuario")]
        public ActionResult<IEnumerable<Usuario>> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        [HttpGet("{IdUsuario}")]
        public ActionResult<Usuario> GetById(int IdUsuario)
        {
            var usuario = _context.Usuarios.Find(IdUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        [HttpPost]
        public ActionResult<Usuario> Create(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                NombreUsuario = usuarioDTO.NombreUsuario,
                Clave = usuarioDTO.Clave,
                Habilitado = usuarioDTO.Habilitado
            };
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { IdUsuario = usuario.IdUsuario }, usuario);
        }

        [HttpPut("{IdUsuario}")]
        public ActionResult Update(int IdUsuario, UsuarioDTO usuarioDTO)
        {
            var usuario = _context.Usuarios.Find(IdUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.NombreUsuario = usuarioDTO.NombreUsuario;
            usuario.Clave = usuarioDTO.Clave;
            usuario.Habilitado = usuarioDTO.Habilitado;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{IdUsuario}")]
        public ActionResult<Usuario> Delete(int IdUsuario)
        {
            var usuario = _context.Usuarios.Find(IdUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return usuario;
        }
    }
}
