using Application.Abstractions.Messaging;
using Domain.Abstractions.Repositories;
using Domain.Shared;
using AutoMapper;
using Domain.Abstractions.Filters.ActorFilters;
using Application.Members.Responses.ActorResponses;

namespace Application.Members.Queries.ActorQueries.GetAllQuery;

public class GetActorByIdQueryHandler(IActorRepository actorRepository, IMapper mapper, IActorFilter actorFilter) : IQueryHandler<GetAllActorsQuery, List<ActorBaseResponse>>
{
    public async Task<Result<List<ActorBaseResponse>>> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
    {
        var actors = await actorRepository.GetAllAsync();

        var filteredList = actorFilter.FilterList(actors, request.ActorName, request.MinRank, request.MaxRank, request.Provider, request.Skip, request.Take);

        if (!filteredList.Any())
        {
            return Result.Failure<List<ActorBaseResponse>>(new Error("400", "No Actor Found"));
        }


        return Result.Success(mapper.Map<List<ActorBaseResponse>>(filteredList));
    }
}
