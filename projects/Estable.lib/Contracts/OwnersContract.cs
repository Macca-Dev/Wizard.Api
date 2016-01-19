using Estable.Lib.Extensions;
using System.Collections.Generic;

namespace Estable.Lib.Contracts
{
	public class OwnersContract : StableContract
	{
		IEnumerable<Owner> Owners { get; set; }
		public string ToJson =>
			this.ToJson<OwnersContract>();
	}
}
