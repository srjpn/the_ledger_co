using TheLedgerCompany.Models;
using TheLedgerCompany.Services;

namespace TheLedgerCompany.Commands
{
    public class PaymentCommand
    {
        private readonly PaymentService paymentService;
        public PaymentCommand(PaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public void MakePayment(string bankName, string borrowerName, int amount, int emi)
        {
            var payment = new Payment
            {
                BankName = bankName,
                BorrowerName = borrowerName,
                Amount = amount,
                Emi = emi
            };
            paymentService.Add(payment);
        }
    }
}