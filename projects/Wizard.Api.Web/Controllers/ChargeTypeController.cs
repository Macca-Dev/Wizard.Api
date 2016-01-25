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
	public class ChargeTypeController : WizardControllerBase
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
		private readonly IChargeTypeService _chargeTypeService;

		public ChargeTypeController(
			IChargeTypeService chargeTypeService,
			EmailValidator emailValidator,
			IInvalidDataProblemMapper problemMapper)
			: base(emailValidator, problemMapper)
		{
			_chargeTypeService = chargeTypeService;
		}

		[HttpPost]
		[Route("chargetypes")]
		public IHttpActionResult Create([FromBody] ChargeTypesContract chargeTypes)
		{
			Logger.Info($"Email: {chargeTypes.StableEmail} attempting to save charge types");

			var problems = _chargeTypeService.Save(chargeTypes);

			if (problems.IsNotNullOrEmpty())
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

			var validation = ValidateGetRequest(email);

			if (validation != null)
			{
				return validation;
			}

			var chargeTypes = _chargeTypeService.Get(email);
			if (chargeTypes == null)
			{
				var charges = new ChargeTypesContract();
				_chargeTypeService.SaveWithoutValidation(charges);
				chargeTypes = charges;
			}

			return Content(HttpStatusCode.OK, chargeTypes);
		}
	}
}