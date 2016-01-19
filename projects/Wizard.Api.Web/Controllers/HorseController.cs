using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using NLog;
using Estable.Lib.Mappers;
using Estable.Lib.Contracts;
using Wizard.Api.Services.Interfaces;
using Wizard.Api.Validation;

namespace Wizard.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        [HttpGet]
        [Route("horse/{email}")]
        public IHttpActionResult GetByEmail(string email)
        {
            Logger.Info($"Email: {email} asked for there horse data");

            var horses = _animalService.Get(email);
            if (horses == null)
            {
                return NotFound();
            }

            return Content(HttpStatusCode.OK, horses);
        }
    }
}