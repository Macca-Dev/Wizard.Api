using Ninject.Modules;
using Wizard.Api.Validation;

namespace Wizard.Api.IoC.Modules
{
    public class ValidationModule :NinjectModule
    {
        public override void Load()
        {
            Bind<StableValidator>().ToSelf().InSingletonScope();
            Bind<FinancialValidator>().ToSelf().InSingletonScope();
            Bind<ChargeTypeValidator>().ToSelf().InSingletonScope();
        }
    }
}