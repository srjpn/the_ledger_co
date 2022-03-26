using TheLedgerCompany.Models;

namespace TheLedgerCompany.Services
{
    public class BalanceService
    {
        private readonly LoanService loanService;
        private readonly PaymentService paymentService;
        public BalanceService(LoanService loanService, PaymentService paymentService)
        {
            this.paymentService = paymentService;
            this.loanService = loanService;
        }
        public Balance GetBalance(string bankName, string borrowerName, int emi)
        {
            var loan = loanService.GetByBankAndBorrowerName(bankName, borrowerName);
            var extraPaymentDone = paymentService.GetPaymentDoneBefore(bankName, borrowerName, emi);
            var totalAmountPaid = loan.GetTotalAmountPaid(emi);
            var emiLeft = loan.EmiPending(emi);
            var balance = new Balance
            {
                BankName = bankName,
                BorrowerName = borrowerName,
                AmountPaid = totalAmountPaid + extraPaymentDone,
                PendingEmis = emiLeft
            };
            return balance;
        }
    }
}