using CCE.Domain.Usine.Entities;

namespace CCE.Application.Repositories.Usine;

public interface ILigneRepository
{
    Task<Ligne> AddAsync(Ligne ligne, string secteurAtelierCode);
    Task<Ligne> GetByIdAsync(string code);
    Task<IEnumerable<Ligne>> GetAllAsync();
    Task<Ligne> UpdateAsync(Ligne ligne);
    Task<bool> DeleteAsync(string code);
}