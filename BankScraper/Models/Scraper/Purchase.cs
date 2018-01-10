using System;
namespace BankScraper.Models.Scraper
{
    public class Purchase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string id { get; set; }
        public string value { get; set; }
        public string description { get; set; }
        public string timestamp { get; set; }
        public string currency { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Transaction"/> class.
        /// </summary>
            public Purchase() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Transaction"/> class.
        /// </summary>
        /// <param name="Id">Identifier.</param>
        /// <param name="Value">Value.</param>
        /// <param name="Description">Description.</param>
        /// <param name="Timestamp">Timestamp.</param>
        /// <param name="Currency">Currency.</param>
            public Purchase(string Id, string Value, string Description, string Timestamp, string Currency)
        {
            id = Id;
            value = Value;
            description = Description;
            timestamp = Timestamp;
            currency = Currency;
        }
        
    }
}
