using ICommand = Application.Abstractions.Messaging.Commands.ICommand;

namespace Application.Members.Commands.ActorCommands.CreateCommand
{
    public record CreateActorCommand(
        string Name,
        string Details,
        string Type,
        int Rank,
        string Source) : ICommand;
}
