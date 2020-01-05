using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AccountAPI.Models
{
    /// <summary>
    /// Represents one transaction
    /// </summary>
    public class AccountTransaction
    {
        /// <summary>
        /// Id of account, to which transaction belongs to
        /// </summary>
        public uint AccountId { get; set; }

        /// <summary>
        /// Time of creation of transaction
        /// </summary>
        public DateTime Time { get; set; }


        /// <summary>
        /// Amount of currency used in transaction
        /// </summary>
        public double transactionSum { get; set; }
    }
}
