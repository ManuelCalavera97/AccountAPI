using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AccountAPI.Models;
using System.Linq;

namespace AccountAPI.UnitTests
{
    public class CurrentAccountRepositoryTests
    {
        [Fact]
        public void GetCurrentAccountId_IdExists_ReturnsId()
        {
            Services services = new Services();
            uint expected = 1;

            uint actual = services.currentAccountRepository.GetCurrentAccountId();

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void SetCurrentAccountId_AccountExists_ReturnsNewId()
        {
            Services services = new Services();
            uint expected = 3;

            services.currentAccountRepository.SetCurrentAccountId(3);
            uint actual = services.currentAccountRepository.GetCurrentAccountId();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetCurrentAccountId_AccountNotExists_ReturnsNewId()
        {
            Services services = new Services();
            uint expected = 1;

            services.currentAccountRepository.SetCurrentAccountId(20);
            uint actual = services.currentAccountRepository.GetCurrentAccountId();

            Assert.Equal(expected, actual);
        }
    }
}
