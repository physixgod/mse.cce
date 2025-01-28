using CCE.Application.Repositories.Usine;
using CCE.Domain.Usine.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CST.CCE.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtelierEndPoints : ControllerBase
    {
        private readonly IAtelierRepository _atelierRepository;

        public AtelierEndPoints(IAtelierRepository atelierRepository)
        {
            _atelierRepository = atelierRepository;
        }

        [HttpPost("AddAtelier")]
        public async Task<IActionResult> AddAtelier([FromBody] Atelier atelier, [FromQuery] string usineCode)
        {
            try
            {
                var addedAtelier = await _atelierRepository.AddAsync(atelier, usineCode);
                return Ok(addedAtelier);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Usine not found.");
            }
        }

        [HttpGet("GetAtelier/{id}")]
        public async Task<IActionResult> GetAtelier(string id)
        {
            var atelier = await _atelierRepository.GetByIdAsync(id);
            if (atelier == null)
            {
                return NotFound();
            }
            return Ok(atelier);
        }

        [HttpGet("GetAteliers")]
        public async Task<IActionResult> GetAteliers()
        {
            var ateliers = await _atelierRepository.GetAllAsync();
            return Ok(ateliers);
        }

        [HttpPut("UpdateAtelier/{id}")]
        public async Task<IActionResult> UpdateAtelier(string id, [FromBody] Atelier atelier)
        {
            if (id != atelier.Code)
            {
                return BadRequest("Atelier ID mismatch");
            }

            var updatedAtelier = await _atelierRepository.UpdateAsync(atelier);
            if (updatedAtelier == null)
            {
                return NotFound();
            }

            return Ok(updatedAtelier);
        }

        [HttpDelete("DeleteAtelier/{id}")]
        public async Task<IActionResult> DeleteAtelier(string id)
        {
            var deleted = await _atelierRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
