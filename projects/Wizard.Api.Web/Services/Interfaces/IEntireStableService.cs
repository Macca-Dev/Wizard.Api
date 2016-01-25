using Estable.Lib.Contracts;

namespace Wizard.Api.Services.Interfaces
{
	public interface IEntireStableService
	{
		string Save(EntireStableContract contract);
		string Get(string email);
	}
}