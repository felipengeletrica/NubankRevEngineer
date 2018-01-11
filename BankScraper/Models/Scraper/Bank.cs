using System;
namespace BankScraper.Models.Scraper
{
    public class Bank
    {
        /// <summary>
        /// Gets or sets the bank names.
        /// </summary>
        /// <value>The bank names.</value>
        public string BankNames { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Bank"/> class.
        /// </summary>
        public Bank(){}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Bank"/> class.
        /// </summary>
        /// <param name="banknames">Banknames.</param>
        public Bank(string banknames)
        {
            BankNames = banknames;
        }
    }
}
