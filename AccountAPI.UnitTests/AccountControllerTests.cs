using System;
using Xunit;
using AccountAPI;
using AccountAPI.Controllers;
using AccountAPI.Models;

namespace AccountAPI.UnitTests
{
    public class AccountControllerTests
    {
        private readonly AccountController _controller;

        private Services services;

        public AccountControllerTests()
        {
            services = new Services();

            _controller = new AccountController(services.fullCurrentAccountInfoBuilder, services.accountRepository);
        }

    }
}
