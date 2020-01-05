using AccountAPI.Interfaces;
using AccountAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AccountAPI.UnitTests
{
    public class FakeJSONTransactionRepository : ITransactionRepository
    {
        private readonly IAccountRepository _accountRepository;

        private List<AccountTransaction> _transactionList;

        public FakeJSONTransactionRepository(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

            _transactionList = new List<AccountTransaction>()
                {
                    new AccountTransaction(){AccountId = 1, Time = DateTime.Now, transactionSum = 52},
                    new AccountTransaction(){AccountId = 1, Time = DateTime.Now, transactionSum = 42},
                    new AccountTransaction(){AccountId = 1, Time = DateTime.Now, transactionSum = 543},
                    new AccountTransaction(){AccountId = 2, Time = DateTime.Now, transactionSum = -53},
                    new AccountTransaction(){AccountId = 2, Time = DateTime.Now, transactionSum = 63},
                    new AccountTransaction(){AccountId = 2, Time = DateTime.Now, transactionSum = 12},
                    new AccountTransaction(){AccountId = 3, Time = DateTime.Now, transactionSum = -43},
                    new AccountTransaction(){AccountId = 3, Time = DateTime.Now, transactionSum = 54},
                    new AccountTransaction(){AccountId = 3, Time = DateTime.Now, transactionSum = -32},
                    new AccountTransaction(){AccountId = 4, Time = DateTime.Now, transactionSum = 65},
                    new AccountTransaction(){AccountId = 4, Time = DateTime.Now, transactionSum = 74},
                    new AccountTransaction(){AccountId = 4, Time = DateTime.Now, transactionSum = -5},
                    new AccountTransaction(){AccountId = 5, Time = DateTime.Now, transactionSum = 234},
                    new AccountTransaction(){AccountId = 5, Time = DateTime.Now, transactionSum = 34},
                    new AccountTransaction(){AccountId = 5, Time = DateTime.Now, transactionSum = 65},

                };
        }

        public AccountTransaction AddTransaction(uint accountId, double sum)
        {
            AccountTransaction transaction = new AccountTransaction() { AccountId = accountId, Time = DateTime.Now, transactionSum = sum };
            try
            {
                _accountRepository.GetAccountInfo(accountId);
                _transactionList.Add(transaction);
                _accountRepository.UpdateAccountBalance(accountId, sum);
                return transaction;
            }
            catch
            {
                throw;
            }
        }

        public AccountTransaction GetTransaction(uint id, DateTime time)
        {
            try
            {
                AccountTransaction transaction = _transactionList.Single(o => (o.AccountId == id) && (o.Time == time));
                return transaction;
            }
            catch
            {
                throw;
            }
        }

        public List<AccountTransaction> GetTransactions(uint accountId, int amount = 0)
        {
            List<AccountTransaction> transactions = _transactionList;
            transactions = transactions.Where(o => o.AccountId == accountId).ToList();
            if (amount > 0)
                transactions = transactions.Skip(Math.Max(0, transactions.Count() - amount)).ToList();
            return transactions;
        }

        public List<AccountTransaction> GetTransactions()
        {
            return _transactionList;
        }
    }
}
