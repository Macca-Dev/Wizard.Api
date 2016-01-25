using Estable.Lib.Extensions;
using System.Collections.Generic;

namespace Estable.Lib.Contracts
{
	public class ChargeTypesContract : StableContract
	{
		public IEnumerable<StableChargeType> StableChargeTypes { get; set; }
		public IEnumerable<StandardChargeType> StandardChargeTypes { get; set; }
		public string ToJson =>
			this.ToJson<ChargeTypesContract>();
	}
}