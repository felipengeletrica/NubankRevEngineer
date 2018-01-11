using System;
using BankScraper.Models;
using BankScraper.Controllers.IntegratedBanks;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net;
using System.Text;
using System.Diagnostics;
using BankScraper.Models.Scraper;
using BankScraper.Models.Comum;
using BankScraper.Models.Nubank;


namespace BankScraper.Controllers.Banks.Nubank
{
    public class nubankParser : IBanks
    {

        //Nubank
        Nubank nubank = new Nubank();
        //Utils
        Utils util = new Utils();

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <returns>The account.</returns>
        /// <param name="login">Login.</param>
        public Account GetAccount(Login login)
        {
            //Scrapers abstraction 
            Account account = new Account() {};

            try
            {
                bool status = nubank.connect(login);
                if (status)
                {
                    account = NubankToAccount();
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                nubank.disconnect();
            }

            //Account info
            account.bank = login.bank;
            account.number = login.account_number;
            account.branch = login.account_agency;

            return account;
        }


        /// <summary>
        /// Nubanks process account.
        /// </summary>
        /// <returns>The to account.</returns>
        private Account NubankToAccount()
        {

            //Scrapers abstraction 
            Account account = new Account();
            JObject jevents = new JObject();
            JObject bills = new JObject();
            JObject customer = new JObject();
            JObject purchases = new JObject();

            //node Object ou element
            string json_object_element = "amount";

            //get values JSON TOKENS
            jevents = nubank.getEvents();
            bills = nubank.getBillsSummary();
            customer = nubank.getCustomer();
            purchases = nubank.getPurchases();


            // **************** events ****************************
            //Nodes tokens events
            JToken _customer_id = jevents["customer_id"];
            JToken _links = jevents["_links"];
            JToken _updates = jevents["updates"];
            JToken _events = jevents["events"];
            JToken _as_of = jevents["as_of"];

            //*************** Costumer ***************************
            JToken _customer = customer["printed_name"];

            //Transactions
            JToken _purchases = purchases["transactions"];


            //var customer_name = (from s in _customer where s["printed_name"] != null select s["printed_name"]).ToList();


            //get JSON events results
            //get objects into a list
            List<JToken> events = _events.Children().ToList();
            //Serialize JSON results into .NET objects 
            List<Events> scraper_events = new List<Events>();

            //PARSER  NUBANK to SCRAPER events
            foreach (JToken ev in events)
            {
                NubankEvents nubank_event = ev.ToObject<NubankEvents>();
                Events scraper_ev = new Events();

                scraper_ev.name = nubank_event.name;
                scraper_ev.category = nubank_event.category;
                scraper_ev.title = nubank_event.title;
                scraper_ev.amount = util.ConvertValue(nubank_event.amount);
                scraper_ev.time = nubank_event.time;
                scraper_ev.message = nubank_event.message;
                scraper_ev.id = nubank_event.id;

                scraper_events.Add(scraper_ev);
            }

            //Copy Events
            account.events = scraper_events;

            //************  Card limit *****************
            //In main json find in node JSON
            var events_amounts_changes = (from s in _events where s[json_object_element] != null select s[json_object_element]).ToList();
            //Last value setting
            string limite_do_cartao = null;

            //limite do cartao
            if (events_amounts_changes.Count() > 0)
            {
                Double card_amount = Convert.ToDouble(events_amounts_changes.First().Value<string>());
                //string card Value
                limite_do_cartao = (card_amount / 100).ToString(".00");
            }
            // account.events = nubank_events;
            //Copy card limit
            account.personal_credit = limite_do_cartao;
            //Purchases

            return account;
        }


    }
}
