using System;
using TheLedgerCompany.Models;

namespace TheLedgerCompany.Commands
{
    public class LoanCommand
    {
        public void Create(string bankName, string borrowerName, int principal, int noOfYears, int interestRate)
        {
            var loan = new Loan(bankName, borrowerName, principal, noOfYears, interestRate);
            Loan.Add(loan);
        }
    }
}