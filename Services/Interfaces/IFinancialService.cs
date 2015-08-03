using System.Threading.Tasks;
using Wizard.Api.Models;

namespace Wizard.Api.Services.Interfaces
{
    public interface IFinancialService
    {
        Task Save(FinancialContract financial);
        Task<string> Get(string email);
    }
}