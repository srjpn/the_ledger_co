using Moq;
using TheLedgerCompany.Models;
using TheLedgerCompany.Services;
using Xunit;

namespace TheLedgerCompany.Test.Services
{
    public class BalanceServiceTest
    {
        private Mock<IPaymentService> paymentServiceMock;
        private Mock<ILoanService> loanServiceMock;

        public BalanceServiceTest()
        {
            paymentServiceMock = new Mock<IPaymentService>();
            loanServiceMock = new Mock<ILoanService>();
        }

        [Fact]
        public void GetBalance_ShouldGiveTheTotalAmountPaidAndPendingEmisAtAGivenEmiNumber()
        {
            var loan = new Loan
            {
                BankName = "IDIDI",
                BorrowerName = "Dale",
                Principal = 5000,
                NoOfYears = 1,
                InterestRate = 6
            };
            loanServiceMock.Setup(x => x.GetByBankAndBorrowerName(It.IsAny<string>(), It.IsAny<string>())).Returns(loan);
            paymentServiceMock.Setup(x => x.GetPaymentDoneBefore(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(0);

            var balanceService = new BalanceService(loanServiceMock.Object, paymentServiceMock.Object);

            var balance = balanceService.GetBalance("IDIDI", "Dale", 5);

            Assert.Equal(2210, balance.AmountPaid);
            Assert.Equal(7, balance.PendingEmis);
        }

        [Fact]
        public void GetBalance_ShouldGiveTheTotalAmountPaidAndPendingEmisAtAGivenEmiNumberWithExtraPaymentsDone()
        {
            var loan = new Loan
            {
                BankName = "IDIDI",
                BorrowerName = "Dale",
                Principal = 5000,
                NoOfYears = 1,
                InterestRate = 6
            };
            loanServiceMock.Setup(x => x.GetByBankAndBorrowerName(It.IsAny<string>(), It.IsAny<string>())).Returns(loan);
            paymentServiceMock.Setup(x => x.GetPaymentDoneBefore(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(1000);

            var balanceService = new BalanceService(loanServiceMock.Object, paymentServiceMock.Object);

            var balance = balanceService.GetBalance("IDIDI", "Dale", 6);

            Assert.Equal(3652, balance.AmountPaid);
            Assert.Equal(4, balance.PendingEmis);
        }
    }
}