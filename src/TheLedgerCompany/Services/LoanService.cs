using System.Collections.Generic;
using System.Linq;
using TheLedgerCompany.Models;

namespace TheLedgerCompany.Services
{
    public interface ILoanService
    {
        void Add(Loan loan);
        Loan GetByBankAndBorrowerName(string bankName, string borrowerName);
    }

    public class LoanService : ILoanService
    {
        private readonly List<Loan> loans = new List<Loan>();

        public void Add(Loan loan)
        {
            loans.Add(loan);
        }

        public Loan GetByBankAndBorrowerName(string bankName, string borrowerName)
        {
            return loans.First(x => x.BankName == bankName && x.BorrowerName == borrowerName);
        }
    }
}