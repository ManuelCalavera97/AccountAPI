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
    /// Controller for account transactions.
    /// </summary>
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;

        private readonly ICurrentAccountRepository _currentAccountRepository;

        public TransactionsController(ITransactionRepository transactionRepository,
            ICurrentAccountRepository currentAccountRepository)
        {
            _transactionRepository = transactionRepository;
            _currentAccountRepository = currentAccountRepository;
        }

        /// <summary>
        /// Gets all exsisting transactions.
        /// </summary>
        /// <returns>A list of transactions.</returns>
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<AccountTransaction>> Get()
        {
            try
            {
                List<AccountTransaction> listOfTransactions = _transactionRepository.GetTransactions();
                if (listOfTransactions.Count > 0)
                    return listOfTransactions;
                else
                    return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Gets transactions, that belongs to a certain account.
        /// </summary>
        /// <param name="id">Unique identifier of an account.</param>
        /// <param name="amountOfTransactions">Number of transactions.</param>
        /// <returns>A list of transactions, that belong to a certain account.</returns>
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<List<AccountTransaction>> GetById(uint id,[FromQuery] int amountOfTransactions = 0)
        {
            try
            {
                List<AccountTransaction> listOfTransactions = _transactionRepository.GetTransactions(id, amountOfTransactions);
                if (listOfTransactions.Count > 0)
                    return listOfTransactions;
                else
                    return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Gets one tranaction, that belongs to a certain account, created at specific time.
        /// </summary>
        /// <param name="id">Unique identifier of an account.</param>
        /// <param name="timeBin">DateTime parameter in binary.</param>
        /// <returns>Transaction.</returns>
        // GET api/<controller>/5/-8586234739836065507
        [HttpGet("{id}/{timeBin}")]
        public ActionResult<AccountTransaction> GetByIdTime(uint id, long timeBin)
        {
            try
            {
                AccountTransaction transaction = _transactionRepository.GetTransaction(id, DateTime.FromBinary(timeBin));
                return transaction;
            }
            catch(InvalidOperationException)
            {
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Posts a transaction and adds that transaction to a balance of transaction's account.
        /// </summary>
        /// <param name="transaction">Model transaction, which needs two parameters: "AccountId" - Id of an account, "transactionSum" - amount of transferred currency</param>
        // POST api/<controller>
        [HttpPost]
        public ActionResult<AccountTransaction> Post([FromBody] AccountTransaction transaction)
        {
            try
            {
                AccountTransaction createdTransaction = _transactionRepository.AddTransaction(transaction.AccountId, transaction.transactionSum);
                _currentAccountRepository.SetCurrentAccountId(transaction.AccountId);
                return CreatedAtAction("GetByIdTime", new { id = createdTransaction.AccountId, timeBin = createdTransaction.Time.ToBinary() }, createdTransaction);
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
            
        }
    }
}
