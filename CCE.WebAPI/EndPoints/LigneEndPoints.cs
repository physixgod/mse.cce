using CCE.Application.Repositories.Usine;
using CCE.Domain.Usine.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CST.CCE.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigneEndPoints : ControllerBase
    {
        private readonly ILigneRepository _ligneRepository;

        public LigneEndPoints(ILigneRepository ligneRepository)
        {
            _ligneRepository = ligneRepository;
        }

        [HttpPost("AddLigne")]
        public async Task<IActionResult> AddLigne([FromBody] Ligne ligne, [FromQuery] string secteurAtelierCode)
        {
            try
            {
                var addedLigne = await _ligneRepository.AddAsync(ligne, secteurAtelierCode);
                return Ok(addedLigne);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("SecteurAtelier not found.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetLigne/{code}")]
        public async Task<IActionResult> GetLigne(string code)
        {
            var ligne = await _ligneRepository.GetByIdAsync(code);
            if (ligne == null)
            {
                return NotFound();
            }
            return Ok(ligne);
        }

        [HttpGet("GetLignes")]
        public async Task<IActionResult> GetLignes()
        {
            var lignes = await _ligneRepository.GetAllAsync();
            return Ok(lignes);
        }
        
        [HttpPut("UpdateLigne/{code}")]
        public async Task<IActionResult> UpdateLigne(string code, [FromBody] Ligne ligne)
        {
            if (code != ligne.Code)
            {
                return BadRequest("Ligne code mismatch");
            }

            var updatedLigne = await _ligneRepository.UpdateAsync(ligne);
            if (updatedLigne == null)
            {
                return NotFound();
            }

            return Ok(updatedLigne);
        }

        [HttpDelete("DeleteLigne/{code}")]
        public async Task<IActionResult> DeleteLigne(string code)
        {
            var deleted = await _ligneRepository.DeleteAsync(code);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
