using FluentValidation;
using MediatorCQRS.Queries;

namespace MediatorCQRS.Validations
{
    public class ReadStationDetailsQueryValidator : AbstractValidator<ReadStationDetailsQuery>
    {
        public ReadStationDetailsQueryValidator()
        {
            RuleFor(o => o.StationId).NotEqual(0);
        }
    }
}
