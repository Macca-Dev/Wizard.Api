using Ninject.Modules;
using Wizard.Api.Adapters;
using Wizard.Api.Mappers.Implementations;
using Wizard.Api.Mappers.Interfaces;
using Wizard.Api.Services.Implementations;
using Wizard.Api.Services.Interfaces;
using Wizard.Api.Validation;

namespace Wizard.Api.IoC.Modules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStorageAdapter>().To<AzureStorageAdapter>().InSingletonScope();
            Bind<IStableService>().To<StableService>().InSingletonScope();
            Bind<StableValidator>().ToSelf();
            Bind<IInvalidDataProblemMapper>().To<InvalidDataProblemMapper>().InSingletonScope();
            Bind<FinancialValidator>().ToSelf();
            Bind<IFinancialService>().To<FinancialService>();
        }
    }
}