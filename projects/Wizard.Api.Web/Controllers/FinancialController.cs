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
    public class FinancialController : WizardControllerBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly IFinancialService _financialService;

		public FinancialController(
            IFinancialService financialService,
			EmailValidator emailValidator,
			IInvalidDataProblemMapper problemMapper)
			: base(emailValidator, problemMapper)
		{
            _financialService = financialService;
        }

        [HttpPost]
        [Route("financial")]
        public IHttpActionResult Create([FromBody] FinancialContract financial)
        {
            Logger.Info($"Email: {financial.StableEmail} attempting to save financial information");
			
			var problems = _financialService.Save(financial);

			if(null != problems)
			{
				return Content(HttpStatusCode.BadRequest, problems);
			}

            return Ok();
        }

        [HttpGet]
        [Route("financial/{email}")]
        public IHttpActionResult GetByEmail(string email)
        {
            Logger.Info($"Email: {email} asked for its financial data");

			var validation = ValidateGetRequest(email);

			if (validation != null)
			{
				return validation;
			}

			var financial = _financialService.Get(email);

            if(null == financial)
            {
				var obj = new FinancialContract();
				_financialService.SaveWithoutValidation(obj);
				financial = obj.ToJson;
            }

            return Content(HttpStatusCode.OK, financial);
        }
    }
}