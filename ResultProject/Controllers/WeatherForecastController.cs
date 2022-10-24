using Microsoft.AspNetCore.Mvc;
using ResultProject.Dtos;
using ResultProject.Services;

namespace ResultProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ITranslateResult<WeatherForecastController> _translate;

        public WeatherForecastController(IPersonService personService, ITranslateResult<WeatherForecastController> translate)
        {
            _personService = personService;
            _translate = translate;
        }


        [HttpDelete("Remove/{id}")]
        public ActionResult RemovePerson(int id)
        {
            var result = _personService.Remove(id);
            var translate = _translate.TranslateToAction(result, this);

            return translate;
        }

        [HttpPost]
        public ActionResult CreatePerson(PersonDto person)
        {
            var result = _personService.Create(person);
            var translate = _translate.TranslateToAction(result, this);

            return translate;
        }
    }
}