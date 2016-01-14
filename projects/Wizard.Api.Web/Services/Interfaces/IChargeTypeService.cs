using Wizard.Api.Models;

namespace Wizard.Api.Services.Interfaces
{
    public interface IChargeTypeService
    {
        void Save(ChargeTypesContract chargeTypes);
        string Get(string email);
    }
}