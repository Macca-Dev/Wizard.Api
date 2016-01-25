using Wizard.Api.Services.Interfaces;
using Estable.Lib.Contracts;
using NLog;
using Estable.Lib.Mappers;
using Estable.Lib.Extensions;

namespace Wizard.Api.Services.Implementations
{
	public class EntireStableService : IEntireStableService
	{
		private readonly IAnimalService _animalService;
		private readonly IChargeTypeService _chargeTypeService;
		private readonly IFinancialService _financialService;
		private readonly IStableService _stableService;
		private readonly IInvalidDataProblemMapper _problemMapper;
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		public EntireStableService(
			IAnimalService animalService,
			IChargeTypeService chargeTypeService,
			IFinancialService financialService,
			IStableService stableService,
			IInvalidDataProblemMapper problemMapper)
		{
			_animalService = animalService;
			_chargeTypeService = chargeTypeService;
			_financialService = financialService;
			_stableService = stableService;
			_problemMapper = problemMapper;
		}

		public string Save(EntireStableContract contract)
		{
			Logger.Info($"Email: {contract.FinancialData.StableEmail} attempting to save entire stable.");

			var problems = _stableService.Save(contract.Metadata);
			problems += _financialService.Save(contract.FinancialData);
			problems += _chargeTypeService.Save(contract.ChargeTypes);
			problems += _animalService.Save(contract.Horses);

			if (false == problems.IsNullOrEmpty())
			{
				return problems;
			}

			return string.Empty;
		}

		public string Get(string email)
		{
			var stable = new EntireStableContract
			{
				Metadata = _stableService.Get(email).FromJson<StableDataContract>(),
				FinancialData = _financialService.Get(email).FromJson<FinancialContract>(),
				ChargeTypes = _chargeTypeService.Get(email).FromJson<ChargeTypesContract>(),
				Horses = _animalService.Get(email).FromJson<HorsesContract>()
			};

			return stable.ToJson<EntireStableContract>();
		}
	}
}