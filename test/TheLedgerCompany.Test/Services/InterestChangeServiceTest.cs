using System.Linq;
using TheLedgerCompany.Services;
using Xunit;

namespace TheLedgerCompany.Test.Services
{
    public class InterestChangeServiceTest
    {
        [Fact]
        public void AddInterestChange_ShouldAddTheInterestChangeForGivenBankAndBorrower()
        {
            var service = new InterestChangeService();

            var bankName = "Bank-name";
            var borrowerName = "borrower-name";
            var interestRate = 8;

            service.AddInterestChange(bankName, borrowerName, interestRate);

            Assert.Single(service.GetByBankAndBorrowerName(bankName, borrowerName));
        }

        [Fact]
        public void AddInterestChange_ShouldAddTheMonthsInMultiplesOfSix()
        {
            var service = new InterestChangeService();

            var bankName = "Bank-name";
            var borrowerName = "borrower-name";
            var interestRate = 8;

            service.AddInterestChange(bankName, borrowerName, interestRate);
            var interestChanges = service.GetByBankAndBorrowerName(bankName, borrowerName);
            Assert.Equal(6, interestChanges.First().Month);

            service.AddInterestChange(bankName, borrowerName, interestRate);

            interestChanges = service.GetByBankAndBorrowerName(bankName, borrowerName);
            Assert.Equal(2, interestChanges.Count());
            Assert.Equal(6, interestChanges.First().Month);
            Assert.Equal(12, interestChanges.Last().Month);
        }
    }
}
