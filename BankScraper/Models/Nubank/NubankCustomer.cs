using System;

namespace BankScraper.Models.Nubank
{
    public class NubankCustomer
    {
        /// <summary>
        /// Gets or sets the state of the address.
        /// </summary>
        /// <value>The state of the address.</value>
        string address_state { get; set; }
        string cpf { get; set; }
        string email { get; set; }
        string address_postcode { get; set; }
        string billing_address_line1 { get; set; }
        string billing_address_state { get; set; }
        NubankDevices[] devices { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Scraper.Customer"/> class.
        /// </summary>
        public NubankCustomer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Scraper.Customer"/> class.
        /// </summary>
        /// <param name="Address_state">Address state.</param>
        /// <param name="Cpf">Cpf.</param>
        /// <param name="Email">Email.</param>
        /// <param name="Address_postcode">Address postcode.</param>
        /// <param name="Billing_address_line1">Billing address line1.</param>
        /// <param name="Billing_address_state">Billing address state.</param>
        /// <param name="Devices">Devices.</param>
        public NubankCustomer(string Address_state, string Cpf, string Email, 
                              string Address_postcode, string Billing_address_line1,
                              string Billing_address_state, NubankDevices[] Devices)
        {

            address_state = Address_state;
            cpf = Cpf;
            email = Email;
            address_postcode = Address_postcode;
            billing_address_line1 = Billing_address_line1;
            billing_address_state = Billing_address_state;
            devices = Devices;
        }
    }
}
