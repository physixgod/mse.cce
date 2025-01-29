using CCE.Application.Repositories.Usine;
using CCE.Domain.Usine.Entities;
using Microsoft.AspNetCore.Mvc;


namespace CST.CCE.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecteurAtelierEndPoints : ControllerBase
    {
        private readonly ISecteurRepository _secteurAtelierRepository;

        public SecteurAtelierEndPoints(ISecteurRepository secteurAtelierRepository)
        {
            _secteurAtelierRepository = secteurAtelierRepository;
        }

        [HttpPost("AddSecteurAtelier")]
        public async Task<IActionResult> AddSecteurAtelier([FromBody] SecteurAtelier secteurAtelier,[FromQuery] string atelierCode)
        {
            try
            {
                var addedSecteurAtelier = await _secteurAtelierRepository.AddAsync(secteurAtelier,atelierCode);
                return Ok(addedSecteurAtelier);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetSecteurAtelier/{id}")]
        public async Task<IActionResult> GetSecteurAtelier(string id)
        {
            var secteurAtelier = await _secteurAtelierRepository.GetByIdAsync(id);
            if (secteurAtelier == null)
            {
                return NotFound();
            }
            return Ok(secteurAtelier);
        }

        [HttpGet("GetSecteurAteliers")]
        public async Task<IActionResult> GetSecteurAteliers()
        {
            var secteurAteliers = await _secteurAtelierRepository.GetAllAsync();
            return Ok(secteurAteliers);
        }

        [HttpPut("UpdateSecteurAtelier/{id}")]
        public async Task<IActionResult> UpdateSecteurAtelier(string id, [FromBody] SecteurAtelier secteurAtelier)
        {
            if (id != secteurAtelier.Code)
            {
                return BadRequest("SecteurAtelier code mismatch");
            }

            var updatedSecteurAtelier = await _secteurAtelierRepository.UpdateAsync(secteurAtelier);
            if (updatedSecteurAtelier == null)
            {
                return NotFound();
            }

            return Ok(updatedSecteurAtelier);
        }

        [HttpDelete("DeleteSecteurAtelier/{id}")]
        public async Task<IActionResult> DeleteSecteurAtelier(string id)
        {
            var deleted = await _secteurAtelierRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
