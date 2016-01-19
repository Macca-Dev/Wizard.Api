using System.Collections.Generic;
using Estable.Lib.Extensions;

namespace Estable.Lib.Contracts
{
	public class HorseOwnershipContract : StableContract
	{
		public long Id { get; set; }
		public long HorseId { get; set; }
		public IEnumerable<Ownership> Ownerships { get; set; }

		public string ToJson => this.ToJson<HorseOwnershipContract>();
	}
}
