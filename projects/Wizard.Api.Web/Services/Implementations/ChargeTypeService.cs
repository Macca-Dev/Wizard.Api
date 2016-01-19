using System.Web.Http.Cors;
using Estable.Lib.Adapters;
using Estable.Lib.Contracts;
using Wizard.Api.Services.Interfaces;
using Estable.Lib;

namespace Wizard.Api.Services.Implementations
{
    public class ChargeTypeService : IChargeTypeService
    {
        private readonly IStorageAdapter _storage;
        private const string ContainerName = Codes.Azure.Containers.ChargeTypes;

        public ChargeTypeService(IStorageAdapter storage)
        {
            _storage = storage;
        }

        public void Save(ChargeTypesContract chargeTypes)
        {
            var fileName = $"{chargeTypes.StableEmail}.json";
            _storage.UploadText(fileName, chargeTypes.ToJson, ContainerName);
        }

        public string Get(string email)
        {
            var fileName = $"{email}.json";
            return _storage.DownloadText(fileName, ContainerName);
        }
    }
}