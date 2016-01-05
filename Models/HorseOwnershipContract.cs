﻿using System.Collections.Generic;
using Wizard.Api.Extensions;

namespace Wizard.Api.Models
{
    public class HorseOwnershipContract : WizardContract
    {
        public long Id { get; set; }
        public long HorseId { get; set; }
        public IEnumerable<Ownership> Ownerships { get; set; }

        public string ToJson => this.ToJson<HorseOwnershipContract>();
    }
}