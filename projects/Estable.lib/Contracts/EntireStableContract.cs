using Estable.Lib.Extensions;

namespace Estable.Lib.Contracts
{
	public class EntireStableContract : JsonSerializable
	{
		public StableDataContract Metadatadata { get; set; }
		public FinancialContract FinancialData { get; set; }
		public ChargeTypesContract ChargeTypes { get; set; }
		public HorsesContract Horses { get; set; }
		public OwnersContract Owners { get; set; }
		public HorseOwnershipContract Ownerships { get; set; }

		public string ToJson =>
			this.ToJson<EntireStableContract>();
	}
}
