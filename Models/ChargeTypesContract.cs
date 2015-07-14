using System.Collections.Generic;
using Wizard.Api.Extensions;

namespace Wizard.Api.Models
{
    public class ChargeTypesContract : WizardContract
    {
        public IEnumerable<StableChargeType> StableChargeTypes { get; set; }
        public IEnumerable<StandardChargeType> StandardChargeTypes { get; set; }

        public string ToJson
        {
            //todo this may fail. might need to do something a little more intelligent with complex objects like this.
            get { return this.ToJson<ChargeTypesContract>(); }
        }
    }
}