using System.Collections.Generic;
using Estable.Lib.Extensions;

namespace Estable.Lib.Contracts
{
	public class HorsesContract : StableContract
	{
		public IEnumerable<Horse> Horses { get; set; }

		public string ToJson =>
			this.ToJson<HorsesContract>();
	}
}
