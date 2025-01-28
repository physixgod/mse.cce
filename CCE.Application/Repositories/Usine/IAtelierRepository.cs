using CCE.Domain.Usine.Entities;

namespace CCE.Application.Repositories.Usine
{
    public interface IAtelierRepository
    {
        Task<Atelier> AddAsync(Atelier atelier, string usineCode);
        Task<Atelier> GetByIdAsync(string id);
        Task<IEnumerable<Atelier>> GetAllAsync();
        Task<Atelier> UpdateAsync(Atelier atelier);
        Task<bool> DeleteAsync(string id);
    }
}