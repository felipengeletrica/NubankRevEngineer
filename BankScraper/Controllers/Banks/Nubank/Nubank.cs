//Class based on Andre C.Gusmão's banksscraper project on github
//https://github.com/AndreCGusmao/bankscraper
//

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

namespace BankScraper.Controllers.IntegratedBanks
{
    /// <summary>
    /// Nubank.
    /// </summary>
    public class Nubank : IBanks 
    {

        private JObject JNubankToken = new JObject() { };
        private string token_url = "https://prod-auth.nubank.com.br/api/token";
        private string user_agent = "User-Agent: Android;Google Nexus 5 - 6.0.0 - API 23 - 1080x1920;Android;6.0;vbox86p-userdebug 6.0 MRA58K eng.buildbot.20160110.195928 test-keys;mov-android-app;6.14.0.1;en_US;cpu=0|clock=|ram=2052484 kB|espacoSDInterno=12.46 GB|isSmartphone=true|nfc=false|camera=true|cameraFrontal=true|root=true|reconhecimentoVoz=false|resolucao=1080_1776|densidade=3.0|";
        private CookieContainer cookies = new CookieContainer();


        Utils util = new Utils();

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <returns>The account.</returns>
        /// <param name="login">Login.</param>
        public  Account GetAccount(Login login)
        {
            //Scrapers abstraction 
            Account account = new Account(){};
           
            try
            {
                bool status = connect(login);
                if (status)
                {
                    account = NubankToAccount();
                }
                
            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                disconnect();
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
            jevents = getEvents();
            bills = getBillsSummary();
            customer = getCustomer();
            purchases = getPurchases();


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
            IList<JToken> events = _events.Children().ToList();
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

        /// <summary>
        /// Connect the specified login.
        /// </summary>
        /// <returns>The connect.</returns>
        /// <param name="login">Login.</param>
        private bool connect(Login login)
        {

            bool status = false;
            string json = String.Empty;

            try
            {
                string payload =
                    "{\"grant_type\": \"password\"," +
                    "\"login\": \"" + util.filter(login.account_number) + "\"," +
                    "\"password\": \"" + login.password + "\"," +
                    "\"client_id\": \"other.conta\"," +
                    "\"client_secret\": \"yQPeLzoHuJzlMMSAjC-LgNUJdUecx8XO\"}";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(token_url);
                request.Timeout = 10000;
                //request.CookieContainer = cookies;
                request.AllowWriteStreamBuffering = true;
                request.ProtocolVersion = HttpVersion.Version11;
                request.AllowAutoRedirect = true;
                request.Method = WebRequestMethods.Http.Post;
                request.UserAgent = user_agent;
                request.ContentType = "application/json; charset=UTF-8";

                string _enc = Convert.ToBase64String(Encoding.ASCII.GetBytes(payload));
                byte[] byteArray = Encoding.UTF8.GetBytes(payload);
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                string responseString = String.Empty;
                using (var dresponse = (HttpWebResponse)request.GetResponse())
                {
                    try
                    {
                        responseString = new StreamReader(dresponse.GetResponseStream()).ReadToEnd();
                        cookies = request.CookieContainer;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                //Parser to JSON.
                JNubankToken = JObject.Parse(responseString);
                status = true;

            }
            catch (Exception e)
            {
                throw e;
            }

            return status;
        }

        /// <summary>
        /// Disconnect this instance.
        /// </summary>
        private void disconnect()
        {
            JNubankToken = null;
        }


        /// <summary>
        /// Gets the json data.
        /// </summary>
        /// <returns>The json data.</returns>
        /// <param name="access_feed">Access feed.</param>
        private JObject getJsonData(JToken access_feed)
        {
            JObject JNubank = new JObject();

            try
            {
                //url events 
                //Nodes tokens
                JToken access_token = JNubankToken["access_token"];
                //Mount headers and URL
                string headers = "Bearer " + access_token.Value<string>();
                string feed_url = access_feed.Value<string>();

                //END COOKIE
                HttpWebRequest ndRequest = (HttpWebRequest)WebRequest.Create(feed_url);
                ndRequest.Timeout = 10000;
                ndRequest.CookieContainer = cookies;
                ndRequest.AllowWriteStreamBuffering = true;
                ndRequest.ProtocolVersion = HttpVersion.Version11;
                ndRequest.Method = WebRequestMethods.Http.Get;
                ndRequest.AllowAutoRedirect = true;
                ndRequest.UserAgent = user_agent;
                ndRequest.ContentType = "application/json; charset=UTF-8";
                ndRequest.Headers.Add("Authorization", headers);

                string ndresponseString = String.Empty;

                using (var ndresponse = (HttpWebResponse)ndRequest.GetResponse())
                {
                    try
                    {
                        ndresponseString = new StreamReader(ndresponse.GetResponseStream()).ReadToEnd();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Error in connect server" + e.ToString());
                        throw e;
                    }
                }
                //Parser to JSON.
                JNubank = JObject.Parse(ndresponseString);
            }
            catch (Exception e)
            {
                throw e;
            }

            return JNubank;
        }

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <returns>The events.</returns>
        public JObject getEvents()
        {
            JObject JNubankEvents = new JObject();
            if (JNubankToken.Count < 1)
                throw new Exception("First connect");
            //Events 
            JToken access_feed = JNubankToken["_links"]["events"]["href"];
            try
            {
                JNubankEvents = getJsonData(access_feed);
            }
            catch (Exception e)
            {
                throw e;
            }

            return JNubankEvents;
        }

        /// <summary>
        /// Gets the bills summary.
        /// </summary>
        /// <returns>The bills summary.</returns>
        private JObject getBillsSummary()
        {

            JObject JNubankBills = new JObject();
            //bills_summary
            JToken access_feed = JNubankToken["_links"]["bills_summary"]["href"];
            try
            {
                JNubankBills = getJsonData(access_feed);

            }
            catch (Exception e)
            {
                throw e;
            }
            return JNubankBills;
        }

        /// <summary>
        /// Gets the customer informations
        /// </summary>
        /// <returns>The customer.</returns>
        private JObject getCustomer()
        {
            JObject JNubank = new JObject();
            //bills_summary
            JToken access_feed = JNubankToken["_links"]["customer"]["href"];
            try
            {
                JNubank = getJsonData(access_feed);

            }
            catch (Exception e)
            {
                throw e;
            }
            return JNubank;
        }

        /// <summary>
        /// Gets the purchases.
        /// </summary>
        /// <returns>The purchases.</returns>
        private JObject getPurchases()
        {

            JObject JNubank = new JObject();
            //bills_summary
            JToken access_feed = JNubankToken["_links"]["purchases"]["href"];
            try
            {
                JNubank = getJsonData(access_feed);

            }
            catch (Exception e)
            {
                throw e;
            }
            return JNubank;
        }
    }
}
