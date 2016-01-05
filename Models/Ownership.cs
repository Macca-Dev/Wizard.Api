﻿using Wizard.Api.Extensions;
using Wizard.Api.Contracts;

namespace Wizard.Api.Models
{
	public class Ownership : JsonSerializable
	{
		public long OwnerId { get; set; }
		public string OwnerName { get; set; }
		public string PercentOwned { get; set; }
		public bool IsSyndicate { get; set; }
		public string ToJson =>
			this.ToJson<Ownership>();
	}
}