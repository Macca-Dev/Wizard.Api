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

        public void Save(FinancialContract financial)
        {
            var fileName = string.Format("{0}.json", financial.StableEmail);
            _storage.UploadText(fileName, financial.ToJson, ContainerName);
        }

        public string Get(string email)
        {
            var fileName = string.Format("{0}.json", email);
            
            return _storage.DownloadText(fileName, ContainerName);
        }
    }
}