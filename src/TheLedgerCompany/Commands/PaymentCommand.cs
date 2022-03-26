using TheLedgerCompany.Models;

namespace TheLedgerCompany.Commands
{
    public class PaymentCommand
    {
        public void MakePayment(string bankName, string borrowerName, int amount, int emi)
        {
            var payment = new Payment(bankName, borrowerName, amount, emi);
            Payment.Add(payment);
        }

    }
}