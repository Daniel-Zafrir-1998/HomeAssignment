using Application.Abstractions.Messaging;
using Application.Members.Responses.ActorResponses;

namespace Application.Members.Queries.ActorQueries.GetAllQuery;

public sealed record GetAllActorsQuery(string? ActorName, int? MinRank, int? MaxRank, string? Provider, int Skip, int Take) : IQuery<List<ActorBaseResponse>>
{ }