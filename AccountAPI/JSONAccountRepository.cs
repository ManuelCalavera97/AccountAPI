using AccountAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using AccountAPI.Models;

namespace AccountAPI
{
    public class JSONAccountRepository : IAccountRepository
    {
        private List<AccountInfo> _listOfAccounts;

        public JSONAccountRepository()
        {
            try
            {
                string json = File.ReadAllText(@".\MockJsonDb\Accounts.txt");
                _listOfAccounts = JsonSerializer.Deserialize<List<AccountInfo>>(json);
                _listOfAccounts = _listOfAccounts.OrderBy(o => o.Id).ToList();
            }
            catch (FileNotFoundException)
            {
                _listOfAccounts = new List<AccountInfo>();
                string json = JsonSerializer.Serialize(_listOfAccounts);
                File.WriteAllText(@".\MockJsonDb\Accounts.txt", json);
            }
            catch
            {
                throw;
            }
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
                string json = JsonSerializer.Serialize(_listOfAccounts);
                File.WriteAllText(@".\MockJsonDb\Accounts.txt", json);
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
                string json = JsonSerializer.Serialize(_listOfAccounts);
                File.WriteAllText(@".\MockJsonDb\Accounts.txt", json);
            }
            catch
            {
                throw;
            }    
        }
    }
}
