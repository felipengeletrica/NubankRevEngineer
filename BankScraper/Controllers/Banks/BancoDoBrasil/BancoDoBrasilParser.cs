using System;
using BankScraper.Controllers.IntegratedBanks;
using BankScraper.Models.Comum;
using BankScraper.Models.Scraper;

namespace BankScraper.Controllers.Banks.BancoDoBrasil
{
    public class BancoDoBrasilParser : IBanks
    {
        /// <summary>
        /// Ges the account.
        /// </summary>
        /// <returns>The account.</returns>
        /// <param name="login">Login.</param>
        public Account GetAccount(Login login)
        {
             throw new Exception("Banco do Brasil not implementad");
            //Account account = new Account() { };
            //return account;
        }
    }
}
