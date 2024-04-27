using ICommand = Application.Abstractions.Messaging.Commands.ICommand;

namespace Application.Members.Commands.ActorCommands.UpdateCommand
{
    public record UpdateActorCommand(
        string Id,
        string Name,
        string Details,
        string Type,
        int Rank,
        string Source) : ICommand;
}
