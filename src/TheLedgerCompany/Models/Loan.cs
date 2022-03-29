using System;

namespace TheLedgerCompany.Models
{
    public class Loan
    {
        public string BankName { get; set; }
        public string BorrowerName { get; set; }
        public double Principal { get; set; }
        public double NoOfYears { get; set; }
        public double InterestRate { get; set; }

        private double Interest => (this.Principal * this.NoOfYears * this.InterestRate) / 100;

        private double Amount => this.Principal + this.Interest;

        private double Emi => Math.Ceiling(Amount / (this.NoOfYears * 12));

        public double GetTotalAmountPaid(int emi) => this.Emi * emi;

        private double GetBalanceAmount(int emi, double extraPaymentsDone) => GetTotalAmountPaid(emi) + extraPaymentsDone;

        public double EmiPending(int emi, double extraPaymentsDone) => Math.Ceiling((Amount - GetBalanceAmount(emi, extraPaymentsDone))/Emi);
    }
}