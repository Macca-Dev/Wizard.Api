using Estable.Lib.Adapters;
using Estable.Lib.Contracts;
using Estable.Lib.Mappers;
using Wizard.Api.Services.Interfaces;
using Estable.Lib;
using Wizard.Api.Validation;

namespace Wizard.Api.Services.Implementations
{
    public class AnimalService : IAnimalService
    {
        private readonly IStorageAdapter _storage;
		private readonly IInvalidDataProblemMapper _problemMapper;
		private readonly HorsesValidator _validator;
        public const string ContainerName = Codes.Azure.Containers.Horses;

        public AnimalService(IStorageAdapter storage, IInvalidDataProblemMapper problemMapper, HorsesValidator validator)
        {
            _storage = storage;
			_validator = validator;
			_problemMapper = problemMapper;
        }

        public string Save(HorsesContract horses)
        {
			var validation = _validator.Validate(horses);

			if (false == validation.IsValid)
			{
				return _problemMapper.Map(validation.Errors).ToJson;
			}

			var fileName = $"{horses.StableEmail}.json";
            _storage.UploadText(fileName, horses.ToJson, ContainerName);

			return null;
        }

        public string Get(string email)
        {
            var fileName = $"{email}.json";
            return _storage.DownloadText(fileName, ContainerName);
        }
    }
}