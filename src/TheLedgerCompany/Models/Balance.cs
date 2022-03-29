namespace TheLedgerCompany.Models
{
    public class Balance
    {
        public string BankName { get; set; }
        public string BorrowerName { get; set; }
        public double AmountPaid { get; set; }
        public double PendingEmis { get; set; }

        public override string ToString()
        {
            return $"{BankName} {BorrowerName} {AmountPaid} {PendingEmis}";
        }
    }
}