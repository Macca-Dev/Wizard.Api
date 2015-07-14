﻿using System;
using Wizard.Api.Extensions;

namespace Wizard.Api.Models
{
    public class FinancialContract : WizardContract
    {
        public string TaxNumber { get; set; }
        public string TaxRate { get; set; }
        public DateTime TaxDate { get; set; }
        public string PreviousTaxRate { get; set; }
        public string NextInvoiceNumber { get; set; }

        public string ToJson
        {
            get { return this.ToJson<FinancialContract>(); }
        }
    }
}