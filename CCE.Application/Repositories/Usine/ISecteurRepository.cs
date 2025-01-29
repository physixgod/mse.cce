using CCE.Domain.Usine.Entities;

namespace CCE.Application.Repositories.Usine;

public interface ISecteurRepository
{
    Task<SecteurAtelier> AddAsync(SecteurAtelier secteur, string atelierCode);
    Task<SecteurAtelier> GetByIdAsync(string id);
    Task<IEnumerable<SecteurAtelier>> GetAllAsync();
    Task<SecteurAtelier> UpdateAsync(SecteurAtelier secteur);
    Task<bool> DeleteAsync(string id);
}