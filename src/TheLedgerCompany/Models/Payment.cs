namespace TheLedgerCompany.Models
{
    public class Payment
    {
        public string BankName { get; set; }
        public string BorrowerName { get; set; }
        public int Amount { get; set; }
        public int Emi { get; set; }
    }
}