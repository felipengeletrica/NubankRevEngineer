using System;

namespace BankScraper.Models.Nubank
{
    public class NubankDevices
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        string id { get; set; }
        string device_id { get; set; }
        string[] user_agent { get; set; }
        string pushToken { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Scraper.Devices"/> class.
        /// </summary>
        public NubankDevices()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Scraper.Devices"/> class.
        /// </summary>
        /// <param name="Id">Identifier.</param>
        /// <param name="Devices_id">Devices identifier.</param>
        /// <param name="User_agent">User agent.</param>
        /// <param name="PushToken">Push token.</param>
        public NubankDevices(string Id, string Devices_id, string[] User_agent, string PushToken)
        {
            id = Id;
            device_id = Devices_id;
            user_agent = User_agent;
            pushToken = PushToken;
        }
    }
}
