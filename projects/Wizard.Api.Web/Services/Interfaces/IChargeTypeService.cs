using Estable.Lib.Contracts;

namespace Wizard.Api.Services.Interfaces
{
    public interface IChargeTypeService
    {
        string Save(ChargeTypesContract chargeTypes);
        string Get(string email);
    }
}