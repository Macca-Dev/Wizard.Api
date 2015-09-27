using Wizard.Api.Adapters;
using Wizard.Api.Models;
using Wizard.Api.Services.Interfaces;

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