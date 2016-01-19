using Estable.Lib.Adapters;
using Wizard.Api.Models;
using Wizard.Api.Services.Interfaces;
using Estable.Lib;

namespace Wizard.Api.Services.Implementations
{
    public class AnimalService : IAnimalService
    {
        private readonly IStorageAdapter _storage;
        public const string ContainerName = Codes.Azure.Containers.Horses;

        public AnimalService(IStorageAdapter storage)
        {
            _storage = storage;
        }

        public void Save(HorsesContract horses)
        {
            var fileName = $"{horses.StableEmail}.json";
            _storage.UploadText(fileName, horses.ToJson, ContainerName);
        }

        public string Get(string email)
        {
            var fileName = $"{email}.json";
            return _storage.DownloadText(fileName, ContainerName);
        }
    }
}