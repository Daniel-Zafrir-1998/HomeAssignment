using Application.Abstractions.Messaging.Commands;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using Domain.Shared;

namespace Application.Members.Commands.ActorCommands.CreateCommand;

public sealed class CreateActorCommandHandler(IMapper mapper, IActorRepository actorRepository) : ICommandHandler<CreateActorCommand>
{
    public async Task<Result> Handle(CreateActorCommand request, CancellationToken cancellationToken)
    {
        var actor = mapper.Map<Actor>(request);
        var isRankUsed = await actorRepository.IsRankExistAsync(actor.Rank);

        if (isRankUsed)
        {
            return Result.Failure(new Error("400", "Rank Already Used"));
        }

        await actorRepository.AddAsync(actor);

        return Result.Success();
    }
}
