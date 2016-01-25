using Estable.Lib.Contracts;

namespace Wizard.Api.Services.Interfaces
{
	public interface IChargeTypeService
	{
		string Save(ChargeTypesContract chargeTypes);
		void SaveWithoutValidation(ChargeTypesContract chargeTypes);
		ChargeTypesContract Get(string email);
	}
}