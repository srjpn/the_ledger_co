namespace TheLedgerCompany
{
    public interface IAction
    {
        IResponse Execute(string[] args);
    }
}