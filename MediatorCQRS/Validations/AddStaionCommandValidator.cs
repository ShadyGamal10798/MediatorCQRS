using FluentValidation;
using MediatorCQRS.Commands;

namespace MediatorCQRS.Validations
{
    public class AddStaionCommandValidator : AbstractValidator<AddStaionCommand>
    {
        public AddStaionCommandValidator()
        {
            RuleFor(x => x.StationName)
            .NotEmpty().WithMessage("Station name is required.")
            .MinimumLength(3).WithMessage("Station name must be at least 3 characters long.");

            RuleFor(x => x.CityId)
                .NotEqual(0).WithMessage("City ID must not be 0.");
        }
    }
}
