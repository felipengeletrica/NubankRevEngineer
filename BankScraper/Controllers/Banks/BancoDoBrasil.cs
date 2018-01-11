//Class based on Andre C.Gusmão's banksscraper project on github
//https://github.com/AndreCGusmao/bankscraper
//
using System;
using BankScraper.Models.Comum;
using BankScraper.Models.Scraper;
using BankScraper.Controllers.IntegratedBanks;


namespace BankScraper.Controllers
{
    /// <summary>
    /// Banco do brasil.
    /// </summary>
    public class BancoDoBrasil : IBanks
    {

        //URLS
        private string api_endpoint = "https://mobi.bb.com.br/mov-centralizador/";
        private string idDispositivo = "000000000000000";
        private string ida = "00000000000000000000000000000000";

        private string hash_url = "https://mobi.bb.com.br/mov-centralizador/hash";
        private string login_url = "https://mobi.bb.com.br/mov-centralizador/servico/ServicoLogin/login";
        private string balance_url = "https://mobi.bb.com.br/mov-centralizador/servico/ServicoSaldo/saldo";
        private string transactions_url = "https://mobi.bb.com.br/mov-centralizador/tela/ExtratoDeContaCorrente/extrato";

        private string post_login_warmup_url1 = "https://mobi.bb.com.br/mov-centralizador/servico/ServicoVersionamento/servicosVersionados";
        private string post_login_warmup_url2 = "https://mobi.bb.com.br/mov-centralizador/servico/ServicoVersaoCentralizador/versaoDaAplicacaoWeb";
        private string post_login_warmup_url3 = "https://mobi.bb.com.br/mov-centralizador/servico/ServicoMenuPersonalizado/menuPersonalizado";
        private string post_login_warmup_url4 = "https://mobi.bb.com.br/mov-centralizador/servico/ServicoMenuTransacoesFavoritas/menuTransacoesFavoritas";

        /// <summary>
        /// Ges the account.
        /// </summary>
        /// <returns>The account.</returns>
        /// <param name="login">Login.</param>
        public Account GetAccount(Login login)
        {

            //throw new Exception("Bank not implementad");
           
            Account account = new Account(){};
            return account;
        }
    }
}
