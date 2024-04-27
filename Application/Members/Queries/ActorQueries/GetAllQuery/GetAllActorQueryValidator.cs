using FluentValidation;

namespace Application.Members.Queries.ActorQueries.GetAllQuery
{
    internal class GetAllActorQueryValidator : AbstractValidator<GetAllActorsQuery>
    {
        public GetAllActorQueryValidator()
        {
            RuleFor(x => x.MinRank).GreaterThanOrEqualTo(1).LessThan(x => x.MaxRank);
            RuleFor(x => x.MaxRank).LessThan(int.MaxValue).GreaterThan(x => x.MinRank);
        }
    }
}
