using Ninject.Modules;
using Wizard.Api.Adapters;

namespace Wizard.Api.IoC.Modules
{
    public class AzureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStorageAdapter>().To<AzureStorageAdapter>().InSingletonScope();
        }
    }
}