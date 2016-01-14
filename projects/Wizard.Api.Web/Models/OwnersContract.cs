using System.Collections.Generic;
using Estable.Lib.Extensions;

namespace Wizard.Api.Models
{
	public class OwnersContract : WizardContract
	{
		IEnumerable<Owner> Owners { get; set; }
		public string ToJson =>
			this.ToJson<OwnersContract>();
	}
}