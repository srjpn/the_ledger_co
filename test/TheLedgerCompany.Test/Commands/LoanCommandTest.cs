using Moq;
using TheLedgerCompany.Commands;
using TheLedgerCompany.Models;
using TheLedgerCompany.Services;
using Xunit;

namespace TheLedgerCompany.Test.Commands
{
    public class LoanCommandTest
    {
        [Fact]
        public void Execute_ShouldCreateLoanFromArgsList()
        {
            var loanServiceMock = new Mock<ILoanService>();
            loanServiceMock.Setup(x => x.Add(It.IsAny<Loan>()));

            var loanCommand = new LoanCommand(loanServiceMock.Object);
            var args = "IDIDI Dale 10000 5 4".Split(" ");
            loanCommand.Execute(args);

            loanServiceMock.Verify(x => x.Add(It.Is<Loan>(loan => loan.BankName == "IDIDI"
                                                                && loan.BorrowerName == "Dale"
                                                                && loan.Principal == 10000
                                                                && loan.NoOfYears == 5
                                                                && loan.InterestRate == 4)));
        }
    }
}