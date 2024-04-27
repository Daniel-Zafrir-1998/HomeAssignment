namespace Application.Members.Responses.ActorResponses;

public sealed record ActorResponse(string Id, string Name, string Details, string Type, int Rank, string Source) : ActorBaseResponse(Id, Name)
{ }
