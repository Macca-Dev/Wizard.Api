using Wizard.Api.Contracts;
using Wizard.Api.Extensions;

namespace Wizard.Api.Models
{
    public class StableChargeType : WizardContract
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }

        public string ToJson
        {
            get { return this.ToJson<StableChargeType>(); }
        }
    }
}