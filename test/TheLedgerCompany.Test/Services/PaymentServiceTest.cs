using TheLedgerCompany.Models;
using TheLedgerCompany.Services;
using Xunit;

namespace TheLedgerCompany.Test.Services
{
    public class PaymentServiceTest
    {
        [Fact]
        public void GetPaymentDoneBefore_ShouldSumOfPaymentsDoneBeforeGivenEmiNumber()
        {
            var service = new PaymentService();
            service.Add(new Payment()
            {
                BankName = "bank_name",
                BorrowerName = "borrower_name",
                Amount = 100,
                Emi = 2
            });

            service.Add(new Payment()
            {
                BankName = "bank_name",
                BorrowerName = "borrower_name",
                Amount = 100,
                Emi = 4
            });

            Assert.Equal(100, service.GetPaymentDoneBefore("bank_name","borrower_name", 3));
            Assert.Equal(200, service.GetPaymentDoneBefore("bank_name","borrower_name", 4));
        }
    }
}