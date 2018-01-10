using System;
using BankScraper.Models;

namespace BankScraper.Controllers.IntegratedBanks
{
    /// <summary>
    /// Banks abstration layer.
    /// </summary>
    public interface IBanks
    {
        /// <summary>
        /// Get the account.
        /// </summary>
        /// <returns>The account.</returns>
        /// <param name="login">Login.</param>
        Account GetAccount(Login login);
    }
}
