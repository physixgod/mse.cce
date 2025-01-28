
namespace CCE.Application.Repositories.Usine;
using CCE.Domain.Usine;

public interface IUsineRepository  
{
    Task<Usine> AddAsync(Usine usine);
    Task<Usine> GetByIdAsync(int id);
    Task<IEnumerable<Usine>> GetAllAsync();
    Task<Usine> UpdateAsync(Usine usine);
    Task<bool> DeleteAsync(int id);

}