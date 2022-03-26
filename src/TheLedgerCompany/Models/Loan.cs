namespace TheLedgerCompany.Models
{
    public class Loan
    {
        public string BankName { get; set; }
        public string BorrowerName { get; set; }
        public int Principal { get; set; }
        public int NoOfYears { get; set; }
        public int InterestRate { get; set; }

        private int Interest => (this.Principal * this.NoOfYears * this.InterestRate) / 100;

        private int Amount => this.Principal + this.Interest;

        private int Emi => Amount / (this.NoOfYears * 12);

        public int GetTotalAmountPaid(int emi) => this.Emi * emi;

        public int EmiPending(int emi) => (Amount / Emi) - emi;
    }
}