namespace TheLedgerCompany.Models
{
    public class Balance
    {
        private string bankName;
        private string borrowerName;
        private int amountPaid;
        private int emi;

        public Balance(string bankName, string borrowerName, int amountPaid, int emi)
        {
            this.bankName = bankName;
            this.borrowerName = borrowerName;
            this.amountPaid = amountPaid;
            this.emi = emi;
        }

        
        public override string ToString() {
            return $"{bankName} {borrowerName} {amountPaid} {emi}";
        }
    }
}