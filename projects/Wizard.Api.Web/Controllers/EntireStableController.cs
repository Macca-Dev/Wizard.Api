using System.Web.Http;
using Estable.Lib.Contracts;
using Wizard.Api.Services.Interfaces;
using System.Web.Http.Cors;
using System.Net;
using NLog;
using Estable.Lib.Extensions;

namespace Wizard.Api.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class EntireStableController : ApiController
    {
		IEntireStableService _service;
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		public EntireStableController(IEntireStableService service)
		{
			_service = service;
		}

		[HttpPost]
		[Route("entirestable/import/json")]
		public IHttpActionResult Create([FromBody] EntireStableContract contract)
		{
			_service.Save(contract);

			return Ok();
		}

		[HttpGet]
		[Route("entirestable/export/json/{email}")]
		public IHttpActionResult GetByEmail(string email)
		{
			Logger.Info($"Email: {email} asked for all of its data");

			var stable = _service.Get(email);
			if(stable.IsNullOrEmpty())
			{
				return NotFound();
			}

			return Content(HttpStatusCode.OK, stable);
		}
	}
}