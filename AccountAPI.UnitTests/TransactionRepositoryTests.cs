using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AccountAPI.Models;
using System.Linq;

namespace AccountAPI.UnitTests
{
    public class TransactionRepositoryTests
    {
        [Fact]
        public void GetTransactions_AllTransactions_ReturnsAllTransactions()
        {
            Services services = new Services();
            var expected = 15;

            var actual = services.transactionRepository.GetTransactions().Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTransactions_AccountsTransactions_ReturnsAllTransactionsOfAccount()
        {
            Services services = new Services();
            var expected = 3;

            var actual = services.transactionRepository.GetTransactions(1).Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddTransactionGetTransaction_NewTransaction_ReturnesNewTransaction()
        {
            Services services = new Services();
            AccountTransaction expectedTransaction = services.transactionRepository.AddTransaction(1,25);

            AccountTransaction actual = services.transactionRepository.GetTransaction(1,expectedTransaction.Time);

            Assert.Equal(expectedTransaction.transactionSum, actual.transactionSum);
        }

        [Fact]
        public void AddTransaction_NewTransaction_UpdatesAccountBalance()
        {
            Services services = new Services();
            double expected = 225;

            services.transactionRepository.AddTransaction(1, 25);
            double actual = services.accountRepository.GetAccountInfo(1).Balance;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddTransaction_NewTransactionNoAccount_ThrowsInvalidOperationException()
        {
            Services services = new Services();

            Assert.Throws<InvalidOperationException>(() => services.transactionRepository.AddTransaction(20, 25));
        }
    }
}
