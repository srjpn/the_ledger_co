using Moq;
using TheLedgerCompany.Queries;
using TheLedgerCompany.Services;
using Xunit;

namespace TheLedgerCompany.Test.Queries
{
    public class BalanceQueryTest
    {
        [Fact]
        public void Execute_ShouldCreatePaymentFromArgsList()
        {
            var balanceServiceMock = new Mock<IBalanceService>();
            balanceServiceMock.Setup(x => x.GetBalance(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()));

            var query = new BalanceQuery(balanceServiceMock.Object);
            var args = "IDIDI Dale 5".Split(" ");
            query.Execute(args);

            balanceServiceMock.Verify(x => x.GetBalance(It.Is<string>(b => b == "IDIDI")
                                                        , It.Is<string>(b => b == "Dale")
                                                        , It.Is<int>(b => b == 5)));
        }
    }
}