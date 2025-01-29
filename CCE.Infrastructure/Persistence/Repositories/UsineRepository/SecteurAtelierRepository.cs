using CCE.Application.Repositories.Usine;
using CCE.Domain.Usine.Entities;
using CCE.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CCE.Infrastructure.Persistence.Repositories.UsineRepository;

public class SecteurAtelierRepository : ISecteurRepository
{
    private readonly ApplicationDbContext _context;

    public SecteurAtelierRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SecteurAtelier> AddAsync(SecteurAtelier secteur, string atelierCode)
    {
        var atelier = await _context.Ateliers.FirstOrDefaultAsync(a => a.Code == atelierCode);
        if (atelier == null)
        {
            throw new Exception("Atelier not found");
        }

        secteur.Atelier = atelier;
        await _context.SecteurAteliers.AddAsync(secteur);
        await _context.SaveChangesAsync();
        return secteur;
    }

    public async Task<SecteurAtelier> GetByIdAsync(string id)
    {
        return await _context.SecteurAteliers
            .Include(sa => sa.Atelier)
            .FirstOrDefaultAsync(sa => sa.Code == id);
    }

    public async Task<IEnumerable<SecteurAtelier>> GetAllAsync()
    {
        return await _context.SecteurAteliers
            .Include(sa => sa.Atelier)
            .ToListAsync();
    }

    public async Task<SecteurAtelier> UpdateAsync(SecteurAtelier secteur)
    {
        var existingSecteur = await _context.SecteurAteliers.FindAsync(secteur.Code);
        if (existingSecteur == null)
        {
            throw new Exception("SecteurAtelier not found");
        }

        _context.Entry(existingSecteur).CurrentValues.SetValues(secteur);
        await _context.SaveChangesAsync();
        return existingSecteur;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var secteur = await _context.SecteurAteliers.FindAsync(id);
        if (secteur == null)
        {
            return false;
        }

        _context.SecteurAteliers.Remove(secteur);
        await _context.SaveChangesAsync();
        return true;
    }
}
