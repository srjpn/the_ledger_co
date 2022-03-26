using TheLedgerCompany.Models;
using TheLedgerCompany.Services;
using Xunit;

namespace TheLedgerCompany.Test.Services
{
    public class LoanServiceTest
    {
        [Fact]
        public void Add_ShouldGetLoanByBankNameAndBorrowerName()
        {
            var service = new LoanService();
            service.Add(new Loan() { BankName = "bank_name", BorrowerName = "borrower_name" });

            Assert.NotNull(service.GetByBankAndBorrowerName("bank_name", "borrower_name"));
        }
    }
}