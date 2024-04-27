using FluentValidation;

namespace Application.Members.Queries.ActorQueries.GetByIdQuery
{
    public class GetActorByIdQueryValidator : AbstractValidator<GetActorByIdQuery>
    {
        public GetActorByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}