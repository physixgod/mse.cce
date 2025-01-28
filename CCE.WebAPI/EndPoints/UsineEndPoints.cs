using CCE.Application.Repositories.Usine;
using CCE.Domain.Usine;
using Microsoft.AspNetCore.Mvc;

namespace CST.CCE.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsineEndPoints : ControllerBase
    {
        private readonly IUsineRepository _usineRepository;

        public UsineEndPoints(IUsineRepository usineRepository)
        {
            _usineRepository = usineRepository;
        }
        [HttpPost("AddUsine")]
        public async Task<IActionResult> AddUsine(Usine usine)
        {
            var addedUsine = await _usineRepository.AddAsync(usine);
            return Ok(addedUsine);
        }
        [HttpGet("GetUsines")]
        public async Task<IActionResult> GetUsines()
        {
            var usines = await _usineRepository.GetAllAsync();
            return Ok(usines);
        }
        [HttpGet("GetUsine/{id}")]
        public async Task<IActionResult> GetUsine(string id)
        {
            var usine = await _usineRepository.GetByIdAsync(id);
            if (usine == null)
            {
                return NotFound();
            }
            return Ok(usine);
        }

        [HttpPut("UpdateUsine/{id}")]
        public async Task<IActionResult> UpdateUsine(string id, Usine usine)
        {
            if (id != usine.Code)
            {
                return BadRequest("Usine ID mismatch");
            }

            var updatedUsine = await _usineRepository.UpdateAsync(usine);
            if (updatedUsine == null)
            {
                return NotFound();
            }

            return Ok(updatedUsine);
        }

        [HttpDelete("DeleteUsine/{id}")]
        public async Task<IActionResult> DeleteUsine(string id)
        {
            var deletedUsine = await _usineRepository.DeleteAsync(id);
            if (deletedUsine == null)
            {
                return NotFound();
            }

            return NoContent(); 
        }
    }
}
