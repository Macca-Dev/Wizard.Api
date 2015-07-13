using Wizard.Api.Contracts;

namespace Wizard.Api.Models
{
    public class OwnersContract : JsonSerializable
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}