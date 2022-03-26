using TheLedgerCompany.Models;
using Xunit;

namespace TheLedgerCompany.Test.Models
{
    public class LoanTest
    {
        [Fact]
        public void GetTotalAmountPaid_ShouldGiveTotalAmountPaidTillGivenEmi()
        {
            var loan = new Loan("IDIDI", "Dale", 10000, 5, 4);
            Assert.Equal(1000, loan.GetTotalAmountPaid(5));
        }

        [Fact]
        public void EmiPending_ShouldGivePendingEmiAfterGivenEmi()
        {
            var loan = new Loan("IDIDI", "Dale", 10000, 5, 4);
            Assert.Equal(55, loan.EmiPending(5));
        }
    }
}