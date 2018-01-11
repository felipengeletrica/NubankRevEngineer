using System;
using BankScraper.Models;
using BankScraper.Controllers.IntegratedBanks;
using BankScraper.Models.Scraper;
using BankScraper.Models.Comum;

namespace BankScraper.Controllers.Banks.Itau
{
    /// <summary>
    /// Itau.
    /// </summary>
    public class Itau
    {
        private string app_id = "kspf";
        private string app_version = "4.1.19";
        private string platform = "android";
        private string platform_version = "6.0.1";
        private string platform_extra_version = "5.6.GA_v201508271451_r3";
        private string platform_model = "Nexus 5";

        private long device_id = 12345678;
        private long user_id = 1234;

        private string api_endpoint = "https://kms.itau.com.br/middleware/MWServlet";
        private string device_session_template = "Modelo: {platform_model}|Operadora:|VersaoSO:{platform_version}|appIdCore:";
    }
}
