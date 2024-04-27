using ICommand = Application.Abstractions.Messaging.Commands.ICommand;

namespace Application.Members.Commands.ActorCommands.DeleteCommand
{
    public record DeleteActorCommand(string Id) : ICommand;
}
