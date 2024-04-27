using Domain.Entities;

namespace Domain.Abstractions.Filters.ActorFilters;

public interface IActorFilter
{
    public List<Actor> FilterList(List<Actor> actors, string? actorName, int? minRank, int? maxRank, string? provider, int skip = 0, int take = 20);
}
