using System.Net;
using System.Net.Http.Headers;

namespace PayPal
{
    public class SmartButtonHttpResponse
    {
        readonly PayPalCheckoutSdk.Orders.Order _result;
        public SmartButtonHttpResponse(PayPalHttp.HttpResponse httpResponse)
        {
            Headers = httpResponse.Headers;
            StatusCode = httpResponse.StatusCode;
            _result = httpResponse.Result<PayPalCheckoutSdk.Orders.Order>();
        }

        public HttpHeaders Headers { get; }
        public HttpStatusCode StatusCode { get; }

        public PayPalCheckoutSdk.Orders.Order Result()
        {
            return _result;
        }

        public string orderID { get; set; }
    }
}