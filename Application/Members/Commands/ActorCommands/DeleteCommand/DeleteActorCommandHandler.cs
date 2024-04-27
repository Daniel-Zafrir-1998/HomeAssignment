using Application.Abstractions.Messaging.Commands;
using Domain.Abstractions.Repositories;
using Domain.Shared;

namespace Application.Members.Commands.ActorCommands.DeleteCommand;

public sealed class DeleteActorCommandHandler(IActorRepository actorRepository) : ICommandHandler<DeleteActorCommand>
{
    public async Task<Result> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
    {
        var isDeleted = await actorRepository.DeleteByIdAsync(request.Id);

        if (!isDeleted)
        {
            return Result.Failure(new("400", "Actor didn't deleted"));
        }

        return Result.Success();
    }
}
