using NLog;
using Wizard.Api.Mappers.Interfaces;
using Wizard.Api.Services.Interfaces;
using Wizard.Api.Validation;

namespace Wizard.Api.Controllers
{
    public class AnimalController
    {
        private readonly IAnimalService _animalService;
        private readonly HorseValidator _validator;
        private readonly IInvalidDataProblemMapper _problemMapper;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public AnimalController(IAnimalService animalService , HorseValidator validator, IAnimalValidator, IInvalidDataProblemMapper problemMapper)
        {
            _animalService = animalService;
            _validator = validator;
            _problemMapper = problemMapper;
        }
    }
}