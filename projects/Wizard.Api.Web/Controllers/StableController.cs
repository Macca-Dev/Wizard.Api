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
	public class StableController : WizardControllerBase
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		private readonly IStableService _stableService;

		public StableController(
			IStableService stableService,
			EmailValidator emailValidator,
			IInvalidDataProblemMapper problemMapper)
			: base(emailValidator, problemMapper)
		{
			_stableService = stableService;
		}

		[HttpPost]
		[Route("stable")]
		public IHttpActionResult Create([FromBody] StableDataContract stable)
		{
			Logger.Info($"Email: {stable.StableEmail} attempting to save stable information");

			var problems = _stableService.Save(stable);
			if (problems != null)
			{
				return Content(HttpStatusCode.BadRequest, problems);
			}

			return Ok();
		}

		[HttpGet]
		[Route("stable/{email}")]
		public IHttpActionResult GetByEmail(string email)
		{
			Logger.Info($"Email: {email} asked for data on it's stable");

			var validation = ValidateGetRequest(email);

			if (validation != null)
			{
				return validation;
			}

			var stable = _stableService.Get(email);

			if (null == stable)
			{
				var obj = new StableDataContract();
				_stableService.SaveWithoutValidation(obj);
				stable = obj;
			}

			return Content(HttpStatusCode.OK, stable);
		}
	}
}