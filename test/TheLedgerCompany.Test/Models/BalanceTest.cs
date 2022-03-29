using TheLedgerCompany.Models;
using Xunit;

namespace TheLedgerCompany.Test.Models
{
    public class BalanceTest
    {
        [Fact]
        public void ToString_ShouldFormatTheBalance()
        {
            var balance  = new Balance() {
                BankName = "BANK_NAME",
                BorrowerName = "BORROWER_NAME",
                PendingEmis = 2,
                AmountPaid = 1000
            };

            Assert.Equal("BANK_NAME BORROWER_NAME 1000 2", balance.ToString());
        }
    }
}