using TheLedgerCompany.Services;

namespace TheLedgerCompany.Queries
{
    [Action("BALANCE")]
    public class BalanceQuery : IAction, IQuery
    {
        private readonly IBalanceService balanceService;

        public BalanceQuery(IBalanceService balanceService)
        {
            this.balanceService = balanceService;
        }

        public IResponse Execute(string[] args)
        {
            var bankName = args[0];
            var borrowerName = args[1];
            var emi = int.Parse(args[2]);
            return balanceService.GetBalance(bankName, borrowerName, emi);
        }
    }
}