using Estable.Lib.Adapters;
using Estable.Lib.Contracts;
using Wizard.Api.Services.Interfaces;
using Estable.Lib;
using Wizard.Api.Validation;
using Estable.Lib.Mappers;

namespace Wizard.Api.Services.Implementations
{
    public class FinancialService : IFinancialService
    {
        private readonly IStorageAdapter _storage;
		private readonly FinancialValidator _validator;
		private readonly IInvalidDataProblemMapper _problemMapper;
		private const string ContainerName = Codes.Azure.Containers.Financial;

        public FinancialService(
			IStorageAdapter storage,
			FinancialValidator validator,
			IInvalidDataProblemMapper problemMapper)
        {
            _storage = storage;
			_validator = validator;
			_problemMapper = problemMapper;
		}

        public string Save(FinancialContract financial)
        {
			var validation = _validator.Validate(financial);

			if (false == validation.IsValid)
			{
				return _problemMapper.Map(validation.Errors).ToJson;
			}

			var fileName = $"{financial.StableEmail}.json";
            _storage.UploadText(fileName, financial.ToJson, ContainerName);

			return string.Empty;
        }

        public string Get(string email)
        {
            var fileName = $"{email}.json";
            return _storage.DownloadText(fileName, ContainerName);
        }
    }
}