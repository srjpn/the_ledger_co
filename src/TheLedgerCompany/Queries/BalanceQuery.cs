using TheLedgerCompany.Commands;
using TheLedgerCompany.Models;

namespace TheLedgerCompany.Queries
{
    public class BalanceQuery
    {
        public Balance GetBalance(string bankName, string borrowerName, int emi) {
            var loan = Loan.GetByBankAndBorrowerName(bankName, borrowerName);
            var extraPaymentDone = Payment.GetPaymentDoneBefore(bankName, borrowerName, emi);
            var totalAmountPaid = loan.GetTotalAmountPaid(emi);
            var emiLeft = loan.EmiPending(emi);
            var balance = new Balance(bankName,  borrowerName,  totalAmountPaid + extraPaymentDone, emiLeft);
            return balance;
        }
    }
}