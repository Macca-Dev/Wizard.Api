using Wizard.Api.Contracts;
using Wizard.Api.Extensions;

namespace Wizard.Api.Models
{
    public class Owner : JsonSerializable
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OwnerEmail { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

        public string ToJson => this.ToJson<Owner>();
    }
}