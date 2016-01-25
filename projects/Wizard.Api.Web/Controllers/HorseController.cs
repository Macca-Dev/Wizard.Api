using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using NLog;
using Estable.Lib.Contracts;
using Wizard.Api.Services.Interfaces;
using Estable.Lib.Mappers;
using Wizard.Api.Validation;

namespace Wizard.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HorseController : WizardControllerBase
    {
        private readonly IAnimalService _animalService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public HorseController(
			IAnimalService animalService,
			EmailValidator emailValidator,
			IInvalidDataProblemMapper problemMapper)
			: base(emailValidator, problemMapper)
		{
            _animalService = animalService;
        }

        [HttpPost]
        [Route("horse")]
        public IHttpActionResult Create([FromBody] HorsesContract horses)
        {
            Logger.Info($"Email: {horses.StableEmail} attempting to save horses.");

            var problems = _animalService.Save(horses);

			if(problems != null)
			{
				return Content(HttpStatusCode.BadRequest, problems);
			}
            
            return Ok();
        }

        [HttpGet]
        [Route("horse/{email}")]
        public IHttpActionResult GetByEmail(string email)
        {
            Logger.Info($"Email: {email} asked for there horse data");

			var validation = ValidateGetRequest(email);

			if (validation != null)
			{
				return validation;
			}

			var horses = _animalService.Get(email);
            if (horses == null)
            {
				var obj = new HorsesContract();
				_animalService.SaveWithoutValidation(obj);
				horses = obj.ToJson;
			}

            return Content(HttpStatusCode.OK, horses);
        }
    }
}