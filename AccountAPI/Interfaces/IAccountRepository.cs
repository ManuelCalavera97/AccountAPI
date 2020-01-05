using AccountAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountAPI.Interfaces
{
    /// <summary>
    /// Interface for account database interaction.
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Gets one instance of existing accountInfo.
        /// </summary>
        /// <returns>Information about the account.</returns>
        AccountInfo GetExistingAccountInfo();

        /// <summary>
        /// Gets a list of all instances of accountInfo.
        /// </summary>
        /// <returns>List of accounts.</returns>
        List<AccountInfo> GetAccountInfo();

        /// <summary>
        /// Gets one instance of a certain accountInfo.
        /// </summary>
        /// <param name="id">Id of account, which to get.</param>
        /// <returns>Information about the account.</returns>
        AccountInfo GetAccountInfo(uint id);

        /// <summary>
        /// Adds an account to DB
        /// </summary>
        /// <param name="accountInfo">Information about the account.</param>
        /// <returns>Created account.</returns>
        AccountInfo AddAccount(AccountInfo accountInfo);

        /// <summary>
        /// Adds to account's balance a certain ammount.
        /// </summary>
        /// <param name="id">Id of account, to which to add/subtract a transaction amount.</param>
        /// <param name="sum">Amount to add/subtract from balance.</param>
        void UpdateAccountBalance(uint id, double sum);


        /// <summary>
        /// Checks if account exist.
        /// </summary>
        /// <param name="id">Id of account.</param>
        /// <returns>True, if account exists, false if not.</returns>
        bool CheckAccountExistance(uint id);
    }
}
