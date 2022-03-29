using System;
using System.Collections.Generic;

namespace TheLedgerCompany.Models
{
    public class HelpResponse : IResponse
    {
        public override string ToString()
        {
            var result = new List<string>();
            result.Add("Commands available");
            result.Add("\t * LOAN - LOAN BANK_NAME BORROWER_NAME PRINCIPAL NO_OF_YEARS RATE_OF_INTEREST");
            result.Add("\t * PAYMENT - PAYMENT BANK_NAME BORROWER_NAME LUMP_SUM_AMOUNT EMI_NO ");
            result.Add("\t * BALANCE - BALANCE BANK_NAME BORROWER_NAME EMI_NO");
            result.Add("");
            result.Add("or just press enter to exit");
            return string.Join(Environment.NewLine, result);
        }
    }
}