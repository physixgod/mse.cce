using CCE.Application.Repositories.Usine;
using CCE.Domain.Usine.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CST.CCE.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePosteEndPoints : ControllerBase
    {
        private readonly ITypePosteRepository _typePosteRepository;

        public TypePosteEndPoints(ITypePosteRepository typePosteRepository)
        {
            _typePosteRepository = typePosteRepository;
        }

        // Add a new TypePoste
        [HttpPost("AddTypePoste")]
        public async Task<IActionResult> AddTypePoste([FromBody] TypePoste typePoste)
        {
            try
            {
                var addedTypePoste = await _typePosteRepository.AddAsync(typePoste);
                return Ok(addedTypePoste);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        // Get a specific TypePoste by Code
        [HttpGet("GetTypePoste/{code}")]
        public async Task<IActionResult> GetTypePoste(string code)
        {
            var typePoste = await _typePosteRepository.GetByIdAsync(code);
            if (typePoste == null)
            {
                return NotFound();
            }
            return Ok(typePoste);
        }

        // Get all TypePoste
        [HttpGet("GetTypePostes")]
        public async Task<IActionResult> GetTypePostes()
        {
            var typePostes = await _typePosteRepository.GetAllAsync();
            return Ok(typePostes);
        }

        // Update an existing TypePoste
        [HttpPut("UpdateTypePoste/{code}")]
        public async Task<IActionResult> UpdateTypePoste(string code, [FromBody] TypePoste typePoste)
        {
            if (code != typePoste.Code)
            {
                return BadRequest("TypePoste code mismatch");
            }

            var updatedTypePoste = await _typePosteRepository.UpdateAsync(typePoste);
            if (updatedTypePoste == null)
            {
                return NotFound();
            }

            return Ok(updatedTypePoste);
        }

        // Delete a TypePoste by Code
        [HttpDelete("DeleteTypePoste/{code}")]
        public async Task<IActionResult> DeleteTypePoste(string code)
        {
            var deleted = await _typePosteRepository.DeleteAsync(code);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
