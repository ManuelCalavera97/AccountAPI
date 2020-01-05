using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AccountAPI.Models;
using System.Linq;

namespace AccountAPI.UnitTests
{
    public class AccountRepositoryTests
    {

        [Fact]
        public void GetAccountInfoAll_ReturnsFullList()
        {
            Services services = new Services();
            var expected = 5;

            var actual = services.accountRepository.GetAccountInfo().Count;

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void AddAccount_ReturnsAccountWithNewId()
        {
            Services services = new Services();
            uint expectedId = 6;
            double expectedBalance = 0;

            var actualAccount = services.accountRepository.AddAccount(new AccountInfo() {
                Id = 0,
                Name = "Viktor", 
                Surname = "Kayden", 
                Balance = 432 
            });

            Assert.Equal(expectedId, actualAccount.Id);
            Assert.Equal(expectedBalance, actualAccount.Balance);
        }

        [Fact]
        public void UpdateAccountBalance_AccountExist_UpdatesBalance()
        {
            Services services = new Services();
            double expectedBalance = 225;

            services.accountRepository.UpdateAccountBalance(1,25);
            double actualBalance = services.accountRepository.GetAccountInfo(1).Balance;
        }

        [Fact]
        public void UpdateAccountBalance_AccountNotExist_ThrowsInvalidOperationException()
        {
            Services services = new Services();
  
            Assert.Throws<InvalidOperationException>(()=> services.accountRepository.UpdateAccountBalance(20, 25));
        }

        [Fact]
        public void GetAccountInfoId_AccountExists_ReturnsAccount()
        {
            Services services = new Services();
            var expected = "Dmitry";

            var actual = services.accountRepository.GetAccountInfo(1).Name;

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void GetAccountInfoId_AccountNotExists_ThrowsInvalidOperationException()
        {
            Services services = new Services();

            Assert.Throws<InvalidOperationException>(() => services.accountRepository.GetAccountInfo(20));
        }

        [Fact]
        public void CheckAccountExistance_AccountExists_ReturnsTrue()
        {
            Services services = new Services();

            Assert.True(services.accountRepository.CheckAccountExistance(1));
        }

        [Fact]
        public void CheckAccountExistance_AccountNotExists_ReturnsFalse()
        {
            Services services = new Services();

            Assert.False(services.accountRepository.CheckAccountExistance(20));
        }

    }
}
