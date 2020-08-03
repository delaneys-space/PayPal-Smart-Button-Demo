using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayPal.Values
{
    public static class CurrencyCode
    {

        /// <summary>
        /// Great British Pounds
        /// </summary>
        public static string GBP { get; private set; } = "GBP";

        /// <summary>
        /// US Dolars
        /// </summary>
        public static string USD { get; private set; } = "USD";

        /// <summary>
        /// Euros
        /// </summary>
        public static string EUR { get; private set; } = "EUR";
    }
}
