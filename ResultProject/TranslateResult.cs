using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ResultProject
{

    public class TranslateResult<T> : ITranslateResult<T> where T : ControllerBase
    {
        private readonly ILogger<T> _logger;

        public TranslateResult(ILogger<T> logger)
        {
            _logger = logger;
        }
        public ActionResult TranslateToAction(Ardalis.Result.IResult model, ControllerBase controller)
        {
            ActionResult convertToAction = controller.ToActionResult(model);
          
            var result = (ObjectResult)convertToAction; 
            var value = JsonConvert.SerializeObject(result.Value);

            _logger.LogInformation($"Status:{result.StatusCode}, Value: {value}");
            return convertToAction;
        }
    }

    public interface ITranslateResult<T>
    {
        ActionResult TranslateToAction(Ardalis.Result.IResult model, ControllerBase controller);
    }
}
