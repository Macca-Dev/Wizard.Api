using Estable.Lib.Contracts;

namespace Wizard.Api.Services.Interfaces
{
	public interface IAnimalService
	{
		string Save(HorsesContract horses);
		void SaveWithoutValidation(HorsesContract horses);
		HorsesContract Get(string email);
	}
}