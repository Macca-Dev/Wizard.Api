using System.Net;
using System.Web.Http;
using NLog;
using Wizard.Api.Mappers.Interfaces;
using Wizard.Api.Models;
using Wizard.Api.Services.Interfaces;
using Wizard.Api.Validation;

namespace Wizard.Api.Controllers
{
    public class HorseController : ApiController
    {
        private readonly IAnimalService _animalService;
        private readonly HorsesValidator _validator;
        private readonly IInvalidDataProblemMapper _problemMapper;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public HorseController(IAnimalService animalService , HorsesValidator validator, IInvalidDataProblemMapper problemMapper)
        {
            _animalService = animalService;
            _validator = validator;
            _problemMapper = problemMapper;
        }

        [HttpPost]
        [Route("horse")]
        public IHttpActionResult Create([FromBody] HorsesContract horses)
        {
            Logger.Info($"Email: {horses.StableEmail} attempting to save horses.");

            var validation = _validator.Validate(horses);

            if (false == validation.IsValid)
            {
                var result = _problemMapper.Map(validation.Errors).ToJson;
                return Content(HttpStatusCode.BadRequest, result);
            }

            _animalService.Save(horses);
            
            return Ok();
        }
    }
}