using Application.Members.Commands.ActorCommands.CreateCommand;
using Application.Members.Commands.ActorCommands.DeleteCommand;
using Application.Members.Commands.ActorCommands.UpdateCommand;
using Application.Members.Responses.ActorResponses;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<Actor, ActorResponse>().ReverseMap();
        CreateMap<Actor, ActorBaseResponse>().ReverseMap();
        CreateMap<Actor, CreateActorCommand>().ReverseMap();
        CreateMap<Actor, DeleteActorCommand>().ReverseMap();
        CreateMap<Actor, UpdateActorCommand>().ReverseMap();
    }
}
