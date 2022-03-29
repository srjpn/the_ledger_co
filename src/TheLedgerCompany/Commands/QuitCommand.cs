
namespace TheLedgerCompany.Commands
{
    [Action("")]
    public class QuitCommand : IAction
    {
        public IResponse Execute(string[] args)
        {
            System.Environment.Exit(0);
            return null;
        }
    }
}