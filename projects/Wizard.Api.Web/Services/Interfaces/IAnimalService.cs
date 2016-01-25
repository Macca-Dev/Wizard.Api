using Estable.Lib.Contracts;

namespace Wizard.Api.Services.Interfaces
{
    public interface IAnimalService
    {
        string Save(HorsesContract horses);
        string Get(string email);
    }
}