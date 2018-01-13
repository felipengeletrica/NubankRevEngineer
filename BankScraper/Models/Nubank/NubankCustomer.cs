using System;

namespace BankScraper.Models.Nubank
{
    public class NubankCustomer
    {
        public string address_state { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string address_postcode { get; set; }
        public string billing_address_line1 { get; set; }
        public string billing_address_state { get; set; }
        //public primary_device primary_device { get; set; }
        public string address_number { get; set; }
        //public string[] channels { get; set; }
        public string billing_address_city { get; set; }
        public string phone { get; set; }
        public string billing_address_locality { get; set; }
        public string name { get; set; }
        public string nationality { get; set; }
        public string billing_address_line2 { get; set; }
        public string printed_name { get; set; }
        //public foursquare[]  external_ids{ get; set; }
        public string preferred_name { get; set; }
        public string address_country { get; set; }
        public string address_line2 { get; set; }
        public string billing_address_postcode { get; set; }
        //public string[] documents { get; set; }
        public string dob { get; set; }
        public string id { get; set; }
        public string address_locality { get; set; }
        public string marital_status { get; set; }
        public string billing_address_country { get; set; }
        //public string[] devices { get; set; }
        public string address_line1 { get; set; }
        public string gender { get; set; }
        public string billing_address_number { get; set; }
        //public string[] _links{ get; set; }
        public string reported_income { get; set; }
        public string mothers_name { get; set; }
        public string invitations { get; set; }
        public string address_city { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:NubankCustomer"/> class.
        /// </summary>
        public NubankCustomer()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:NubankCustomer"/> class.
        /// </summary>
        /// <param name="Address_state">Address state.</param>
        /// <param name="Cpf">Cpf.</param>
        /// <param name="Email">Email.</param>
        /// <param name="Address_postcode">Address postcode.</param>
        /// <param name="Billing_address_line1">Billing address line1.</param>
        /// <param name="Billing_address_state">Billing address state.</param>
        /// <param name="Address_number">Address number.</param>
        /// <param name="Billing_address_city">Billing address city.</param>
        /// <param name="Phone">Phone.</param>
        /// <param name="Billing_address_locality">Billing address locality.</param>
        /// <param name="Name">Name.</param>
        /// <param name="Nationality">Nationality.</param>
        /// <param name="Billing_address_line2">Billing address line2.</param>
        /// <param name="Printed_name">Printed name.</param>
        /// <param name="Preferred_name">Preferred name.</param>
        /// <param name="Address_country">Address country.</param>
        /// <param name="Address_line2">Address line2.</param>
        /// <param name="Billing_address_postcode">Billing address postcode.</param>
        /// <param name="Documents">Documents.</param>
        /// <param name="Dob (Date on Born)">Dob.</param>
        /// <param name="Id">Identifier.</param>
        /// <param name="Address_locality">Address locality.</param>
        /// <param name="Marital_status">Marital status.</param>
        /// <param name="Billing_address_country">Billing address country.</param>
        /// <param name="Devices">Devices.</param>
        /// <param name="Address_line1">Address line1.</param>
        /// <param name="Gender">Gender.</param>
        /// <param name="Billing_address_number">Billing address number.</param>
        /// <param name="_Links">Links.</param>
        /// <param name="Reported_income">Reported income.</param>
        /// <param name="Mothers_name">Mothers name.</param>
        /// <param name="Invitations">Invitations.</param>
        /// <param name="Address_city">Address city.</param>
        public NubankCustomer(
            string Address_state,
            string Cpf,
            string Email,
            string Address_postcode,
            string Billing_address_line1,
            string Billing_address_state,
            //primary_device Primary_device,
            string Address_number,
            //string [] Channels,
            string Billing_address_city,
            string Phone,
            string Billing_address_locality,
            string Name,
            string Nationality,
            string Billing_address_line2,
            string Printed_name,
            //foursquare [] External_ids,
            string Preferred_name,
            string Address_country,
            string Address_line2,
            string Billing_address_postcode,
            string[] Documents,
            string Dob,
            string Id,
            string Address_locality,
            string Marital_status,
            string Billing_address_country,
            string[] Devices,
            string Address_line1,
            string Gender,
            string Billing_address_number,
            //string[] _Links,
            string Reported_income,
            string Mothers_name,
            string Invitations,
            string Address_city)
        {
            
            address_state = Address_state;
            cpf = Cpf;
            email = Email;
            address_postcode = Address_postcode;
            billing_address_line1 = Billing_address_line1;
            billing_address_state = Billing_address_state;
            //primary_device = Primary_device;
            address_number = Address_number;
            //channels = Channels;
            billing_address_city = Billing_address_city;
            phone = Phone;
            billing_address_locality = Billing_address_locality;
            name = Name;
            nationality = Nationality;
            billing_address_line2 = Billing_address_line2;
            printed_name = Printed_name;
            //external_ids = External_ids;
            preferred_name = Preferred_name;
            address_country = Address_country;
            address_line2 = Address_line2;
            billing_address_postcode = Billing_address_postcode;
            //documents = Documents;
            dob = Dob;
            id = Id;
            address_locality = Address_locality;
            marital_status = Marital_status;
            billing_address_country = Billing_address_country;
            //devices = Devices;
            address_line1 = Address_line1;
            gender = Gender;
            billing_address_number = Billing_address_number;
            //_links = _Links;
            reported_income = Reported_income;
            mothers_name = Mothers_name;
            invitations = Invitations;
            address_city = Address_city;
        }
    }

}
