using System.Web.Http;
using Wizard.Api.Models;

namespace Wizard.Api.Controllers
{
    public class StableController : ApiController
    {
        [HttpPost]
        public void Post([FromBody] StableContract stable)
        {

        }
    }
}