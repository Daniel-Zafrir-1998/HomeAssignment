using FluentValidation;

namespace Application.Members.Commands.ActorCommands.CreateCommand;

public class UpdateActorCommandValidator : AbstractValidator<CreateActorCommand>
{
    public UpdateActorCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Rank).GreaterThanOrEqualTo(1);
    }
}
