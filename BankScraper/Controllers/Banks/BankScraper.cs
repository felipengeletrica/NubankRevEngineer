using System;
using System.Collections.Generic;
using BankScraper.Models.Scraper;
using BankScraper.Models.Comum;
using BankScraper.Controllers.IntegratedBanks;
using BankScraper.Controllers.Banks.Nubank;
using BankScraper.Controllers.Banks.Itau;
using BankScraper.Controllers.Banks.Template;
using BankScraper.Controllers.Banks.BancoDoBrasil;

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
                new Bank(){ BankNames = "Itau"},
                new Bank(){ BankNames = "Banco do Brasil"},
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
                Banks = new nubankParser();

            }else if (login.bank == "Itau")
            {
                Banks = new ItauParser();

            }else if (login.bank == "Banco do Brasil")
            {
                Banks = new BancoDoBrasilParser();  
            }else if (login.bank == "Template")
            {
                Banks = new TemplateParser();
            }else
            {
                throw new Exception("BANK SELECT - Option not implemented");
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
