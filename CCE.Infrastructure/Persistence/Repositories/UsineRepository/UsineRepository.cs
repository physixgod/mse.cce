using CCE.Application.Repositories.Usine;
using CCE.Domain.Usine;

namespace CCE.Infrastructure.Persistence.Repositories.UsineRepository;

public class UsineRepository:IUsineRepository
{
    public Task<Usine> AddAsync(Usine usine)
    {
        throw new NotImplementedException();
    }

    public Task<Usine> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Usine>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Usine> UpdateAsync(Usine usine)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}