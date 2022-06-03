using TheLedgerCompany.Services;

namespace TheLedgerCompany.Commands
{
    [Action("INTEREST_CHANGE")]
    public class InterestChangeCommand : IAction
    {
        private readonly IInterestChangeService interestChangeService;
        public InterestChangeCommand(IInterestChangeService interestChangeService)
        {
            this.interestChangeService = interestChangeService;
        }

        public IResponse Execute(string[] args)
        {
            var bankName = args[0];
            var borrowerName = args[1];
            var interestRate = int.Parse(args[2]);
            interestChangeService.AddInterestChange(bankName, borrowerName, interestRate);
            return null;
        }
    }
}