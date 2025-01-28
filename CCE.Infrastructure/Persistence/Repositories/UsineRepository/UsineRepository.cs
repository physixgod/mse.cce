using CCE.Application.Repositories.Usine;
using CCE.Domain.Usine;
using Microsoft.EntityFrameworkCore;
using CCE.Infrastructure.Persistence.Context;

namespace CCE.Infrastructure.Persistence.Repositories.UsineRepository
{
    public class UsineRepository : IUsineRepository
    {
        private readonly ApplicationDbContext _context;

        public UsineRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Usine> AddAsync(Usine usine)
        {
            _context.Usines.Add(usine);
            await _context.SaveChangesAsync();
            return usine;
        }
        public async Task<Usine> GetByIdAsync(string id)
        {
            return await _context.Usines.FindAsync(id); 
        }
        public async Task<IEnumerable<Usine>> GetAllAsync()
        {
            return await _context.Usines.ToListAsync(); 
        }
        public async Task<Usine> UpdateAsync(Usine usine)
        {
            _context.Usines.Update(usine);
            await _context.SaveChangesAsync();
            return usine;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var usine = await _context.Usines.FindAsync(id);
            if (usine == null)
                return false;

            _context.Usines.Remove(usine);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
