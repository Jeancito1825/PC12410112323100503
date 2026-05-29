using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC12410112323100503.Entidades;

namespace PC12410112323100503.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoServicioController : ControllerBase
    {
        private readonly TallerContext _context;

        public TipoServicioController(TallerContext context)
        {
            _context = context;
        }

        // GET: api/TipoServicio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoServicio>>> Get()
        {
            return await _context.TipoServicios.AsNoTracking().ToListAsync();
        }

        // GET: api/TipoServicio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoServicio>> Get(int id)
        {
            var tipo = await _context.TipoServicios.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

            if (tipo == null)
                return NotFound();

            return tipo;
        }

        // POST: api/TipoServicio
        [HttpPost]
        public async Task<ActionResult<TipoServicio>> Post(TipoServicio tipoServicio)
        {
            _context.TipoServicios.Add(tipoServicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = tipoServicio.Id }, tipoServicio);
        }

        // PUT: api/TipoServicio/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TipoServicio tipoServicio)
        {
            if (id != tipoServicio.Id)
                return BadRequest();

            var exist = await _context.TipoServicios.FindAsync(id);
            if (exist == null)
                return NotFound();

            // actualizar campos permitidos
            exist.Nombre = tipoServicio.Nombre;
            exist.PrecioBase = tipoServicio.PrecioBase;

            _context.Entry(exist).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/TipoServicio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipo = await _context.TipoServicios.FindAsync(id);
            if (tipo == null)
                return NotFound();

            _context.TipoServicios.Remove(tipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
