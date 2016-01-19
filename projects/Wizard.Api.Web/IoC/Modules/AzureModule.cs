using Ninject.Modules;
using Estable.Lib.Adapters;
using Estable.Lib.Adapters.Impl;

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