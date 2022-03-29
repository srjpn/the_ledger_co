using TheLedgerCompany.Models;

namespace TheLedgerCompany.Queries
{
    [Action("HELP")]
    public class HelpQuery : IAction
    {
        public IResponse Execute(string[] args)
        {
            return new HelpResponse();
        }
    }
}