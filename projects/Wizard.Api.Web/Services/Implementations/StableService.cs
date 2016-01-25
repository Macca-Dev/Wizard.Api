using Estable.Lib.Adapters;
using Estable.Lib.Contracts;
using Wizard.Api.Services.Interfaces;
using Estable.Lib;
using Estable.Lib.Mappers;
using Wizard.Api.Validation;

namespace Wizard.Api.Services.Implementations
{
    public class StableService : IStableService
    {
        private readonly IStorageAdapter _storage;
		private readonly StableValidator _validator;
		private readonly IInvalidDataProblemMapper _problemMapper;
        private const string ContainerName = Codes.Azure.Containers.Stable;

        public StableService(
			IStorageAdapter storage,
			StableValidator validator, 
			IInvalidDataProblemMapper problemMapper)
        {
			_storage = storage;
			_validator = validator;
			_problemMapper = problemMapper;
        }

        public string Save(StableDataContract stable)
        {
			var problems = _validator.Validate(stable);

			if (!problems.IsValid)
			{
				return _problemMapper.Map(problems.Errors).ToJson;
			}

			var fileName = $"{stable.StableEmail}.json";
            _storage.UploadText(fileName, stable.ToJson, ContainerName);

			return string.Empty;
        }

		public void SaveWithoutValidation(StableDataContract stable)
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