using TheLedgerCompany.Models;
using TheLedgerCompany.Services;

namespace TheLedgerCompany.Commands
{
    [Action("PAYMENT")]
    public class PaymentCommand : IAction
    {
        private readonly IPaymentService paymentService;
        public PaymentCommand(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public IResponse Execute(string[] args)
        {
            var bankName = args[0];
            var borrowerName = args[1];
            var amount = int.Parse(args[2]);
            var emi = int.Parse(args[3]);
            var payment = new Payment
            {
                BankName = bankName,
                BorrowerName = borrowerName,
                Amount = amount,
                Emi = emi
            };
            paymentService.Add(payment);
            return null;
        }
    }
}