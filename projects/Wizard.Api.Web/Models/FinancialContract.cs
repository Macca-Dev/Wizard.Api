using System;
using Estable.Lib.Extensions;

namespace Wizard.Api.Models
{
    public class FinancialContract : StableContract
    {
        public string TaxNumber { get; set; }
        public string TaxRate { get; set; }
        public string TaxDate { get; set; }
        public string PreviousTaxRate { get; set; }
        public string NextInvoiceNumber { get; set; }

        public string ToJson => 
            this.ToJson<FinancialContract>();
    }
}