using Estable.Lib.Contracts;


namespace Wizard.Api.Models
{
    public class StableContract : JsonSerializable
    {
        public string StableEmail { get; set; }
        public string StableName { get; set; }
    }
}