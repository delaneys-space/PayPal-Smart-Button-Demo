using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayPal.Values
{
    /// <summary>
    /// The intent to either capture payment immediately or
    /// authorize a payment for an order after order creation.
    /// </summary>
    public static class CheckoutPaymentIntent
    {

        /// <summary>
        /// The merchant intends to capture payment immediately after the customer makes a payment.
        /// </summary>
        public static string CAPTURE { get; private set; } = "CAPTURE";

        /// <summary>
        /// The merchant intends to authorize a payment and
        /// place funds on hold after the customer makes a payment.
        /// Authorized payments are guaranteed for up to three days but
        /// are available to capture for up to 29 days.
        /// After the three-day honor period, the original authorized payment expires
        /// and you must re-authorize the payment.
        /// You must make a separate request to capture payments on demand.
        /// This intent is not supported when you have more than one `purchase_unit` within your order.
        /// </summary>
        public static string AUTHORIZE { get; private set; } = "AUTHORIZE";
    }
}