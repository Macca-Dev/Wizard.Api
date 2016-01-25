using System.Net;
using System.Web.Http;
using NLog;
using Estable.Lib.Mappers;
using Estable.Lib.Contracts;
using Wizard.Api.Services.Interfaces;
using Wizard.Api.Validation;
using System.Web.Http.Cors;
using Estable.Lib.Extensions;

namespace Wizard.Api.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class ChargeTypeController : ApiController
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IChargeTypeService _chargeTypeService;

        public ChargeTypeController(IChargeTypeService chargeTypeService)
        {
            _chargeTypeService = chargeTypeService;
        }

        [HttpPost]
        [Route("chargetypes")]
        public IHttpActionResult Create([FromBody] ChargeTypesContract chargeTypes)
        {
            Logger.Info($"Email: {chargeTypes.StableEmail} attempting to save charge types");

            var problems = _chargeTypeService.Save(chargeTypes);

			if (problems.IsNullOrEmpty())
            {
                return Content(HttpStatusCode.BadRequest, problems);
            }
			            
            return Ok();
        }

        [HttpGet]
        [Route("chargeTypes/{email}")]
        public IHttpActionResult GetByEmail(string email)
        {
            Logger.Info("Email:{0} asked for there charge type data", email);

            var chargeTypes = _chargeTypeService.Get(email);
            if (chargeTypes == null)
            {
                return NotFound();
            }

            return Content(HttpStatusCode.OK, chargeTypes);
        }
    }
}