using FluentValidation;
using ResultProject.Dtos;

namespace ResultProject.Validations
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Surname)
                .NotEmpty()
                .MaximumLength(10)
                .NotEqual("SomeLongName");
            RuleFor(x => x.Forename).NotEmpty().WithMessage("Please specify a first name");
        }
    }
}
