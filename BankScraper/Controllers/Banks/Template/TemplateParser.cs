using System;
using System.Collections.Generic;
using BankScraper.Controllers.IntegratedBanks;
using BankScraper.Models.Comum;
using BankScraper.Models.Scraper;

namespace BankScraper.Controllers.Banks.Template
{
    public class TemplateParser : IBanks
    {
        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <returns>The account.</returns>
        /// <param name="login">Login.</param>
        public Account GetAccount(Login login)
        {

            Account account = new Account() {};

            Customer customer = new Customer();
            Purchase purchase = new Purchase();
            BillsSummary billsSummary = new BillsSummary();

            List<Events> events = new List<Events>() { };
            List<Purchase> purchases = new List<Purchase>();




            try
            {
                //########### Account info ####################################
                account.bank = login.bank;
                account.number = login.account_number;

                //############ Customer info ##################################
                customer.address_state  = "Nuremberg";
                customer.cpf = null;
                customer.email = "pachelbel@pachelbel.com";
                customer.address_postcode = "90411180";
                customer.billing_address_line1 = "Street of Music";
                customer.billing_address_state = "Province Nuremberg";
                customer.address_number = "1653";
                customer.billing_address_city = "City of Nuremberg";
                customer.phone = null;
                customer.billing_address_locality = "Neighborhood of Nuremberg";
                customer.name = "Johann Pachelbel";
                customer.nationality = "GER";
                customer.billing_address_line2 = "Opera";
                customer.printed_name = "Pachelbel";
                customer.preferred_name = "Mr. Pachelbel";
                customer.address_country = "German";
                customer.address_line2 = "House of Pachelbel AP. 404";
                customer.billing_address_postcode = "90411180";
                customer.dob = "09-01-1653";
                customer.id = "id-unique";
                customer.address_locality = "Neighborhood of Nuremberg";
                customer.marital_status = "Single";
                customer.billing_address_country = "German";
                customer.address_line1 = "Street Nuremberg";
                customer.gender = "Male";
                customer.billing_address_number = "1653";
                customer.reported_income = "USD: 20000,00";
                customer.mothers_name = "Anna Maria Mair";
                customer.invitations = "10";
                customer.address_city = "City of nurember";
                customer.personal_credit = "60000,00";
                account.customer = customer;

                //############ Bills summary ####################################
                billsSummary.payments = "1345,00";
                billsSummary.interest_charge = "00,00";
                billsSummary.total_international = "00.00";
                billsSummary.due_date = "02-24-2018";
                billsSummary.precise_minimum_payment = "735,00";
                billsSummary.interest_reversal = "00.00";
                billsSummary.close_date = "02-10-2018";
                billsSummary.expenses = "3500,00";
                billsSummary.total_credits = "5700,00";
                billsSummary.past_balance = "1235,00";
                billsSummary.effective_due_date = "02-24-2018";
                billsSummary.international_tax = "20% am";
                billsSummary.tax = "3.91";
                billsSummary.adjustments = "00.00";
                billsSummary.precise_total_balance = "1345,00";
                billsSummary.total_financed = "2578,00";
                billsSummary.total_balance = "2578,00";
                billsSummary.interest_rate = "14%";
                billsSummary.total_national = "1345,00";
                billsSummary.previous_bill_balance = "82,00";
                billsSummary.interest = null;
                billsSummary.total_cumulative = "10.000";
                billsSummary.paid = "true";
                billsSummary.fees = null;
                billsSummary.total_payments = "10.000";
                billsSummary.minimum_payment = "735,00";
                billsSummary.open_date = "02-01-2018";
                billsSummary.total_accrued = "15123.00";

                //Account events
                //Add list
                events.Add(new Events()
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
                events.Add(new Events()
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
                events.Add(new Events()
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
                purchases.Add(new Purchase()
                {
                    id = "1",
                    value = "700,00",
                    description = "Amazon new smart watch Garmin Fenix 5",
                    timestamp = DateTime.Now.ToString(),
                    currency = "EUR"
                });
                //Account purchases
                purchases.Add(new Purchase()
                {
                    id = "2",
                    value = "100,00",
                    description = "Amazon Alexa home",
                    timestamp = DateTime.Now.ToString(),
                    currency = "EUR"
                });


                //Add to account
                account.events = events;
                account.purchase = purchases;


            }
            catch (Exception e)
            {
                throw e;
            }
            return account;
        }

    }
}
