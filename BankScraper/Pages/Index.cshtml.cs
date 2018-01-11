using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BankScraper.Controllers;
using BankScraper.Models.Comum;
using BankScraper.Models.Scraper;


namespace BankScraper.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Bank> banks { get; set; }
        [BindProperty]
        public Account account { get; set; } = null;
        [BindProperty]
        public Login login { get; set; }


        //Create instance banks scrappers
        Controllers.BankScraper bankScraper = new Controllers.BankScraper();
       
        /// <summary>
        /// Ons the get.
        /// </summary>
        public void OnGet()
        {

            banks = bankScraper.ListBanks();
            account = null;           
        }

        /// <summary>
        /// Ons the post.
        /// </summary>
        public void OnPost()
        {

            if(ModelState.IsValid)
            {
                banks = bankScraper.ListBanks();
                account = bankScraper.CheckAccounts(login);
            }

        }
    }
}
