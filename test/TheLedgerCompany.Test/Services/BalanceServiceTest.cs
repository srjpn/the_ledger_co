using TheLedgerCompany.Models;
using TheLedgerCompany.Services;
using Xunit;

namespace TheLedgerCompany.Test.Services
{
    public class BalanceServiceTest
    {
        private PaymentService paymentService;
        private LoanService loanService;

        public BalanceServiceTest()
        {
            paymentService = new PaymentService();
            loanService = new LoanService();
        }

        [Fact]
        public void GetBalance_ShouldGiveTheTotalAmountPaidAndPendingEmisAtAGivenEmiNumber()
        {
            loanService.Add(new Loan
            {
                BankName = "IDIDI",
                BorrowerName = "Dale",
                Principal = 10000,
                NoOfYears = 5,
                InterestRate = 4
            });


            var balanceService = new BalanceService(loanService, paymentService);

            var balance = balanceService.GetBalance("IDIDI", "Dale", 5);

            Assert.Equal(1000, balance.AmountPaid);
            Assert.Equal(55, balance.PendingEmis);
        }

        [Fact]
        public void GetBalance_ShouldGiveTheTotalAmountPaidAndPendingEmisAtAGivenEmiNumberWithExtraPaymentsDone()
        {
            loanService.Add(new Loan
            {
                BankName = "IDIDI",
                BorrowerName = "Dale",
                Principal = 5000,
                NoOfYears = 1,
                InterestRate = 6
            });

            paymentService.Add(new Payment
            {
                BankName = "IDIDI",
                BorrowerName = "Dale",
                Amount = 1000,
                Emi = 5
            });

            var balanceService = new BalanceService(loanService, paymentService);

            var balance = balanceService.GetBalance("IDIDI", "Dale", 6);

            Assert.Equal(3652, balance.AmountPaid);
            Assert.Equal(4, balance.PendingEmis);
        }
    }
}