using Wizard.Api.Contracts;


namespace Wizard.Api.Models
{
    public class WizardContract : JsonSerializable
    {
        public string StableEmail { get; set; }
        public string StableName { get; set; }
    }
}