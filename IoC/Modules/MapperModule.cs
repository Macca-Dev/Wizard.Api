using Ninject.Modules;
using Wizard.Api.Mappers.Implementations;
using Wizard.Api.Mappers.Interfaces;

namespace Wizard.Api.IoC.Modules
{
    public class MapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IInvalidDataProblemMapper>().To<InvalidDataProblemMapper>().InSingletonScope();
        }
    }
}