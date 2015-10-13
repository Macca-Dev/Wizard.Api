using System.Web.Http.Cors;
using Wizard.Api.Adapters;
using Wizard.Api.Models;
using Wizard.Api.Services.Interfaces;

namespace Wizard.Api.Services.Implementations
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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