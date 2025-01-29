using CCE.Domain.Usine.Entities;

namespace CCE.Application.Repositories.Usine;

public interface IProductionRepository
{
    Task<ProductionPotentielle> AddAsync(ProductionPotentielle productionPotentielle, string ligneCode);
    Task<ProductionPotentielle> GetByIdAsync(string code);
    Task<IEnumerable<ProductionPotentielle>> GetAllAsync();
    Task<ProductionPotentielle> UpdateAsync(ProductionPotentielle productionPotentielle);
    Task<bool> DeleteAsync(string code);
}