using System;
using Wizard.Api.Contracts;

namespace Wizard.Api.Models
{
    public class FinancialContract : JsonSerializable
    {
        public string TaxNumber { get; set; }
        public string TaxRate { get; set; }
        public DateTime TaxDate { get; set; }
        public string PreviousTaxRate { get; set; }
        public string NextInvoiceNumber { get; set; }
    }
}