using System;
using System.Collections.Generic;
using System.Text;
using AccountAPI.Interfaces;

namespace AccountAPI.UnitTests
{
    class Services
    {
        public readonly IFullCurrentAccountInfoBuilder fullCurrentAccountInfoBuilder;

        public readonly IAccountRepository accountRepository;

        public readonly ICurrentAccountRepository currentAccountRepository;

        public readonly ITransactionRepository transactionRepository;

        public Services()
        {
            accountRepository = new FakeJSONAccountRepository();

            transactionRepository = new FakeJSONTransactionRepository(accountRepository);

            currentAccountRepository = new FakeJSONCurrentAccountRepository(accountRepository);

            fullCurrentAccountInfoBuilder = new FullCurrentAccountInfoBuilder(accountRepository,transactionRepository,currentAccountRepository);
        }
    }
}
