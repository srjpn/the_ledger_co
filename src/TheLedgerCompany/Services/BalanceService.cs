using TheLedgerCompany.Models;

namespace TheLedgerCompany.Services
{
    public interface IBalanceService
    {
        Balance GetBalance(string bankName, string borrowerName, int emi);
    }

    public class BalanceService : IBalanceService
    {
        private readonly ILoanService loanService;
        private readonly IPaymentService paymentService;
        public BalanceService(ILoanService loanService, IPaymentService paymentService)
        {
            this.paymentService = paymentService;
            this.loanService = loanService;
        }
        public Balance GetBalance(string bankName, string borrowerName, int emi)
        {
            var loan = loanService.GetByBankAndBorrowerName(bankName, borrowerName);
            var extraPaymentDone = paymentService.GetPaymentDoneBefore(bankName, borrowerName, emi);
            var totalAmountPaid = loan.GetTotalAmountPaid(emi, extraPaymentDone);
            var emiLeft = loan.EmiPending(emi, extraPaymentDone);
            var balance = new Balance
            {
                BankName = bankName,
                BorrowerName = borrowerName,
                AmountPaid = totalAmountPaid,
                PendingEmis = emiLeft
            };
            return balance;
        }
    }
}