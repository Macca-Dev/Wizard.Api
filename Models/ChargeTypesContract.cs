using System.Collections.Generic;
using Wizard.Api.Contracts;

namespace Wizard.Api.Models
{
    public class ChargeTypesContract : JsonSerializable
    {
        public IEnumerable<StableChargeType> StableChargeTypes { get; set; }
        public IEnumerable<StandardChargeType> StandardChargeTypes { get; set; }
    }
}