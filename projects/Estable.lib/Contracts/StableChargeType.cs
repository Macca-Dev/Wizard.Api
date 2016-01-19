using System;
using System.Collections.Generic;
using System.Linq;
using Estable.Lib.Extensions;

namespace Estable.Lib.Contracts
{
	public class StableChargeType : JsonSerializable
	{
		public long Id { get; set; }
		public string Description { get; set; }
		public string Rate { get; set; }

		public string ToJson =>
			this.ToJson<StableChargeType>();
	}
}
