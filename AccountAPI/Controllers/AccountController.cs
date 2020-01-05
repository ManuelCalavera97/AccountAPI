using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AccountAPI.Interfaces;
using AccountAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountAPI.Controllers
{
    /// <summary>
    /// Controller for account managment
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IFullCurrentAccountInfoBuilder _fullCurrentAccountInfoBuilder;

        private readonly IAccountRepository _accountRepository;

        public AccountController(IFullCurrentAccountInfoBuilder fullCurrentAccountInfoBuilder, 
            IAccountRepository accountRepository)
        {
            _fullCurrentAccountInfoBuilder = fullCurrentAccountInfoBuilder;
            _accountRepository = accountRepository;
        }

        /// <summary>
        /// Gets informaton about current account and it's transactions.
        /// </summary>
        /// <param name="amountOfTransactions">Number of transactions.</param>
        /// <returns>FullAccountInfo object with account information and transactions</returns>
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<FullAccountInfo> GetCurrent(int amountOfTransactions = 5)
        {
            try
            {
                FullAccountInfo fullAccountInfo = _fullCurrentAccountInfoBuilder.GetCurrentAccountInfo(amountOfTransactions);
                return fullAccountInfo;
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Gets informaton about a certain account and it's transactions.
        /// </summary>
        /// <param name="id">Id of an account.</param>
        /// <param name="amountOfTransactions">Number of transactions.</param>
        /// <returns>FullAccountInfo object with account information and transactions</returns>
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<FullAccountInfo> GetById(uint id, int amountOfTransactions = 5)
        {
            try
            {
                FullAccountInfo fullAccountInfo = _fullCurrentAccountInfoBuilder.GetAccountInfo(id, amountOfTransactions);
                return fullAccountInfo;
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Posts a new account
        /// </summary>
        /// <param name="accountInfo">Model accountInfo, which needs 2 parameters: "Name" - First name of customer, "Surname" - Surname of customer</param>
        // POST api/<controller>
        [HttpPost]
        public ActionResult<AccountInfo> Post([FromBody] AccountInfo accountInfo)
        {
            try
            {
                AccountInfo createdAccount = _accountRepository.AddAccount(accountInfo);
                return CreatedAtAction("GetById", new { Id = createdAccount.Id }, createdAccount);
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
