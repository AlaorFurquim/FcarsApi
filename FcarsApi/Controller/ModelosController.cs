using Fcar.Domain.Enitites;
using Fcar.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FcarsApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelosController : ControllerBase
    {
        private readonly ModeloRepository _repo;

        public ModelosController(ModeloRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _repo.GetAllAsync());

        [HttpPost("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var modelo = await _repo.GetByIdAsync(id);
            return modelo == null ? NotFound() : Ok(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Marca marca)
        {
            await _repo.AddAsync(marca);
            return CreatedAtAction(nameof(Get), new { id = marca.Id }, marca);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Marca marca)
        {
            if (id != marca.Id) return BadRequest();
            await _repo.UpdateAsync(marca);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
