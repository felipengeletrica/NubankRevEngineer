using System;
using System.ComponentModel.DataAnnotations;

namespace BankScraper.Models
{

    /// <summary>
    /// Login.
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        /// <value>The bank.</value>
        /// 
        /// 

        public string bank { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string account_number { get; set; }
        public string account_agency { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Login"/> class.
        /// </summary>
        public Login() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Login"/> class.
        /// </summary>
        /// <param name="Bank">Bank.</param>
        /// <param name="User">User.</param>
        /// <param name="Password">Password.</param>
        /// <param name="Account_number">Account number.</param>
        /// <param name="Account_agency">Account agency.</param>
        public Login(string Bank, string User, string Password, string Account_number, string Account_agency)
        {
            bank = Bank;
            user = User;
            password = Password;
            account_number = Account_number;
            account_agency = Account_agency;
        }
    }
}
