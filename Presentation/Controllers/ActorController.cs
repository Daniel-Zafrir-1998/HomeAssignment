using Application.Members.Commands.ActorCommands.CreateCommand;
using Application.Members.Commands.ActorCommands.DeleteCommand;
using Application.Members.Commands.ActorCommands.UpdateCommand;
using Application.Members.Queries.ActorQueries.GetAllQuery;
using Application.Members.Queries.ActorQueries.GetByIdQuery;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.BaseController;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorController(ISender sender) : ApiBaseController(sender)
{
    [HttpGet("GetAllActors")]
    public async Task<Result> GetAllActors(
        [FromQuery] string? actorName,
        [FromQuery] int? minRank,
        [FromQuery] int? maxRank,
        [FromQuery] string? provider,
        [FromHeader] int skip = 0,
        [FromHeader] int take = 20)
    {
        var actorQuery = new GetAllActorsQuery(actorName, minRank, maxRank, provider, skip, take);

        var response = await _sender.Send(actorQuery);

        return response;
    }

    [HttpGet("GetActorById")]
    public async Task<Result> GetActorById([FromQuery] string id)
    {
        var actorQuery = new GetActorByIdQuery(id);

        var response = await _sender.Send(actorQuery);

        return response;
    }

    [HttpPost("CreateActor")]
    public async Task<Result> CreateActor([FromBody] CreateActorCommand createActor)
    {
        var response = await _sender.Send(createActor);

        return response;
    }

    [HttpPut("UpdateActor")]
    public async Task<Result> UpdateActor([FromBody] UpdateActorCommand updateActor)
    {
        var response = await _sender.Send(updateActor);

        return response;
    }

    [HttpPut("DeleteActor")]
    public async Task<Result> DeleteActor([FromQuery] string id)
    {
        var actorQuery = new DeleteActorCommand(id);

        var response = await _sender.Send(actorQuery);

        return response;
    }
}

