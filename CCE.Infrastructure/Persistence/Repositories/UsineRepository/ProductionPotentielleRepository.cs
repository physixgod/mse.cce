using CCE.Application.Repositories.Usine;
using CCE.Domain.Usine.Entities;
using CCE.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace CCE.Infrastructure.Persistence.Repositories.UsineRepository
{
    public class ProductionPotentielleRepository : IProductionRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductionPotentielleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductionPotentielle> AddAsync(ProductionPotentielle productionPotentielle, string ligneCode)
        {
            var ligne = await _context.Lignes
                .FirstOrDefaultAsync(l => l.Code == ligneCode);

            if (ligne == null)
            {
                throw new Exception("Ligne not found");
            }

            productionPotentielle.Ligne = ligne;
            productionPotentielle.CodeLigne = ligne.Code;

            await _context.ProductionPotentielles.AddAsync(productionPotentielle);
            await _context.SaveChangesAsync();

            return productionPotentielle;
        }

        public async Task<ProductionPotentielle> GetByIdAsync(string code)
        {
            return await _context.ProductionPotentielles
                .Include(pp => pp.Ligne) // Include the related Ligne
                .FirstOrDefaultAsync(pp => pp.Code == code);
        }

        public async Task<IEnumerable<ProductionPotentielle>> GetAllAsync()
        {
            return await _context.ProductionPotentielles
                .Include(pp => pp.Ligne)
                .ToListAsync();
        }

        public async Task<ProductionPotentielle> UpdateAsync(ProductionPotentielle productionPotentielle)
        {
            var existingProductionPotentielle = await _context.ProductionPotentielles
                .FindAsync(productionPotentielle.Code);

            if (existingProductionPotentielle == null)
            {
                throw new Exception("ProductionPotentielle not found");
            }

            _context.Entry(existingProductionPotentielle).CurrentValues.SetValues(productionPotentielle);
            await _context.SaveChangesAsync();

            return existingProductionPotentielle;
        }

        public async Task<bool> DeleteAsync(string code)
        {
            var productionPotentielle = await _context.ProductionPotentielles
                .FirstOrDefaultAsync(pp => pp.Code == code);

            if (productionPotentielle == null)
            {
                return false; 
            }

            _context.ProductionPotentielles.Remove(productionPotentielle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
