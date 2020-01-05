using AccountAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountAPI.Interfaces
{
    /// <summary>
    /// Interface for building together account information with transactions.
    /// </summary>
    public interface IFullCurrentAccountInfoBuilder
    {
        /// <summary>
        /// Gets full current account infrormation.
        /// </summary>
        /// <param name="transactAmount">Amount of account's last transactions. Will show all by default.</param>
        /// <returns>Account information with a list of transactions.</returns>
        FullAccountInfo GetCurrentAccountInfo(int transactAmount = 0);

        /// <summary>
        /// Gets full certain account information.
        /// </summary>
        /// <param name="id">Id of account to get.</param>
        /// <param name="transactAmount">Amount of account's last transactions. Will show all by default.</param>
        /// <returns>Account information with a list of transactions.</returns>
        FullAccountInfo GetAccountInfo(uint id,int transactAmount = 0);
    }
}
