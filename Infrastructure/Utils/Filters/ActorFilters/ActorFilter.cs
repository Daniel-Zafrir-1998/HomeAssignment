using Domain.Abstractions.Filters.ActorFilters;
using Domain.Entities;
namespace Infrastructure.Utils.Filters.ActorFilters;

public class ActorFilter : IActorFilter
{
    public List<Actor> FilterList(List<Actor> actors, 
                                  string? actorName, 
                                  int? minRank, int? maxRank, 
                                  string? provider, int skip = 0, 
                                  int take = 20)
    {
        return actors.Where(x =>   (string.IsNullOrWhiteSpace(actorName) || x.Name == actorName)
                                && (string.IsNullOrWhiteSpace(provider) || x.Source == provider)
                                && x.Rank < (maxRank ?? int.MaxValue) 
                                && x.Rank > (minRank ?? int.MinValue))
                                .Skip(skip)
                                    .Take(take)
                                        .ToList();
    }
}
