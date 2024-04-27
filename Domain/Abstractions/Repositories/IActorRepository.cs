using Domain.Entities;

namespace Domain.Abstractions.Repositories;

public interface IActorRepository
{
    Task AddAsync(Actor actor);
    Task AddRangeAsync(List<Actor> actors);
    Task<List<Actor>> GetAllAsync();
    Task<Actor?> GetByIdAsync(string Id);
    Task<bool> UpdateAsync(Actor actor);
    Task<bool> DeleteAsync(Actor actor);
    Task<bool> DeleteByIdAsync(string Id);
    Task<bool> IsRankExistAsync(int rank);
}
