using CCE.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using CCE.Application.Repositories.Usine;
using CCE.Domain.Usine.Entities;

namespace CCE.Infrastructure.Persistence.Repositories.UsineRepository
{
    public class AtelierRepository : IAtelierRepository
    {
        private readonly ApplicationDbContext _context;

        public AtelierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Atelier> AddAsync(Atelier atelier, string usineCode)
        {
            var usine = await _context.Usines.FirstOrDefaultAsync(u => u.Code == usineCode);
            if (usine == null)
            {
                throw new KeyNotFoundException("Usine not found.");
            }

            atelier.UsineCode = usine.Code;
            atelier.Usine = usine;

            await _context.Ateliers.AddAsync(atelier);
            await _context.SaveChangesAsync();

            return atelier;
        }

        public async Task<Atelier> GetByIdAsync(string id)
        {
            return await _context.Ateliers
                .Include(a => a.Usine)
                .FirstOrDefaultAsync(a => a.Code == id);
        }

        public async Task<IEnumerable<Atelier>> GetAllAsync()
        {
            return await _context.Ateliers
                .Include(a => a.Usine)
                .ToListAsync();
        }

        public async Task<Atelier> UpdateAsync(Atelier atelier)
        {
            _context.Ateliers.Update(atelier);
            await _context.SaveChangesAsync();
            return atelier;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var atelier = await _context.Ateliers.FindAsync(id);
            if (atelier == null)
            {
                return false;
            }

            _context.Ateliers.Remove(atelier);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
