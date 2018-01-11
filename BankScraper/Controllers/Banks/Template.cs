
using System;
using BankScraper.Models;
using BankScraper.Controllers.IntegratedBanks;
using System.Collections.Generic;
using BankScraper.Models.Scraper;
using BankScraper.Models.Comum;

namespace BankScraper.Controllers.IntegratedBanks
{
    /// <summary>
    /// Nubank.
    /// </summary>
    public class Template : IBanks 
    {
        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <returns>The account.</returns>
        /// <param name="login">Login.</param>
        public  Account GetAccount(Login login)
        {

            Account account = new Account(){};
            Events transaction = new Events();
            Purchase purchase = new Purchase();
            List<Events> tr = new List<Events>() { };
            List<Purchase> Lpurchase = new List<Purchase>();

            try
            {
                
                //Account info
                account.bank = login.bank;
                account.owner = "Pachelbel";
                account.overdraft = "396.00";
                account.personal_credit = "10,00";
                account.number = login.account_number;
                account.currency = "U$$";

                //Account events
                //Add list
                tr.Add(new Events()
                {
                    id = "1",
                    name = "Payment",
                    category = "Bank deposit",
                    title = "Canon in d paymento music",
                    amount = "1500,00",
                    time = DateTime.Now.ToString(),
                    message = "Payment of copyright"  
                });
                //Add list
                tr.Add(new Events()
                {
                    id = "2",
                    name = "Payment",
                    category = "Bank deposit",
                    title = "Canon in d paymento music",
                    amount = "15000,00",
                    time = DateTime.Now.ToString(),
                    message = "Payment of copyright in american dolars (USD) Berlin State Opera"
                        
                });
                //Add list
                tr.Add(new Events()
                {
                    id = "2",
                    name = "Payment",
                    category = "Bank deposit",
                    title = "Canon in d paymento music",
                    amount = "150000,00",
                    time = DateTime.Now.ToString(),
                    message = "Payment of copyright in Brazilian Real (R$) Brasil State Opera"
                });

                 //############################################################
                //Account purchases
                Lpurchase.Add(new Purchase()
                {
                    id = "1",
                    value = "700,00",
                    description = "Amazon new smart watch Garmin Fenix 5",
                    timestamp = DateTime.Now.ToString(),
                    currency = "EUR"
                });
                //Account purchases
                Lpurchase.Add(new Purchase()
                {
                    id = "2",
                    value = "100,00",
                    description = "Amazon Alexa home",
                    timestamp = DateTime.Now.ToString(),
                    currency = "EUR"
                });


                //Add to account
                account.events = tr;
                account.purchase = Lpurchase;

               
            }catch(Exception e)
            {
                throw e;
            }
            return account;
        }
    }
}
