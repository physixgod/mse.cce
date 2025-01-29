using CCE.Application.Repositories.Usine;
using CCE.Domain.Usine.Entities;
using Microsoft.AspNetCore.Mvc;


namespace CST.CCE.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionPotentielleEndPoints : ControllerBase
    {
        private readonly IProductionRepository _productionRepository;

        public ProductionPotentielleEndPoints(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }

        [HttpPost("AddProductionPotentielle")]
        public async Task<IActionResult> AddProductionPotentielle([FromBody] ProductionPotentielle productionPotentielle, [FromQuery] string ligneCode)
        {
            try
            {
                var addedProductionPotentielle = await _productionRepository.AddAsync(productionPotentielle, ligneCode);
                return Ok(addedProductionPotentielle);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetProductionPotentielle/{code}")]
        public async Task<IActionResult> GetProductionPotentielle(string code)
        {
            var productionPotentielle = await _productionRepository.GetByIdAsync(code);
            if (productionPotentielle == null)
            {
                return NotFound();
            }
            return Ok(productionPotentielle);
        }

        [HttpGet("GetProductionPotentielles")]
        public async Task<IActionResult> GetProductionPotentielles()
        {
            var productionPotentielles = await _productionRepository.GetAllAsync();
            return Ok(productionPotentielles);
        }

        [HttpPut("UpdateProductionPotentielle/{code}")]
        public async Task<IActionResult> UpdateProductionPotentielle(string code, [FromBody] ProductionPotentielle productionPotentielle)
        {
            if (code != productionPotentielle.Code)
            {
                return BadRequest("ProductionPotentielle code mismatch");
            }

            var updatedProductionPotentielle = await _productionRepository.UpdateAsync(productionPotentielle);
            if (updatedProductionPotentielle == null)
            {
                return NotFound();
            }

            return Ok(updatedProductionPotentielle);
        }

        [HttpDelete("DeleteProductionPotentielle/{code}")]
        public async Task<IActionResult> DeleteProductionPotentielle(string code)
        {
            var deleted = await _productionRepository.DeleteAsync(code);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
