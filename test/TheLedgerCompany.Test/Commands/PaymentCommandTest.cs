using Moq;
using TheLedgerCompany.Commands;
using TheLedgerCompany.Models;
using TheLedgerCompany.Services;
using Xunit;

namespace TheLedgerCompany.Test.Commands
{
    public class PaymentCommandTest
    {
        [Fact]
        public void Execute_ShouldCreatePaymentFromArgsList()
        {
            var paymentServiceMock = new Mock<IPaymentService>();
            paymentServiceMock.Setup(x => x.Add(It.IsAny<Payment>()));

            var command = new PaymentCommand(paymentServiceMock.Object);
            var args = "IDIDI Dale 10000 5".Split(" ");
            command.Execute(args);

            paymentServiceMock.Verify(x => x.Add(It.Is<Payment>(payment => payment.BankName == "IDIDI"
                                                                && payment.BorrowerName == "Dale"
                                                                && payment.Amount == 10000
                                                                && payment.Emi == 5)));
        }
    }
}