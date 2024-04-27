using FluentValidation;

namespace Application.Members.Commands.ActorCommands.UpdateCommand;

public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
{
    public UpdateActorCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Rank).GreaterThanOrEqualTo(1);
    }
}
