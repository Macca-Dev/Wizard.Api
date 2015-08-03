using System.Threading.Tasks;
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

        public async Task Save(FinancialContract financial)
        {
            var fileName = string.Format("{0}.json", financial.StableEmail);
            await _storage.UploadTextAsync(fileName, financial.ToJson, ContainerName);
        }

        public async Task<string> Get(string email)
        {
            var fileName = string.Format("{0}.json", email);
            
            return await _storage.DownloadTextAsync(fileName, ContainerName);
        }
    }
}