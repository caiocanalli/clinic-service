using Clinic.Application.Exams.Requests;
using Clinic.Domain.Exams;
using FluentValidation;

namespace Clinic.Application.Exams.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .WithMessage("Exam name invalid")
                .MinimumLength(3)
                .WithMessage("Exam name must be at least 3 characters")
                .MaximumLength(150)
                .WithMessage("Exam name must be a maximum of 150 characters");

            RuleFor(x => x.Type)
                .Cascade(CascadeMode.Stop)
                .NotEqual(ExamType.None)
                .WithMessage("Exam type invalid");

            RuleFor(x => x.LabIds)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Exam labs invalid")
                .ForEach(x =>
                    x.GreaterThan(0)
                        .WithMessage("Lab id invalid"));
        }
    }
}