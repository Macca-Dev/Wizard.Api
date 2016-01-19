using Estable.Lib.Adapters;
using Estable.Lib.Contracts;
using Wizard.Api.Services.Interfaces;
using Estable.Lib;

namespace Wizard.Api.Services.Implementations
{
    public class FinancialService : IFinancialService
    {
        private readonly IStorageAdapter _storage;
        private const string ContainerName = Codes.Azure.Containers.Financial;

        public FinancialService(IStorageAdapter storage)
        {
            _storage = storage;
        }

        public void Save(FinancialContract financial)
        {
            var fileName = $"{financial.StableEmail}.json";
            _storage.UploadText(fileName, financial.ToJson, ContainerName);
        }

        public string Get(string email)
        {
            var fileName = $"{email}.json";
            return _storage.DownloadText(fileName, ContainerName);
        }
    }
}