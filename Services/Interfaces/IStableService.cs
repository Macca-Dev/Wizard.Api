using System.Threading.Tasks;
using Wizard.Api.Models;

namespace Wizard.Api.Services.Interfaces
{
    public interface IStableService
    {
        Task StoreStable(StableContract stable);
        Task<StableContract> Get(string email);
    }
}