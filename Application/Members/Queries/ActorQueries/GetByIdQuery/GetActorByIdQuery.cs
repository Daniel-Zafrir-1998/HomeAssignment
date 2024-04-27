using Application.Abstractions.Messaging;
using Application.Members.Responses.ActorResponses;

namespace Application.Members.Queries.ActorQueries.GetByIdQuery;

public sealed record GetActorByIdQuery(string Id) : IQuery<ActorResponse>
{ }
