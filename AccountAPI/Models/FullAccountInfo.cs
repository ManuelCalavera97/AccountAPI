using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountAPI.Models
{
    /// <summary>
    /// Represents joined information about customer's account an its transactions
    /// </summary>
    public class FullAccountInfo 
    {
        /// <summary>
        /// Information about the account
        /// </summary>
        public AccountInfo AccountInfo { get; set; }

        /// <summary>
        /// List of transactions, which belong to the account
        /// </summary>
        public List<AccountTransaction> Transactions { get; set; }
    }
}
