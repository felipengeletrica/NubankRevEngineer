using System;
namespace BankScraper.Models.Scraper
{
    public class Purchase
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public string category { get; set; }
        public string amount { get; set; }
        public string precise_amount { get; set; }
        public string time { get; set; }
        public string charges { get; set; }
        public string original_merchant_name { get; set; }
        public string type { get; set; }
        public string mcc { get; set; }
        public string[] approved_reasons { get; set; }
        public string expires_on { get; set; }
        public string auth_code { get; set; }
        public string country { get; set; }
        public string time_wallclock { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JSON.NubankPurchases"/> class.
        /// </summary>
        public Purchase()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:JSON.NubankPurchases"/> class.
        /// </summary>
        /// <param name="Category">Category.</param>
        /// <param name="Amount">Amount.</param>
        /// <param name="Precise_amount">Precise amount.</param>
        /// <param name="Time">Time.</param>
        /// <param name="Charges">Charges.</param>
        /// <param name="Original_merchant_name">Original merchant name.</param>
        /// <param name="Type">Type.</param>
        /// <param name="Mcc">Mcc.</param>
        /// <param name="Approved_reasons">Approved reasons.</param>
        /// <param name="Expires_on">Expires on.</param>
        /// <param name="Auth_code">Auth code.</param>
        /// <param name="Country">Country.</param>
        /// <param name="Time_wallclock">Time wallclock.</param>
        public Purchase(
            string Category,
            string Amount,
            string Precise_amount,
            string Time,
            string Charges,
            string Original_merchant_name,
            string Type,
            string Mcc,
            string[] Approved_reasons,
            string Expires_on,
            string Auth_code,
            string Country,
            string Time_wallclock)
        {

            category = Category;
            amount = Amount;
            precise_amount = Precise_amount;
            time = Time;
            charges = Charges;
            original_merchant_name = Original_merchant_name;
            type = Type;
            mcc = Mcc;
            approved_reasons = Approved_reasons;
            expires_on = Expires_on;
            auth_code = Auth_code;
            country = Country;
            time_wallclock = Time_wallclock;

        }
    }
}
