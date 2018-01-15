using System;

namespace BankScraper.Controllers
{
    public class Utils
    {
        /// <summary>
        /// Converts the value.
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="value">Value.</param>
        public string ConvertValue(string value, int Divide = 100, string format = "0.00")
        {
            return (Convert.ToInt64(value) / Divide).ToString(format);
        }

        /// <summary>
        /// Filter the specified data.
        /// </summary>
        /// <returns>The filter.</returns>
        /// <param name="data">Data.</param>
        public string filter(string data)
        {
            return (data.Replace(".", "").Replace("-", ""));
        }
    }
}
