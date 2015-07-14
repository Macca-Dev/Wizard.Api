using System.Threading.Tasks;
using Wizard.Api.Adapters;
using Wizard.Api.Extensions;
using Wizard.Api.Models;

namespace Wizard.Api.Services
{
    public interface IEmailService
    {
        Task StoreEmail(string fileName, string email);
    }

    public class EmailService : IEmailService
    {
        private readonly IStorageAdapter _storage;

        public EmailService(IStorageAdapter storage)
        {
            _storage = storage;
        }

        public async Task StoreEmail(string fileName, string email)
        {
            var emailToSave = new EmailContract
                {
                    StableEmail = email
                };

            await _storage.UploadTextAsync(fileName, emailToSave.ToJson<EmailContract>(), Codes.Azure.Containers.Stable);
        }
    }
}