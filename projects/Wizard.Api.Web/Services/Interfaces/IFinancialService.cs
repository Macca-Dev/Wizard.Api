using System.Threading.Tasks;
using Wizard.Api.Models;

namespace Wizard.Api.Services.Interfaces
{
    public interface IFinancialService
    {
        void Save(FinancialContract financial);
        string Get(string email);
    }
}