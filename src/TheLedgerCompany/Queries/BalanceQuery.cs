using TheLedgerCompany.Models;
using TheLedgerCompany.Services;

namespace TheLedgerCompany.Queries
{
    public class BalanceQuery
    {
        private readonly BalanceService balanceService;

        public BalanceQuery(BalanceService balanceService)
        {
            this.balanceService = balanceService;
        }

        public Balance GetBalance(string bankName, string borrowerName, int emi)
        {
            return balanceService.GetBalance(bankName, borrowerName, emi);
        }
    }
}