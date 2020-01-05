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
    public class FakeJSONCurrentAccountRepository : ICurrentAccountRepository
    {
        private readonly IAccountRepository _accountRepository;

        private List<CurrentAccount> _listOfCurrentAccounts;

        public FakeJSONCurrentAccountRepository(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

            _listOfCurrentAccounts = new List<CurrentAccount>()
                {
                    new CurrentAccount(){Id = 1, Time = DateTime.Now},
                };
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

                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
