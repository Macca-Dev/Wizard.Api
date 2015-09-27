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

        public void Save(StableContract stable)
        {
            var fileName = $"{stable.StableEmail}.json";
             _storage.UploadText(fileName, stable.ToJson, ContainerName);
        }

        public string Get(string email)
        {
            var fileName = $"{email}.json";
            var stable = _storage.DownloadText(fileName, ContainerName);

            return stable;
        }
    }
}