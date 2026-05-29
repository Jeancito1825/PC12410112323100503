using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PC12410112323100503.Core.Dtos;
using PC12410112323100503.Core.Interfaces;

namespace PC12410112323100503.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenServicioController : ControllerBase
    {
        private readonly IOrdenServicioService _service;

        public OrdenServicioController(IOrdenServicioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenServicioDto>>> Get()
        {
            try
            {
                var list = await _service.GetAllAsync();
                return Ok(list);
            }
            catch (System.Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenServicioDto>> Get(int id)
        {
            try
            {
                var dto = await _service.GetByIdAsync(id);
                if (dto == null) return NotFound();
                return Ok(dto);
            }
            catch (System.Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrdenServicioDto>> Post(OrdenServicioDto dto)
        {
            try
            {
                var created = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
            }
            catch (System.ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OrdenServicioDto dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (System.ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }
    }
}
