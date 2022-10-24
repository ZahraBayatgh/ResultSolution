using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using ResultProject.Dtos;

namespace ResultProject.Services
{
    public class PersonService: IPersonService
    {
        private readonly IValidator<PersonDto> _personValidator;

        public PersonService(IValidator<PersonDto> personValidator )
        {
            _personValidator = personValidator;
        }
        private readonly int[] _knownIds = new[] { 1 };

        public Result<PersonDto> Create(PersonDto person)
        {
            var result = _personValidator.Validate(person);
            if (!result.IsValid)
            {
                return Result.Invalid(result.AsErrors());
            }

            return Result.Success(person);
        }

        public Result Remove(int id)
        {
            if (!_knownIds.Any(knownId => knownId == id))
            {
                return Result.NotFound("Person Not Found");
            }

            //Pretend removing person

            return Result.Success();
        }
    }
}
