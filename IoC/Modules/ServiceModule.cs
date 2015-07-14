using Ninject.Modules;
using Wizard.Api.Adapters;
using Wizard.Api.Services.Implementations;
using Wizard.Api.Services.Interfaces;

namespace Wizard.Api.IoC.Modules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStorageAdapter>().To<AzureStorageAdapter>().InSingletonScope();
            Bind<IStableService>().To<StableService>().InSingletonScope();
        }
    }
}