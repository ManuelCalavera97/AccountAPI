using AccountAPI.Interfaces;
using AccountAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AccountAPI
{
    public class JSONTransactionRepository : ITransactionRepository
    {
        private readonly IAccountRepository _accountRepository;

        private List<AccountTransaction> _transactionList;

        public JSONTransactionRepository(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

            try
            {
                string json = File.ReadAllText(@".\MockJsonDb\Transactions.txt");
                _transactionList = JsonSerializer.Deserialize<List<AccountTransaction>>(json);
                _transactionList = _transactionList.OrderBy(o => o.AccountId).ThenBy(o =>o.Time).ToList();
            }
            catch (FileNotFoundException)
            {
                _transactionList = new List<AccountTransaction>();           
                string json = JsonSerializer.Serialize(_transactionList);
                File.WriteAllText(@".\MockJsonDb\Transactions.txt", json);
            }
            catch
            {
                throw;
            }
        }

        public AccountTransaction AddTransaction(uint accountId, double sum)
        {
            AccountTransaction transaction = new AccountTransaction() { AccountId = accountId, Time = DateTime.Now, transactionSum = sum };
            try
            {
                _accountRepository.GetAccountInfo(accountId);
                _transactionList.Add(transaction);
                string json = JsonSerializer.Serialize(_transactionList);     
                _accountRepository.UpdateAccountBalance(accountId, sum);
                File.WriteAllText(@".\MockJsonDb\Transactions.txt", json);
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
