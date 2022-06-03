namespace TheLedgerCompany.Models
{
    public class InterestChange
    {
        public string BankName { get; set; }
        public string BorrowerName { get; set; }
        public double InterestRate { get; set; }
        public int Month { get; set; }
    }
}