using CCE.Application.Repositories.Usine;
using CCE.Domain.Usine.Entities;
using Microsoft.EntityFrameworkCore;
using CCE.Infrastructure.Persistence.Context;

namespace CCE.Infrastructure.Persistence.Repositories.UsineRepository;

public class TypePosteRepository : ITypePosteRepository
{
    private readonly ApplicationDbContext _context;

    public TypePosteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TypePoste> AddAsync(TypePoste typePoste)
    {
        await _context.TypePostes.AddAsync(typePoste);
        await _context.SaveChangesAsync();
        return typePoste;
    }

    public async Task<TypePoste?> GetByIdAsync(string code)
    {
        return await _context.TypePostes.FindAsync(code);
    }

    public async Task<IEnumerable<TypePoste>> GetAllAsync()
    {
        return await _context.TypePostes.ToListAsync();
    }

    public async Task<TypePoste> UpdateAsync(TypePoste typePoste)
    {
        var existingTypePoste = await _context.TypePostes.FindAsync(typePoste.Code);
        if (existingTypePoste == null)
        {
            throw new KeyNotFoundException("TypePoste not found");
        }

        _context.Entry(existingTypePoste).CurrentValues.SetValues(typePoste);
        await _context.SaveChangesAsync();
        return existingTypePoste;
    }

    public async Task<bool> DeleteAsync(string code)
    {
        var typePoste = await _context.TypePostes.FindAsync(code);
        if (typePoste == null)
        {
            return false;
        }

        _context.TypePostes.Remove(typePoste);
        await _context.SaveChangesAsync();
        return true;
    }
}