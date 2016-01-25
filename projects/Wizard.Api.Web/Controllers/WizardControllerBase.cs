using System.Net;
using System.Web.Http;
using Estable.Lib.Mappers;
using Wizard.Api.Validation;
namespace Wizard.Api.Controllers
{
	public class WizardControllerBase : ApiController
	{
		private readonly EmailValidator _emailValidator;
		private readonly IInvalidDataProblemMapper _problemMapper;
		public WizardControllerBase(
			EmailValidator emailValidator,
			IInvalidDataProblemMapper problemMapper)
		{
			_emailValidator = emailValidator;
			_problemMapper = problemMapper;
		}

		protected virtual IHttpActionResult ValidateGetRequest(string email)
		{
			var validation = _emailValidator.Validate(email);

			if (false == validation.IsValid)
			{
				var problems = _problemMapper.Map(validation.Errors).ToJson;
				return Content(HttpStatusCode.BadRequest, problems);
			}

			return null;
		}
    }
}