using System.Collections.Generic;
using Wizard.Api.Contracts;

namespace Wizard.Api.Models
{
    public class HorseOwnershipContract : JsonSerializable
    {
        public long Id { get; set; }
        public long HorseId { get; set; }
        public IEnumerable<Ownership> Ownerships { get; set; }
    }

    public class Ownership
    {
        public long OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string PercentOwned { get; set; }
        public bool IsSyndicate { get; set; }
    }
}