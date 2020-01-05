using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountAPI.Models
{
    /// <summary>
    /// Represents a log file for current account
    /// </summary>
    public class CurrentAccount
    {
        /// <summary>
        /// Id of an account
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Time of selecting a current account
        /// </summary>
        public DateTime Time { get; set; }
    }
}
