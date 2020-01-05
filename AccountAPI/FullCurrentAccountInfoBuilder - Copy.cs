using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountAPI.Interfaces;
using AccountAPI.Models;

namespace AccountAPI
{
    public class FullCurrentAccountInfoBuilder : IFullCurrentAccountInfoBuilder
    {
        private readonly IAccountRepository _accountRepository;

        private readonly ITransactionRepository _transactionRepository;

        private readonly ICurrentAccountRepository _currentAccountRepository;

        private FullAccountInfo _fullCurrentAccount;

        public FullCurrentAccountInfoBuilder(IAccountRepository accountRepository,
            ITransactionRepository transactionRepository,
            ICurrentAccountRepository currentAccountRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _currentAccountRepository = currentAccountRepository;
        }

        public FullAccountInfo GetCurrentAccountInfo(int transactAmount = 0)
        {
            try
            {
                _fullCurrentAccount = new FullAccountInfo
                {
                    AccountInfo = _accountRepository.GetAccountInfo(_currentAccountRepository.GetCurrentAccountId()),
                    Transactions = _transactionRepository.GetTransactions(_currentAccountRepository.GetCurrentAccountId(), transactAmount)
                };
                return _fullCurrentAccount;
            }
            catch
            {
                throw;    
            }
        }

        public FullAccountInfo GetAccountInfo(uint id, int transactAmount = 0)
        {
            try
            {
                _fullCurrentAccount = new FullAccountInfo
                {
                    AccountInfo = _accountRepository.GetAccountInfo(id),
                    Transactions = _transactionRepository.GetTransactions(id, transactAmount)
                };
                return _fullCurrentAccount;
            }
            catch
            {
                throw;
            }       
        }
    }
}
