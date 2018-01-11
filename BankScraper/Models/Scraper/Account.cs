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
        public string cpf { get; set; }
        public string branch { get; set; }
        public string password { get; set; }
        public string personal_credit { get; set; }
        public string number { get; set; }
        public string status { get; set; }
        public string owner { get; set; }
        public List<Events> events{ get; set; }
        public List<Purchase> purchase { get; set; }
        public Customer customer { get; set; }
        public string currency { get; set; }
        public string overdraft { get; set; }
        public string interest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Account"/> class.
        /// </summary>
        public Account(){}

       
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Account"/> class.
        /// </summary>
        /// <param name="Bank">Bank.</param>
        /// <param name="Cpf">Cpf.</param>
        /// <param name="Branch">Branch.</param>
        /// <param name="Password">Password.</param>
        /// <param name="Personal_credit">Personal credit.</param>
        /// <param name="Number">Number.</param>
        /// <param name="Status">Status.</param>
        /// <param name="Owner">Owner.</param>
        /// <param name="Events">Events.</param>
        /// <param name="Purchase">Purchase.</param>
        /// <param name="Currency">Currency.</param>
        /// <param name="Overdraft">Overdraft.</param>
        /// <param name="Interest">Interest.</param>
        public Account(string Bank, string Cpf, string Branch, string Password, 
                       string Personal_credit, string Number, string Status, 
                       string Owner, List<Events> Events, List<Purchase> Purchase, 
                       string Currency, string Overdraft, string Interest){

            bank = Bank;
            cpf = Cpf;
            branch = Branch;
            password = Password;
            personal_credit = Personal_credit;
            number = Number;
            status = Status;
            owner = Owner;
            purchase = Purchase;
            events = Events;
            currency = Currency;
            overdraft = Overdraft;
            interest = Interest;
        }

    }
}
