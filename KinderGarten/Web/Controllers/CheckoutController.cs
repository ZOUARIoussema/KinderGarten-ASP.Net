using Newtonsoft.Json;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CheckoutController : Controller
    {
        [Route("create-payment-intent")]
        [HttpPost]
        public ActionResult Create(PaymentIntentCreateRequest request)
        {

            System.Diagnostics.Debug.WriteLine(request);

            // This is your real test secret API key.
            StripeConfiguration.ApiKey = "sk_test_51IRgyaJ3wGblCO7QrvCjRizYM4jmNFAvsStxCKN9pjCdDfeCuybbC9FCBgEACCC4UiAKlk0a7hw6ei3FMVCbu1KH00mUcpCkti";

            var paymentIntents = new PaymentIntentService();
            var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
            {
                Amount = CalculateOrderAmount(request.Items),
                Currency = "usd",
            });
            return Json(new { clientSecret = paymentIntent.ClientSecret });
        }

        private int CalculateOrderAmount(Item[] items)
        {
            // Replace this constant with a calculation of the order's amount
            // Calculate the order total on the server to prevent
            // people from directly manipulating the amount on the client
            return 1400;
        }

        public class Item
        {
            [JsonProperty("id")] public string Id { get; set; }
        }

        public class PaymentIntentCreateRequest
        {
            [JsonProperty("items")] public Item[] Items { get; set; }
        }
    }
}