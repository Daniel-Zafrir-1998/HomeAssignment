using Domain.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ActorRepository(ApplicationDbContext dbContext) : IActorRepository
{
    public async Task AddAsync(Actor actor)
    {
        await dbContext.AddAsync(actor);

        await dbContext.SaveChangesAsync();
    }

    public async Task AddRangeAsync(List<Actor> actors)
    {
        await dbContext.Actors.AddRangeAsync(actors);

        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Actor actor)
    {
        dbContext.Remove(actor);

        await dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteByIdAsync(string Id)
    {
        var actor = await dbContext.Actors.Where(a => a.Id == Id).FirstOrDefaultAsync();

        if (actor is null)
        {
            return false;
        }

        dbContext.Remove(actor);

        await dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<Actor>> GetAllAsync()
    {
        return await dbContext.Actors.ToListAsync();
    }

    public async Task<Actor?> GetByIdAsync(string Id)
    {
        return await dbContext.Actors.FirstOrDefaultAsync(a => a.Id == Id);
    }

    public async Task<bool> IsRankExistAsync(int rank)
    {
        return await dbContext.Actors.AnyAsync(a => a.Rank == rank);
    }

    public async Task<bool> UpdateAsync(Actor actor)
    {
        dbContext.Actors.Update(actor);

        await dbContext.SaveChangesAsync();

        return true;
    }
}
