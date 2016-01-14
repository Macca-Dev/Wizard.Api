using System.Collections.Generic;
using Estable.Lib.Extensions;

namespace Wizard.Api.Models
{
    public class ChargeTypesContract : WizardContract
    {
        public IEnumerable<StableChargeType> StableChargeTypes { get; set; }
        public IEnumerable<StandardChargeType> StandardChargeTypes { get; set; }

        public string ToJson => 
            this.ToJson<ChargeTypesContract>();
    }
}