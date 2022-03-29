using TheLedgerCompany.Models;
using TheLedgerCompany.Services;

namespace TheLedgerCompany.Commands
{
    [Action("LOAN")]
    public class LoanCommand : IAction
    {
        private readonly ILoanService loanService;
        public LoanCommand(ILoanService loanService)
        {
            this.loanService = loanService;
        }

        public IResponse Execute(string[] args)
        {
            var bankName = args[0];
            var borrowerName = args[1];
            var principal = int.Parse(args[2]);
            var noOfYears = int.Parse(args[3]);
            var interestRate = int.Parse(args[4]);

            var loan = new Loan()
            {
                BankName = bankName,
                BorrowerName = borrowerName,
                Principal = principal,
                NoOfYears = noOfYears,
                InterestRate = interestRate
            };
            loanService.Add(loan);
            return null;
        }
    }
}