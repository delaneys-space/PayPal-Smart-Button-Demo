using PayPalCheckoutSdk.Orders;
using System.Collections.Generic;

namespace PayPal
{
    public static class OrderBuilder
    {
        /// <summary>
        /// Use classes from the PayPalCheckoutSdk to build an OrderRequest
        /// </summary>
        /// <returns></returns>
        public static OrderRequest Build(Delaney.Services.Data.Core.IUnitOfWork unitOfWork)
        {

            var basket = unitOfWork.Baskets.SingleOrDefault(x => x.Id == x.Id);

            if (basket == null)
                return null;

            //https://developer.paypal.com/docs/api/reference/locale-codes/#


            OrderRequest orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = PayPal.Values.CheckoutPaymentIntent.CAPTURE,
                ApplicationContext = new ApplicationContext
                {
                    BrandName = "Delaneys.space",
                    LandingPage = PayPal.Values.LandingPage.LOGIN,
                    UserAction = PayPal.Values.UserAction.PAY_NOW,
                    ShippingPreference = PayPal.Values.ShippingPreference.NO_SHIPPING,
                    Locale = "en-GB"
                },
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest
                    {
                        //ReferenceId = "Delaneys.space", // [required] The merchant ID for the purchase unit.
                        Description = "Software published by Delaneys.space",
                        SoftDescriptor = "Delaneys.space",
                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                            CurrencyCode = PayPal.Values.CurrencyCode.GBP,
                            Value = basket.Total.ToString(),
                            AmountBreakdown = new AmountBreakdown
                            {
                                ItemTotal = new Money
                                {
                                    CurrencyCode = basket.CurrencyCode,
                                    Value = basket.SubTotal.ToString()
                                },
                                Discount = new Money
                                {
                                    CurrencyCode = basket.CurrencyCode,
                                    Value = basket.Discount.ToString()
                                }
                            }
                        },
                        Items = new List<Item>()
                    }
                }
            };

            foreach (var product in basket.Products)
            {
                orderRequest.PurchaseUnits[0]
                            .Items
                            .Add(new Item
                            {
                                Name = product.Name,
                                Description = product.Description,
                                UnitAmount = new Money
                                {
                                    CurrencyCode = basket.CurrencyCode,
                                    Value = product.Price.ToString()
                                },
                                Quantity = product.Quantity.ToString(),
                                Category = PayPal.Values.Item.Category.DIGITAL_GOODS
                            });
            }


            return orderRequest;
        }
    }
}