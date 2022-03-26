using System.Collections.Generic;
using System.Linq;
using TheLedgerCompany.Models;

namespace TheLedgerCompany.Services
{
    public class PaymentService
    {
        private readonly List<Payment> payments = new List<Payment>();

        public void Add(Payment payment)
        {
            payments.Add(payment);
        }

        public int GetPaymentDoneBefore(string bankName, string borrowerName, int emi)
        {
            return payments.Where(x => x.BankName == bankName && x.BorrowerName == borrowerName && x.Emi <= emi).Sum(x => x.Amount);
        }
    }
}