using CCE.Domain.Usine.Entities;

namespace CCE.Application.Repositories.Usine;

public interface ITypePosteRepository
{
    Task<TypePoste> AddAsync(TypePoste typePoste);
    Task<TypePoste?> GetByIdAsync(string code);
    Task<IEnumerable<TypePoste>> GetAllAsync();
    Task<TypePoste> UpdateAsync(TypePoste typePoste);
    Task<bool> DeleteAsync(string code);
}