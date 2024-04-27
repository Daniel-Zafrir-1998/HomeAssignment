using FluentValidation;

namespace Application.Members.Commands.ActorCommands.DeleteCommand;

public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
{
    public DeleteActorCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
