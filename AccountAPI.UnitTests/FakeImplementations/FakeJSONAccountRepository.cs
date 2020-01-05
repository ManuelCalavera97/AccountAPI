using AccountAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using AccountAPI.Models;

namespace AccountAPI.UnitTests
{
    public class FakeJSONAccountRepository : IAccountRepository
    {
        private List<AccountInfo> _listOfAccounts;

        public FakeJSONAccountRepository()
        {
            _listOfAccounts = new List<AccountInfo>()
                {
                    new AccountInfo(){Id = 1, Name = "Dmitry", Surname = "Ivanov", Balance = 200},
                    new AccountInfo(){Id = 2, Name = "Alex", Surname = "Mercer", Balance = 350},
                    new AccountInfo(){Id = 3, Name = "Peter", Surname = "Jackson", Balance = 500},
                    new AccountInfo(){Id = 4, Name = "Travis", Surname = "Willingham", Balance = 550},
                    new AccountInfo(){Id = 5, Name = "Alyx", Surname = "Vance", Balance = 325},
                };
        }

        public AccountInfo AddAccount(AccountInfo accountInfo)
        {
            AccountInfo accountToBeAdded = new AccountInfo
            {
                Id = _listOfAccounts[_listOfAccounts.Count - 1].Id + 1,
                Name = accountInfo.Name,
                Surname = accountInfo.Surname,
                Balance = 0,
            };

            _listOfAccounts.Add(accountToBeAdded);

            try
            {
                return accountToBeAdded;
            }
            catch
            {
                throw;
            }
        }

        public bool CheckAccountExistance(uint id)
        {
            try
            {
                GetAccountInfo(id);
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public List<AccountInfo> GetAccountInfo()
        {
            return _listOfAccounts;
        }

        public AccountInfo GetAccountInfo(uint id)
        {
            try
            {
                return _listOfAccounts.Single(o => o.Id == id);
            }
            catch
            {
                throw;
            }
        }

        public AccountInfo GetExistingAccountInfo()
        {
            try
            {
                return _listOfAccounts.First();
            }
            catch 
            {
                throw;
            }
        }

        public void UpdateAccountBalance(uint id, double sum)
        {
            try
            {
                _listOfAccounts.Single(o => o.Id == id).Balance += sum;
            }
            catch
            {
                throw;
            }    
        }
    }
}
