using Application.Abstractions.Messaging;
using Domain.Abstractions.Repositories;
using Domain.Shared;
using AutoMapper;
using Application.Members.Responses.ActorResponses;

namespace Application.Members.Queries.ActorQueries.GetByIdQuery;

public class GetActorByIdQueryHandler(IActorRepository actorRepository, IMapper mapper) : IQueryHandler<GetActorByIdQuery, ActorResponse>
{
    public async Task<Result<ActorResponse>> Handle(GetActorByIdQuery request, CancellationToken cancellationToken)
    {
        var actor = await actorRepository.GetByIdAsync(request.Id);

        if (actor == null)
        {
            return Result.Failure<ActorResponse>(new Error("400", "Actor Not Found"));
        }

        return Result.Success(mapper.Map<ActorResponse>(actor));
    }
    
}
