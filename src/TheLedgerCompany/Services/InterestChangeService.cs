using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TheLedgerCompany.Models;

namespace TheLedgerCompany.Services
{
    public class InterestChangeService : IInterestChangeService
    {
        private readonly IList<InterestChange> interestChanges = new List<InterestChange>();

        public void AddInterestChange(string bankName, string borrowerName, int interestRate)
        {
            var count = GetInterestChangesCountByBankAndBorrower(bankName, borrowerName);
            interestChanges.Add(new InterestChange() { BankName = bankName, BorrowerName = borrowerName, InterestRate = interestRate, Month = CalculateMonthForInterestChange(count) });
        }

        private static int CalculateMonthForInterestChange(int count)
        {
            return (count + 1) * 6;
        }

        private int GetInterestChangesCountByBankAndBorrower(string bankName, string borrowerName)
        {
            return interestChanges.Count(x => x.BankName == bankName && x.BorrowerName == borrowerName);
        }

        public IEnumerable<InterestChange> GetByBankAndBorrowerName(string bankName, string borrowerName)
        {
            return interestChanges.Where(x => x.BankName == bankName && x.BorrowerName == borrowerName);
        }
    }

    public interface IInterestChangeService
    {
        void AddInterestChange(string bankName, string borrowerName, int interestRate);
    }
}