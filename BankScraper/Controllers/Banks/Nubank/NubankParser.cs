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
    /// <summary>
    /// Nubank parser.
    /// </summary>
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
            JObject jbills = new JObject();
            JObject jcustomer = new JObject();
            JObject jpurchases = new JObject();

            List<Purchase> purchase = new List<Purchase>();
          
            //get values JSON TOKENS
            jevents = nubank.getEvents();
            jbills = nubank.getBillsSummary();
            jcustomer = nubank.getCustomer();
            jpurchases = nubank.getPurchases();

            //*************** Costumer informations costumers ******************

            JToken _customer = jcustomer["customer"];
            NubankCustomer nubankCustomer = _customer.ToObject<NubankCustomer>();
            Customer customer = new Customer();

            //Copy to customer  
            customer.address_state = nubankCustomer.address_state;
            customer.cpf = nubankCustomer.cpf;
            customer.email = nubankCustomer.email;
            customer.address_postcode = nubankCustomer.address_postcode;
            customer.billing_address_line1 = nubankCustomer.billing_address_line1;
            customer.billing_address_state = nubankCustomer.billing_address_state;
            customer.address_number = nubankCustomer.address_number;
            customer.billing_address_city = nubankCustomer.billing_address_city;
            customer.phone = nubankCustomer.phone;
            customer.billing_address_locality = nubankCustomer.billing_address_locality;
            customer.name = nubankCustomer.name;
            customer.nationality = nubankCustomer.nationality;
            customer.billing_address_line2 = nubankCustomer.billing_address_line2;
            customer.printed_name = nubankCustomer.printed_name;
            customer.preferred_name = nubankCustomer.preferred_name;
            customer.address_country = nubankCustomer.address_country;
            customer.address_line2 = nubankCustomer.address_line2;
            customer.billing_address_postcode = nubankCustomer.billing_address_postcode;
            customer.dob = nubankCustomer.dob;
            customer.id = nubankCustomer.id;
            customer.address_locality = nubankCustomer.address_locality;
            customer.marital_status = nubankCustomer.marital_status;
            customer.billing_address_country = nubankCustomer.billing_address_country;
            customer.address_line1 = nubankCustomer.address_line1;
            customer.gender = nubankCustomer.gender;
            customer.billing_address_number = nubankCustomer.billing_address_number;
            customer.reported_income = nubankCustomer.reported_income;
            customer.mothers_name = nubankCustomer.mothers_name;
            customer.invitations = nubankCustomer.invitations;
            customer.address_city = nubankCustomer.address_city;

            //Add in account
            account.customer = customer;

            //*************** Transaction Compras ******************************

            JToken _purchases = jpurchases["transactions"];

            //**************** Events ******************************************
            //Nodes tokens events
            JToken _customer_id = jevents["customer_id"];
            JToken _links = jevents["_links"];
            JToken _updates = jevents["updates"];
            JToken _events = jevents["events"];
            JToken _as_of = jevents["as_of"];

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

                scraper_ev.category = nubank_event.category;
                scraper_ev.title = nubank_event.title;
                scraper_ev.amount = util.ConvertValue(nubank_event.amount);
                scraper_ev.time = nubank_event.time;
                scraper_ev.message = nubank_event.message;
                scraper_ev.id = nubank_event.id;

                scraper_events.Add(scraper_ev);
            }

            //Copy Events to list scrapper
            account.events = scraper_events;

            //************  Card limit *****************
            string json_object_element = "amount";
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

            //************** Bills summary ************************
            //account.billsSummary = new BillsSummary() { total_credits = limite_do_cartao };


            //############ Bills summary ####################################
            JToken bills = jbills["bills"];
            BillsSummary billsSummary = new BillsSummary();
            //get objects into a list Valor da fatura
            IList<JToken> lbills = bills.Children().ToList();
            IList<JToken>  summarys = (from s in bills where s["summary"] != null select s["summary"]).ToList();
            //Serialize JSON results into .NET objects 
            NubankBillsSummary nubankBillsSummary = summarys[0].ToObject<NubankBillsSummary>();

            billsSummary.payments = nubankBillsSummary.payments;
            billsSummary.interest_charge = nubankBillsSummary.interest_charge;
            billsSummary.total_international = nubankBillsSummary.total_international;
            billsSummary.due_date = nubankBillsSummary.due_date;
            billsSummary.precise_minimum_payment = nubankBillsSummary.precise_minimum_payment;
            billsSummary.interest_reversal = nubankBillsSummary.interest_reversal;
            billsSummary.close_date = nubankBillsSummary.close_date;
            billsSummary.expenses = nubankBillsSummary.expenses;
            billsSummary.total_credits = nubankBillsSummary.total_credits;
            billsSummary.past_balance = nubankBillsSummary.past_balance;
            billsSummary.effective_due_date = nubankBillsSummary.effective_due_date;
            billsSummary.international_tax = nubankBillsSummary.international_tax;
            billsSummary.tax = nubankBillsSummary.tax;
            billsSummary.adjustments = nubankBillsSummary.adjustments;
            billsSummary.precise_total_balance = nubankBillsSummary.precise_total_balance;
            billsSummary.total_financed = nubankBillsSummary.total_financed;
            billsSummary.total_balance = nubankBillsSummary.total_balance;
            billsSummary.interest_rate = nubankBillsSummary.interest_rate;
            billsSummary.total_national = nubankBillsSummary.total_national;
            billsSummary.previous_bill_balance = nubankBillsSummary.previous_bill_balance;
            billsSummary.interest = nubankBillsSummary.interest;
            billsSummary.total_cumulative = nubankBillsSummary.total_cumulative;
            billsSummary.paid = nubankBillsSummary.paid;
            billsSummary.fees = nubankBillsSummary.fees;
            billsSummary.total_payments = nubankBillsSummary.total_payments;
            billsSummary.minimum_payment = nubankBillsSummary.minimum_payment;
            billsSummary.open_date = nubankBillsSummary.open_date;
            billsSummary.total_accrued = nubankBillsSummary.total_accrued;
            account.billsSummary = billsSummary;

            //********** Purchases *********************************************
            account.purchase = purchase;


            return account;
        }


    }
}
