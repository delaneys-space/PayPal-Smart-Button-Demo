using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayPal.Values
{
    /// <summary>
    /// The type of landing page to show on the PayPal site for customer checkout.
    /// Default: NO_PREFERENCE.
    /// Source: https://developer.paypal.com/docs/api/orders/v2/
    /// </summary>
    public class LandingPage
    {
        /// <summary>
        /// When the customer clicks PayPal Checkout, the customer is redirected to a page to log in to PayPal and approve the payment.
        /// </summary>
        public static string LOGIN { get; private set; } = "LOGIN";

        /// <summary>
        /// When the customer clicks PayPal Checkout, 
        /// the customer is redirected to a page to enter credit or 
        /// debit card and other relevant billing information required to complete the purchase.
        /// </summary>
        public static string BILLING { get; private set; } = "BILLING";

        /// <summary>
        /// When the customer clicks PayPal Checkout,
        /// the customer is redirected to either a page to log in to PayPal and
        /// approve the payment or to a page to enter credit or
        /// debit card and other relevant billing information
        /// required to complete the purchase, depending on their previous interaction with PayPal.
        /// </summary>
        public static string NO_PREFERENCE { get; private set; } = "NO_PREFERENCE";
    }
}
