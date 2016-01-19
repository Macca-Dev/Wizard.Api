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
            Logger.Info($"Email: {financial.StableEmail} attempting to save financial information");

            var validation = _validator.Validate(financial);

            if (false == validation.IsValid)
            {
                var result = _problemMapper.Map(validation.Errors).ToJson;
                return Content(HttpStatusCode.BadRequest, result);
            }

            _financialService.Save(financial);
            return Ok();
        }

        [HttpGet]
        [Route("financial/{email}")]
        public IHttpActionResult GetByEmail(string email)
        {
            Logger.Info($"Email: {email} asked for its financial data");
            var financial = _financialService.Get(email);

            if(null == financial)
            {
                return NotFound();
            }

            return Content(HttpStatusCode.OK, financial);
        }
    }
}