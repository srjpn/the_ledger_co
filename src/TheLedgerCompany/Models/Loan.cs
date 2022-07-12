using System;
using System.Collections.Generic;
using System.Linq;

namespace TheLedgerCompany.Models
{
    public class Loan
    {
        public string BankName { get; set; }
        public string BorrowerName { get; set; }
        public double Principal { get; set; }
        public double NoOfYears { get; set; }
        public IList<InterestRate> InterestRates { get; set; }

        private double Interest(int emi) => (this.Principal * this.NoOfYears * GetInterestRate(emi)) / 100;

        private double GetInterestRate(int emi) => this.InterestRates.Where(x => x.Month <= emi).OrderBy(x => x.Month).Last().Rate;

        private double Amount(int emi) => this.Principal + this.Interest(emi);

        private double Emi(int emi) => Math.Ceiling(Amount(emi) / (this.NoOfYears * 12));

        public double GetTotalAmountPaid(int emi, double extraPaymentsDone)
        {
            var totalAmount = Amount(emi) - extraPaymentsDone;
            double amountPaid = 0;
            for (var i = 0; i < emi; i++)
            {
                var currentEmi = totalAmount > Emi(emi) ? Emi(emi) : totalAmount;
                amountPaid = amountPaid + currentEmi;
                totalAmount = totalAmount - currentEmi;

            }
            return extraPaymentsDone + amountPaid;
        }

        public int EmiPending(int emi, double extraPaymentsDone) => Convert.ToInt32(Math.Ceiling((Amount(emi) - GetTotalAmountPaid(emi, extraPaymentsDone)) / Emi(emi)));
    }
}