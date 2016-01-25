using System.Threading.Tasks;
using Estable.Lib.Contracts;

namespace Wizard.Api.Services.Interfaces
{
	public interface IFinancialService
	{
		string Save(FinancialContract financial);
		void SaveWithoutValidation(FinancialContract financial);
		string Get(string email);
	}
}