using Ardalis.Result;
using ResultProject.Dtos;

namespace ResultProject.Services;

public interface IPersonService
{
    Result<PersonDto> Create(PersonDto person);
    Result Remove(int id);
}