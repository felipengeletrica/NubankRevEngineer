using System;
using Microsoft.EntityFrameworkCore;

namespace BankScraper.Models
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Account{ get; set; }
    }
}
