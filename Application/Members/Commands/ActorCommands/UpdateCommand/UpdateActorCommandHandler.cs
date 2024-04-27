using Application.Abstractions.Messaging.Commands;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using Domain.Shared;

namespace Application.Members.Commands.ActorCommands.UpdateCommand;

public sealed class UpdateActorCommandHandler(IMapper mapper, IActorRepository actorRepository) : ICommandHandler<UpdateActorCommand>
{
    public async Task<Result> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
    {
        var actor = mapper.Map<Actor>(request);
        var isRankUsed = await actorRepository.IsRankExistAsync(actor.Rank);

        if (isRankUsed)
        {
            return Result.Failure(new Error("400", "Rank Already Used"));
        }

        await actorRepository.UpdateAsync(actor);

        return Result.Success();
    }
}
