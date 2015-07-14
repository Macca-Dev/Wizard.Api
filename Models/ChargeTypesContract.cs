using System.Collections.Generic;
using Wizard.Api.Contracts;

namespace Wizard.Api.Models
{
    public class ChargeTypesContract : WizardContract
    {
        public IEnumerable<StableChargeType> StableChargeTypes { get; set; }
        public IEnumerable<StandardChargeType> StandardChargeTypes { get; set; }
    }
}