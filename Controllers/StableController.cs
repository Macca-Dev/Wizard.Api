using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using NLog;
using Wizard.Api.Mappers.Interfaces;
using Wizard.Api.Models;
using Wizard.Api.Services.Interfaces;
using Wizard.Api.Validation;

namespace Wizard.Api.Controllers
{
    //[RoutePrefix("v1")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StableController : ApiController
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly IStableService _stableService;
        private readonly StableValidator _validator;
        private readonly IInvalidDataProblemMapper _problemMapper;

        public StableController(IStableService stableService, StableValidator validator, IInvalidDataProblemMapper problemMapper)
        {
            _stableService = stableService;
            _validator = validator;
            _problemMapper = problemMapper;
        }

        [HttpPost]
        [Route("stable")]
        public IHttpActionResult Create([FromBody] StableContract stable)
        {
            Logger.Info(string.Format("Email: {0} attempting to save stable information", stable.StableEmail));

            var failures = _validator.Validate(stable);

            if (!failures.IsValid)
            {
                var result = _problemMapper.Map(failures.Errors).ToJson;

                return Content(HttpStatusCode.BadRequest, result);
            }
             
            _stableService.Save(stable);
            return Ok();
        }

        [HttpGet]
        [Route("stable/{email}")]
        public IHttpActionResult GetByEmail(string email)
        {
            Logger.Info(string.Format("Email: {0} asked for data on it's stable", email));
            var stable = _stableService.Get(email);

            return Content(HttpStatusCode.OK, stable);
        }
    }
}