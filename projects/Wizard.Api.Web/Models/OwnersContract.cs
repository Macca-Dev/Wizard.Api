using System.Collections.Generic;
using Wizard.Api.Extensions;

namespace Wizard.Api.Models
{
	public class OwnersContract : WizardContract
	{
		IEnumerable<Owner> Owners { get; set; }
		public string ToJson =>
			this.ToJson<OwnersContract>();
	}
}