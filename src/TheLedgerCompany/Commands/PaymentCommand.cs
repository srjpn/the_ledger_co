using TheLedgerCompany.Models;
using TheLedgerCompany.Services;

namespace TheLedgerCompany.Commands
{
    public class PaymentCommand : IAction
    {
        private readonly PaymentService paymentService;
        public PaymentCommand(PaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public IResponse Execute(string[] args)
        {
            var bankName = args[0];
            var borrowerName = args[1];
            var amount = int.Parse(args[2]);
            var emi = int.Parse(args[3]);
            MakePayment(bankName, borrowerName, amount, emi);
            return null;
        }

        private void MakePayment(string bankName, string borrowerName, int amount, int emi)
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