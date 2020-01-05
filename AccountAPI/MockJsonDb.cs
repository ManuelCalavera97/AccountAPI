using AccountAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace AccountAPI
{
    class MockJsonDb
    {
        private List<AccountInfo> _listOfAccounts;
        private List<CurrentAccount> _listOfCurrentAccounts;
        private List<AccountTransaction> _transactionList;

        public MockJsonDb()
        {
            _listOfAccounts = new List<AccountInfo>()
                {
                    new AccountInfo(){Id = 1, Name = "Dmitry", Surname = "Ivanov", Balance = 200},
                    new AccountInfo(){Id = 2, Name = "Alex", Surname = "Mercer", Balance = 350},
                    new AccountInfo(){Id = 3, Name = "Peter", Surname = "Jackson", Balance = 500},
                    new AccountInfo(){Id = 4, Name = "Travis", Surname = "Willingham", Balance = 550},
                    new AccountInfo(){Id = 5, Name = "Alyx", Surname = "Vance", Balance = 325},
                };

            _listOfCurrentAccounts = new List<CurrentAccount>()
                {
                    new CurrentAccount(){Id = 1, Time = DateTime.Now},
                };

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

        public void CreateDb(){
            
            string json = JsonSerializer.Serialize(_listOfAccounts);
            File.WriteAllText(@".\MockJsonDb\Accounts.txt", json);

            
            json = JsonSerializer.Serialize(_listOfCurrentAccounts);
            File.WriteAllText(@".\MockJsonDb\CurrentAccounts.txt", json);

            
            json = JsonSerializer.Serialize(_transactionList);
            File.WriteAllText(@".\MockJsonDb\Transactions.txt", json);
        }

        public void DeleteDb()
        {
            File.Delete(@".\MockJsonDb\Transactions.txt");
            File.Delete(@".\MockJsonDb\CurrentAccounts.txt");
            File.Delete(@".\MockJsonDb\Accounts.txt");           
        }
    }
}
