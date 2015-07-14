using Wizard.Api.Contracts;

namespace Wizard.Api.Models
{
    public class StableChargeType : WizardContract
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }
    }
}