using TheLedgerCompany.Models;
using TheLedgerCompany.Services;

namespace TheLedgerCompany.Commands
{
    public class LoanCommand
    {
        private readonly LoanService loanService;
        public LoanCommand(LoanService loanService)
        {
            this.loanService = loanService;
        }

        public void Create(string bankName, string borrowerName, double principal, double noOfYears, double interestRate)
        {
            var loan = new Loan()
            {
                BankName = bankName,
                BorrowerName = borrowerName,
                Principal = principal,
                NoOfYears = noOfYears,
                InterestRate = interestRate
            };
            loanService.Add(loan);
        }
    }
}