using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using NLog;
using Wizard.Api.Mappers.Interfaces;
using Wizard.Api.Models;
using Wizard.Api.Problems;
using Wizard.Api.Services.Interfaces;
using Wizard.Api.Validation;

namespace Wizard.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FinancialController : ApiController
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly IFinancialService _financialService;
        private readonly FinancialValidator _validator;
        private readonly IInvalidDataProblemMapper _problemMapper;

        public FinancialController(
            IFinancialService financialService, 
            FinancialValidator validator,  
            IInvalidDataProblemMapper problemMapper)
        {
            _financialService = financialService;
            _validator = validator;
            _problemMapper = problemMapper;
        }

        [HttpPost]
        [Route("financial")]
        public IHttpActionResult Create([FromBody] FinancialContract financial)
        {
            Logger.Info(string.Format("Email: {0} attempting to save financial information", financial.StableEmail));

            var failures = _validator.Validate(financial);

            if (!failures.IsValid)
            {
                var result = _problemMapper.Map(failures.Errors).ToJson;
                return Content(HttpStatusCode.BadRequest, result);
            }

            _financialService.Save(financial);
            return Ok();
        }

        [HttpGet]
        [Route("financial/{email}")]
        public IHttpActionResult GetByEmail(string email)
        {
            Logger.Info(string.Format("Email: {0} asked for its financial data", email));
            
            return Content(
                HttpStatusCode.OK,
                _financialService.Get(email));
        }
    }
}