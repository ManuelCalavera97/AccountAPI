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
    public class JSONCurrentAccountRepository : ICurrentAccountRepository
    {
        private readonly IAccountRepository _accountRepository;

        private List<CurrentAccount> _listOfCurrentAccounts;

        public JSONCurrentAccountRepository(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

            try
            {
                string json = File.ReadAllText(@".\MockJsonDb\CurrentAccounts.txt");
                _listOfCurrentAccounts = JsonSerializer.Deserialize<List<CurrentAccount>>(json);
                _listOfCurrentAccounts.OrderBy(o => o.Time);
            }
            catch (FileNotFoundException)
            {
                _listOfCurrentAccounts = new List<CurrentAccount>();
                string json = JsonSerializer.Serialize(_listOfCurrentAccounts);
                File.WriteAllText(@".\MockJsonDb\CurrentAccounts.txt", json);
            }
            catch
            {
                throw;
            }
        }

        public uint GetCurrentAccountId()
        {
            return _listOfCurrentAccounts.Last().Id;
        }

        public void SetCurrentAccountId(uint id)
        {
            if ((GetCurrentAccountId() != id)&&(_accountRepository.CheckAccountExistance(id)))
            {
                _listOfCurrentAccounts.Add(new CurrentAccount { Id = id, Time = DateTime.Now });
                try
                {
                    string json = JsonSerializer.Serialize(_listOfCurrentAccounts);
                    File.WriteAllText(@".\MockJsonDb\CurrentAccounts.txt", json);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
