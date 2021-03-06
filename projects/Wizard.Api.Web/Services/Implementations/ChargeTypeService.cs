﻿using Estable.Lib.Extensions;
using Estable.Lib.Adapters;
using Estable.Lib.Contracts;
using Wizard.Api.Services.Interfaces;
using Estable.Lib;
using Wizard.Api.Validation;
using Estable.Lib.Mappers;

namespace Wizard.Api.Services.Implementations
{
	public class ChargeTypeService : IChargeTypeService
	{
		private readonly IStorageAdapter _storage;
		private readonly ChargeTypeValidator _validator;
		private readonly IInvalidDataProblemMapper _problemMapper;
		private const string ContainerName = Codes.Azure.Containers.ChargeTypes;

		public ChargeTypeService(
			IStorageAdapter storage,
			ChargeTypeValidator validator,
			IInvalidDataProblemMapper problemMapper)
		{
			_storage = storage;
			_validator = validator;
			_problemMapper = problemMapper;
		}

		public string Save(ChargeTypesContract chargeTypes)
		{
			var problems = _validator.Validate(chargeTypes);

			if (false == problems.IsValid)
			{
				return _problemMapper.Map(problems.Errors).ToJson;
			}

			var fileName = $"{chargeTypes.StableEmail}.json";
			_storage.UploadText(fileName, chargeTypes.ToJson, ContainerName);

			return string.Empty;
		}

		public void SaveWithoutValidation(ChargeTypesContract chargeTypes)
		{
			var fileName = $"{chargeTypes.StableEmail}.json";
			_storage.UploadText(fileName, chargeTypes.ToJson, ContainerName);
		}

		public ChargeTypesContract Get(string email)
		{
			var fileName = $"{email}.json";
			var file = _storage.DownloadText(fileName, ContainerName);

			if (file == null)
			{
				return null;
			}

			return file.FromJson<ChargeTypesContract>();
		}
	}
}