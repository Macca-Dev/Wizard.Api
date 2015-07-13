using Wizard.Api.Contracts;

namespace Wizard.Api.Models
{
    public class StableContract : JsonSerializable
    {
        public string StableName { get; set; }
        public string RacingCode { get; set; }
        public string Trainer { get; set; }
        public string LegalEntity { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
    }
}