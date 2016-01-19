using Estable.Lib.Contracts;

namespace Wizard.Api.Services.Interfaces
{
    public interface IAnimalService
    {
        void Save(HorsesContract horses);
        string Get(string email);
    }
}