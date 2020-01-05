using AccountAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountAPI.Interfaces
{
    /// <summary>
    /// Interface for transaction database interactions.
    /// </summary>
    public interface ITransactionRepository
    {
        /// <summary>
        /// Gets transaction,belogning to a certain account, created at certain time.
        /// </summary>
        /// <param name="id">Id of an account.</param>
        /// <param name="time">Time of creation.</param>
        /// <returns>Transaction.</returns>
        AccountTransaction GetTransaction(uint id, DateTime time);

        /// <summary>
        /// Gets all existing transactions.
        /// </summary>
        /// <returns>List of transactions.</returns>
        List<AccountTransaction> GetTransactions();

        /// <summary>
        /// Gets transactions, belogning to a certain account.
        /// </summary>
        /// <param name="accountId">Id of an account</param>
        /// <param name="amount">Amount of account's last transactions. Will show all by default.</param>
        /// <returns>List of transactions.</returns>
        List<AccountTransaction> GetTransactions(uint accountId, int amount = 0);

        /// <summary>
        /// Adds a transaction to a database of transactions, and updates account's balance.
        /// </summary>
        /// <param name="accountId">Id of an account.</param>
        /// <param name="sum">Transaction sum.</param>
        /// <returns>Created transaction.</returns>
        AccountTransaction AddTransaction(uint accountId, double sum);

    }
}
