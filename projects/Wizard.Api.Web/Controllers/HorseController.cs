using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using NLog;
using Estable.Lib.Contracts;
using Wizard.Api.Services.Interfaces;

namespace Wizard.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HorseController : ApiController
    {
        private readonly IAnimalService _animalService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public HorseController(IAnimalService animalService)
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

            var horses = _animalService.Get(email);
            if (horses == null)
            {
                return NotFound();
            }

            return Content(HttpStatusCode.OK, horses);
        }
    }
}