using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLog;
using Wizard.Api.Models;
using Wizard.Api.Services.Interfaces;

namespace Wizard.Api.Controllers
{
    //[RoutePrefix("v1")]
    public class StableController : ApiController
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IStableService _stableService;
        
        public StableController(IStableService stableService)
        {
            _stableService = stableService;
        }

        [HttpPost]
        [Route("stable")]
        public IHttpActionResult Create([FromBody] StableContract stable)
        {
            Logger.Info(string.Format("Email: {0} saved stable information", stable.StableEmail));
            _stableService.StoreStable(stable);
            return Ok();
        }

        [HttpGet]
        [Route("stable/{email}")]
        public IHttpActionResult GetByEmail(string email)
        {
            Logger.Info(string.Format("Email: {0} asked for data on it's stable", email));
            var stable = _stableService.Get(email);

            return Content(HttpStatusCode.Found, stable);
        }
    }
}