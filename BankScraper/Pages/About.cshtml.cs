using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankScraper.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }
        public string Explanation { get; set; }

        public void OnGet()
        {
            Message = "Web Bank scraps";
            Explanation = "Programa para captura de dados bancários automaizados Web Scraper. Para verificar seus saldos entre na";
            Explanation += " pagína principal \"Home\" e digite seus dados bancários solicitados.";
        }
    }
}
