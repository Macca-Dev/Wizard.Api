using Estable.Lib.Extensions;

namespace Estable.Lib.Contracts
{
	public class Ownership : JsonSerializable
	{
		public long OwnerId { get; set; }
		public string OwnerName { get; set; }
		public string PercentOwned { get; set; }
		public bool IsSyndicate { get; set; }
		public string ToJson =>
			this.ToJson<Ownership>();
	}
}
