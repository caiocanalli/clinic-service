using Clinic.Application.Labs.Requests;
using FluentValidation;

namespace Clinic.Application.Labs.Validators
{
    public class UpdateRequestValidator : AbstractValidator<UpdateRequest>
    {
        public UpdateRequestValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithMessage("Lab id invalid");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lab name invalid")
                .MinimumLength(3)
                .WithMessage("Lab name must be at least 3 characters")
                .MaximumLength(150)
                .WithMessage("Lab name must be a maximum of 150 characters");

            RuleFor(x => x.Address)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lab name invalid")
                .MinimumLength(3)
                .WithMessage("Lab name must be at least 3 characters")
                .MaximumLength(250)
                .WithMessage("Lab name must be a maximum of 250 characters");
        }
    }
}