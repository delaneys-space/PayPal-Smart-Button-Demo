namespace PayPal.Values
{
    /// <summary>
    /// The shipping preference:
    /// <ul>
    /// <li>Displays the shipping address to the customer.</li>
    /// <li>Enables the customer to choose an address on the PayPal site.</li>
    /// <li>Restricts the customer from changing the address during the payment-approval process.</li>
    /// </ul>
    /// Default: GET_FROM_FILE.
    /// Source: https://developer.paypal.com/docs/api/orders/v2/
    /// </summary>
    public static class ShippingPreference
    {
        /// <summary>
        /// Use the customer-provided shipping address on the PayPal site.
        /// </summary>
        public static string GET_FROM_FILE { get; private set; } = "GET_FROM_FILE";

        /// <summary>
        /// Redact the shipping address from the PayPal site. Recommended for digital goods.
        /// </summary>
        public static string NO_SHIPPING { get; private set; } = "NO_SHIPPING";

        /// <summary>
        /// Use the merchant-provided address. The customer cannot change this address on the PayPal site.
        /// </summary>
        public static string SET_PROVIDED_ADDRESS { get; private set; } = "SET_PROVIDED_ADDRESS";
    }
}