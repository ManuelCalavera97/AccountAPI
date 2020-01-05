using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountAPI.Interfaces
{
    /// <summary>
    /// Interface for current account database interaction.
    /// </summary>
    public interface ICurrentAccountRepository
    {
        /// <summary>
        /// Gets current account Id.
        /// </summary>
        /// <returns>Id of account.</returns>
        uint GetCurrentAccountId();

        /// <summary>
        /// Sets current accout Id.
        /// </summary>
        /// <param name="id"></param>
        void SetCurrentAccountId(uint id);
    }
}
