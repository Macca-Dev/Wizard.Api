using Ninject.Modules;
using Estable.Lib.Contracts;
using Estable.Lib.Adapters;

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