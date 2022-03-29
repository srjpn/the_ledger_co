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

        public double GetTotalAmountPaid(int emi, double extraPaymentsDone)
        {
            var totalAmount = Amount - extraPaymentsDone;
            double amountPaid = 0;
            for (var i = 0; i < emi; i++)
            {
                var currentEmi = totalAmount > Emi ? Emi : totalAmount;
                amountPaid = amountPaid + currentEmi;
                totalAmount = totalAmount - currentEmi;

            }
            return extraPaymentsDone + amountPaid;
        }

        public int EmiPending(int emi, double extraPaymentsDone) => Convert.ToInt32(Math.Ceiling((Amount - GetTotalAmountPaid(emi, extraPaymentsDone)) / Emi));
    }
}