using System.Threading.Tasks;
using Estable.Lib.Contracts;

namespace Wizard.Api.Services.Interfaces
{
    public interface IFinancialService
    {
        void Save(FinancialContract financial);
        string Get(string email);
    }
}