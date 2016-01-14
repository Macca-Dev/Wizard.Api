using Ninject.Modules;
using Estable.Lib.Mappers.Impl;
using Estable.Lib.Mappers;

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