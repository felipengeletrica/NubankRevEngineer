using System;

namespace BankScraper.Models.Scraper
{

    public class BillsSummary
    {
        /// <summary>
        /// Gets or sets the payments.
        /// </summary>
        /// <value>The payments.</value>
        public string payments { get; set; }
        public string interest_charge { get; set; }
        public string total_international { get; set; }
        public string due_date { get; set; }
        public string precise_minimum_payment { get; set; }
        public string interest_reversal { get; set; }
        public string close_date { get; set; }
        public string expenses { get; set; }
        public string total_credits { get; set; }
        public string past_balance { get; set; }
        public string effective_due_date { get; set; }
        public string international_tax { get; set; }
        public string tax { get; set; }
        public string adjustments { get; set; }
        public string precise_total_balance { get; set; }
        public string total_financed { get; set; }
        public string total_balance { get; set; }
        public string interest_rate { get; set; }
        public string total_national { get; set; }
        public string previous_bill_balance { get; set; }
        public string interest { get; set; }
        public string total_cumulative { get; set; }
        public string paid { get; set; }
        public string fees { get; set; }
        public string total_payments { get; set; }
        public string minimum_payment { get; set; }
        public string open_date { get; set; }
        public string total_accrued { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Nubank.NubankBillsSummary"/> class.
        /// </summary>
        public BillsSummary()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BankScraper.Models.Nubank.NubankBillsSummary"/> class.
        /// </summary>
        /// <param name="Payments">Payments.</param>
        /// <param name="Interest_charge">Interest charge.</param>
        /// <param name="Total_international">Total international.</param>
        /// <param name="Due_date">Due date.</param>
        /// <param name="Precise_minimum_payment">Precise minimum payment.</param>
        /// <param name="Interest_reversal">Interest reversal.</param>
        /// <param name="Close_date">Close date.</param>
        /// <param name="Expenses">Expenses.</param>
        /// <param name="Total_credits">Total credits.</param>
        /// <param name="Past_balance">Past balance.</param>
        /// <param name="Effective_due_date">Effective due date.</param>
        /// <param name="International_tax">International tax.</param>
        /// <param name="Tax">Tax.</param>
        /// <param name="Adjustments">Adjustments.</param>
        /// <param name="Precise_total_balance">Precise total balance.</param>
        /// <param name="Total_financed">Total financed.</param>
        /// <param name="Total_balance">Total balance.</param>
        /// <param name="Interest_rate">Interest rate.</param>
        /// <param name="Total_national">Total national.</param>
        /// <param name="Previous_bill_balance">Previous bill balance.</param>
        /// <param name="Interest">Interest.</param>
        /// <param name="Total_cumulative">Total cumulative.</param>
        /// <param name="Paid">Paid.</param>
        /// <param name="Fees">Fees.</param>
        /// <param name="Total_payments">Total payments.</param>
        /// <param name="Minimum_payment">Minimum payment.</param>
        /// <param name="Open_date">Open date.</param>
        /// <param name="Total_accrued">Total accrued.</param>
       
            public BillsSummary(
            string Payments,
            string Interest_charge,
            string Total_international,
            string Due_date,
            string Precise_minimum_payment,
            string Interest_reversal,
            string Close_date,
            string Expenses,
            string Total_credits,
            string Past_balance,
            string Effective_due_date,
            string International_tax,
            string Tax,
            string Adjustments,
            string Precise_total_balance,
            string Total_financed,
            string Total_balance,
            string Interest_rate,
            string Total_national,
            string Previous_bill_balance,
            string Interest,
            string Total_cumulative,
            string Paid,
            string Fees,
            string Total_payments,
            string Minimum_payment,
            string Open_date,
            string Total_accrued,
            string Amount
            )
        {
            payments = Payments;
            interest_charge = Interest_charge;
            total_international = Total_international;
            due_date = Due_date;
            precise_minimum_payment = Precise_minimum_payment;
            interest_reversal = Interest_reversal;
            close_date = Close_date;
            expenses = Expenses;
            total_credits = Total_credits;
            past_balance = Past_balance;
            effective_due_date = Effective_due_date;
            international_tax = International_tax;
            tax = Tax;
            adjustments = Adjustments;
            precise_total_balance = Precise_total_balance;
            total_financed = Total_financed;
            total_balance = Total_balance;
            interest_rate = Interest_rate;
            total_national = Total_national;
            previous_bill_balance = Previous_bill_balance;
            interest = Interest;
            total_cumulative = Total_cumulative;
            paid = Paid;
            fees = Fees;
            total_payments = Total_payments;
            minimum_payment = Minimum_payment;
            open_date = Open_date;
            total_accrued = Total_accrued;
        }

        public static implicit operator string(BillsSummary v)
        {
            throw new NotImplementedException();
        }
    }
}
