using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeladeirosfcApp.Data;
using PeladeirosfcApp.Models;

namespace PeladeirosfcApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UsuariosController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET: api/usuarios
       [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _db.Users.ToListAsync();
        }

        //GET: api/usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string id)
        {
            var usuario = await _db.Users.FindAsync(id);
            if (usuario == null) return NotFound();
            return usuario;
        }

        // POST: api/usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            _db.Users.Add(usuario);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(string id, Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest();

            _db.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.Users.AnyAsync(e => e.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(string id)
        {
            var usuario = await _db.Users.FindAsync(id);
            if (usuario == null) return NotFound();

            _db.Users.Remove(usuario);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}