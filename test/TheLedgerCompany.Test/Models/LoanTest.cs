using System.Collections.Generic;
using TheLedgerCompany.Models;
using Xunit;

namespace TheLedgerCompany.Test.Models
{
    public class LoanTest
    {
        [Fact]
        public void GetTotalAmountPaid_ShouldGiveTotalAmountPaidTillGivenEmi()
        {
            var loan = new Loan
            {
                BankName = "IDIDI",
                BorrowerName = "Dale",
                Principal = 10000,
                NoOfYears = 5,
                InterestRates = new List<InterestRate>{new InterestRate(){Month = 0, Rate = 4}}

            };
            Assert.Equal(1000, loan.GetTotalAmountPaid(5, 0));
        }

        [Fact]
        public void GetTotalAmountPaid_ShouldGiveTotalAmountPaidTillGivenEmiForVariableEMI()
        {
            var loan = new Loan
            {
                BankName = "IDIDI",
                BorrowerName = "Dale",
                Principal = 10000,
                NoOfYears = 5,
                InterestRates = new List<InterestRate>{new InterestRate(){Month = 0, Rate = 4}, new InterestRate(){Month = 6, Rate = 6}}

            };
            Assert.Equal(1519, loan.GetTotalAmountPaid(7, 0));
        }

        [Fact]
        public void GetTotalAmountPaid_ShouldCalculateTotalPaidAmountAlongWithExtraPaymentsDone()
        {
            var loan = new Loan
            {
                BankName = "IDIDI",
                BorrowerName = "Dale",
                Principal = 10000,
                NoOfYears = 3,
                InterestRates = new List<InterestRate>{new InterestRate(){Month = 0, Rate = 7}}

            };
            Assert.Equal(12100, loan.GetTotalAmountPaid(30, 2000));
        }

        // [Fact]
        // public void EmiPending_ShouldGivePendingEmiAfterGivenEmi()
        // {
        //     var loan = new Loan
        //     {
        //         BankName = "IDIDI",
        //         BorrowerName = "Dale",
        //         Principal = 10000,
        //         NoOfYears = 5,
        //         InterestRate = 4
        //     };
        //     Assert.Equal(55, loan.EmiPending(5, 0));
        // }

        // [Fact]
        // public void EmiPending_ShouldGivePendingEmiAfterGivenEmi_WithExtraPaymentsDone()
        // {
        //     var loan = new Loan
        //     {
        //         BankName = "IDIDI",
        //         BorrowerName = "Dale",
        //         Principal = 5000,
        //         NoOfYears = 1,
        //         InterestRate = 6
        //     };
        //     Assert.Equal(4, loan.EmiPending(6, 1000));
        // }

        [Fact]
        public void EmiPending_ShouldGivePendingEmiAfterGivenEmiWhenNoPendingEmis()
        {
            var loan = new Loan
            {
                BankName = "IDIDI",
                BorrowerName = "Dale",
                Principal = 10000,
                NoOfYears = 3,
                InterestRates = new List<InterestRate>{new InterestRate(){Month = 0, Rate = 7}}
            };
            Assert.Equal(0, loan.EmiPending(30, 2000));
        }
    }
}