using System.Threading.Tasks;
using Wizard.Api.Models;

namespace Wizard.Api.Services.Interfaces
{
    public interface IStableService
    {
        Task StoreStable(StableContract stable);
        Task<string> Get(string email);
    }
}