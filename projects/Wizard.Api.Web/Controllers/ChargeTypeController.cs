using System.Net;
using System.Web.Http;
using NLog;
using Wizard.Api.Mappers.Interfaces;
using Wizard.Api.Models;
using Wizard.Api.Services.Interfaces;
using Wizard.Api.Validation;
using System.Web.Http.Cors;

namespace Wizard.Api.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class ChargeTypeController : ApiController
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ChargeTypeValidator _validator;
        private readonly IInvalidDataProblemMapper _problemMapper;
        private readonly IChargeTypeService _chargeTypeService;

        public ChargeTypeController(ChargeTypeValidator validator, IInvalidDataProblemMapper problemMapper, IChargeTypeService chargeTypeService)
        {
            _validator = validator;
            _problemMapper = problemMapper;
            _chargeTypeService = chargeTypeService;
        }

        [HttpPost]
        [Route("chargetypes")]
        public IHttpActionResult Create([FromBody] ChargeTypesContract chargeTypes)
        {
            Logger.Info($"Email: {chargeTypes.StableEmail} attempting to save charge types");

            var validation = _validator.Validate(chargeTypes);

            if (false == validation.IsValid)
            {
                var result = _problemMapper.Map(validation.Errors).ToJson;
                return Content(HttpStatusCode.BadRequest, result);
            }

            _chargeTypeService.Save(chargeTypes);
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