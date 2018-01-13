using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BankScraper.Models;
using BankScraper.Models.Scraper;

namespace BankScraper.Models.Scraper
{
    /// <summary>
    /// Account.
    /// </summary>
    public class Account
    {
        [Display(Name = "Banco:")]
        [DataType(DataType.Text)]
        public string bank { get; set; }
        public string branch { get; set; }
        public string password { get; set; }
        public string number { get; set; }
        public string status { get; set; }
        public List<Events> events{ get; set; }
        public List<Purchase> purchase { get; set; }
        public Customer customer { get; set; }
        public BillsSummary billsSummary { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Account"/> class.
        /// </summary>
        public Account(){}

       
       /// <summary>
       /// Initializes a new instance of the <see cref="T:BankScraper.Models.Scraper.Account"/> class.
       /// </summary>
       /// <param name="Bank">Bank.</param>
       /// <param name="Branch">Branch.</param>
       /// <param name="Password">Password.</param>
       /// <param name="Number">Number.</param>
       /// <param name="Status">Status.</param>
       /// <param name="Events">Events.</param>
       /// <param name="Purchase">Purchase.</param>
       /// <param name="Customer">Customer.</param>
       /// <param name="BillsSummary">Bills summary.</param>
        public Account(
            string Bank, 
            string Branch, 
            string Password, 
            string Number, 
            string Status, 
            List<Events> Events, 
            List<Purchase> Purchase,
            Customer Customer,
            BillsSummary BillsSummary
            )
        {

            bank = Bank;
            branch = Branch;
            password = Password;
            number = Number;
            status = Status;
            purchase = Purchase;
            events = Events;
            customer = Customer;
            billsSummary = BillsSummary;
        }

    }
}
