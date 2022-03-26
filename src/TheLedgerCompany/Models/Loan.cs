using System.Collections.Generic;
using System.Linq;

namespace TheLedgerCompany.Models
{
    public class Loan
    {
        private readonly string bankName;
        private readonly string borrowerName;
        private readonly int principal;
        private readonly int noOfYears;
        private readonly int interestRate;

        private static IList<Loan> loans = new List<Loan>();

        public Loan(string bankName, string borrowerName, int principal, int noOfYears, int interestRate)
        {
            this.bankName = bankName;
            this.borrowerName = borrowerName;
            this.principal = principal;
            this.noOfYears = noOfYears;
            this.interestRate = interestRate;
        }

        private int Interest => this.principal * this.noOfYears * (this.interestRate / 100);

        private int Amount => this.principal + this.Interest;

        private int Emi => Amount / (this.noOfYears * 12);

        public int GetTotalAmountPaid(int emi) => this.Emi * emi;

        public int EmiPending(int emi) => (Amount / Emi) - emi;

        public static void Add(Loan loan)
        {
            loans.Add(loan);
        }

        public static Loan GetByBankAndBorrowerName(string bankName, string borrowerName)
        {
            return loans.First(x => x.bankName == bankName && x.borrowerName == borrowerName);
        }
    }
}