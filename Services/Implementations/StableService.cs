using System.Threading.Tasks;
using Wizard.Api.Adapters;
using Wizard.Api.Models;
using Wizard.Api.Services.Interfaces;

namespace Wizard.Api.Services.Implementations
{
    public class StableService : IStableService
    {
        private readonly IStorageAdapter _storage;
        private const string ContainerName = Codes.Azure.Containers.Stable;

        public StableService(IStorageAdapter storage)
        {
            _storage = storage;
        }

        public async Task StoreStable(StableContract stable)
        {
            var fileName = string.Format("{0}.json", stable.StableEmail);
            await _storage.UploadTextAsync(fileName, stable.ToJson, ContainerName);
        }

        public async Task<string> Get(string email)
        {
            var fileName = string.Format("{0}.json", email);
            var stable =  await _storage.DownloadTextAsync(fileName, ContainerName);

            return stable;
        }
    }
}