using System.Threading.Tasks;
using Wizard.Api.Models;

namespace Wizard.Api.Services.Interfaces
{
    public interface IStableService
    {
        string Get(string email);
        void Save(StableContract stable);
    }
}