using Estable.Lib.Extensions;

namespace Estable.Lib.Contracts
{
	public class StandardChargeType : JsonSerializable
	{
		public long Id { get; set; }
		public string Description { get; set; }
		public string Unit { get; set; }
		public string Rate { get; set; }
		public bool InStable { get; set; }

		public string ToJson =>
			this.ToJson<StandardChargeType>();
	}
}
