using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AccountAPI.Models
{
    /// <summary>
    /// Represents one account, containing customer's full name and balance
    /// </summary>
    public class AccountInfo
    {
        /// <summary>
        /// Id of specific customer/account
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Customer's first name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Customer's surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Account's balance
        /// </summary>
        public double Balance { get; set; }

    }
}
