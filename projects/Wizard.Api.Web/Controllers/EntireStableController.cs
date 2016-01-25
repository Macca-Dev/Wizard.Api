using System.Web.Http;
using Estable.Lib.Contracts;
using Wizard.Api.Services.Interfaces;
using System.Web.Http.Cors;


namespace Wizard.Api.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class EntireStableController : ApiController
    {
		IEntireStableService _service;
        public EntireStableController(IEntireStableService service)
		{
			_service = service;
		}

		[HttpPost]
		[Route("import/json")]
		public IHttpActionResult Create([FromBody] EntireStableContract contract)
		{
			_service.Save(contract);

			return Ok();
		}
	}
}