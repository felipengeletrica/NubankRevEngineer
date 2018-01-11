using System;
using System.Collections.Generic;
using BankScraper.Models.Scraper;
using BankScraper.Models.Comum;
using BankScraper.Controllers.IntegratedBanks;


namespace BankScraper.Controllers
{
    public class BankScraper
    {
    
        /// <summary>
        /// Lists the banks.
        /// </summary>
        /// <returns>The banks.</returns>
        public List<Bank> ListBanks()
        {
            List<Bank> banks = new List<Bank>{
                new Bank(){ BankNames = ""},
                new Bank(){ BankNames = "Nubank"},
                //new Bank(){ BankNames = "Itau"},
                //new Bank(){ BankNames = "Banco do Brasil"},
                //new Bank(){ BankNames = "Santander"},
                //new Bank(){ BankNames = "Sodexo"},
                new Bank(){ BankNames = "Template"}
        };

            return banks;
        }

        /// <summary>
        /// CheckAccounts the accounts.
        /// </summary>
        /// <returns>The accounts.</returns>
        /// <param name="login">Login.</param>
        public Account CheckAccounts(Login  login)
        {

             //Add validate data ex. cpf

             //Accounts banks
             Account account = new Account(){};

            //Abstration layer for banks
            IBanks Banks;

            if (login.bank == "Nubank")
            {
                Banks = new Nubank();

            }else if (login.bank == "Itau")
            {
                Banks = new Itau();

            }else if (login.bank == "Banco do Brasil")
            {
                Banks = new BancoDoBrasil();  
            }else if (login.bank == "Template")
            {
                Banks = new Template();
            }else
            {
                throw new Exception("Option not implemented");
            }

            try
            {
                //Get info accounts 
                account = Banks.GetAccount(login);
            }
            catch(Exception e)
            {
                throw e;
            }

            return account;
        }
    }
}
