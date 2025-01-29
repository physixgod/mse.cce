using CCE.Application.Repositories.Usine;
using CCE.Domain.Usine.Entities;
using CCE.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CCE.Infrastructure.Persistence.Repositories.UsineRepository;

public class LigneRepository : ILigneRepository
{
    private readonly ApplicationDbContext _context;

    public LigneRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Ligne> AddAsync(Ligne ligne, string secteurAtelierCode)
    {
        var secteurAtelier = await _context.SecteurAteliers
            .FirstOrDefaultAsync(sa => sa.Code == secteurAtelierCode);

        if (secteurAtelier == null)
        {
            throw new Exception("SecteurAtelier not found");
        }

        ligne.SecteurAtelier = secteurAtelier;
        ligne.SecteurAtelierCode = secteurAtelier.Code;

        await _context.Lignes.AddAsync(ligne);
        await _context.SaveChangesAsync();
        return ligne;
    }

    public async Task<Ligne> GetByIdAsync(string code)
    {
        return await _context.Lignes
            .Include(l => l.SecteurAtelier)
            .FirstOrDefaultAsync(l => l.Code == code);
    }

    public async Task<IEnumerable<Ligne>> GetAllAsync()
    {
        return await _context.Lignes
            .Include(l => l.SecteurAtelier)
            .ToListAsync();
    }

    public async Task<Ligne> UpdateAsync(Ligne ligne)
    {
        var existingLigne = await _context.Lignes.FindAsync(ligne.Code);
        if (existingLigne == null)
        {
            throw new Exception("Ligne not found");
        }

        _context.Entry(existingLigne).CurrentValues.SetValues(ligne);
        await _context.SaveChangesAsync();
        return existingLigne;
    }

    public async Task<bool> DeleteAsync(string code)
    {
        var ligne = await _context.Lignes.FindAsync(code);
        if (ligne == null)
        {
            return false;
        }

        _context.Lignes.Remove(ligne);
        await _context.SaveChangesAsync();
        return true;
    }
}
