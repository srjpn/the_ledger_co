using System.Collections.Generic;
using System.Linq;

namespace TheLedgerCompany.Models
{
    public class Payment
    {
        private string bankName;
        private string borrowerName;
        private int amount;
        private int emi;

        private static readonly IList<Payment> payments = new List<Payment>();

        public Payment(string bankName, string borrowerName, int amount, int emi)
        {
            this.bankName = bankName;
            this.borrowerName = borrowerName;
            this.amount = amount;
            this.emi = emi;
        }

        public static void Add(Payment payment)
        {
            payments.Add(payment);
        }

        public static int GetPaymentDoneBefore(string bankName, string borrowerName, int emi)
        {
            return payments.Where(x => x.bankName == bankName && x.borrowerName == borrowerName && x.emi < emi).Sum(x => x.amount);
        }
    }
}