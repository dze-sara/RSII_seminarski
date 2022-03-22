using Rentacar.Dto;
using Rentacar.Services.Interfaces;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Services.Services
{
    public class StripeIntegrationService : IPaymentProcessingService
    {
        public async Task<bool> AddPayment(CardInfoDto cardInfo, decimal amount)
        {
            var x = ConfigurationManager.AppSettings["Stripe"];
            StripeConfiguration.ApiKey = "sk_test_51KgEA8GC5YHd2kehZRJeuFUvsThfFAwMYXkd715OBojouc6Vt0yVl1rusVLbDhmiMADPX0RyEq5mmlY8pRHYfwek007XM5Yofp";

            PaymentMethod paymentMethod = CreatePaymentMethod(cardInfo);
            
            if (paymentMethod.Id != null)
            {
                // Create the PaymentIntent
                CreatePaymentIntent(amount, paymentMethod.Id);
            }

            return true;
        }

        private PaymentIntent CreatePaymentIntent(decimal amount, string paymentMethodId)
        {
            var createOptions = new PaymentIntentCreateOptions
            {
                PaymentMethod = paymentMethodId,
                Amount = (long)amount*100,
                Currency = "eur",
            };
            PaymentIntentService paymentIntentService = new PaymentIntentService();
            PaymentIntent paymentIntent = paymentIntentService.Create(createOptions);

            if (paymentIntent.Id != null)
            {
                var confirmOptions = new PaymentIntentConfirmOptions { };
                paymentIntent = paymentIntentService.Confirm(
                    paymentIntent.Id,
                    confirmOptions
                );
            }

            return paymentIntent;
        }

        private PaymentMethod CreatePaymentMethod(CardInfoDto cardInfo)
        {
            var paymentMethodOptions = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = cardInfo.CardNumber,
                    ExpMonth = GetExpMonth(cardInfo.ExpiryDate),
                    ExpYear = GetExpYear(cardInfo.ExpiryDate),
                    Cvc = cardInfo.CVV,
                },
            };
            var paymentMethodService = new PaymentMethodService();
            PaymentMethod paymentMethod = paymentMethodService.Create(paymentMethodOptions);
            return paymentMethod;
        }

        private int GetExpMonth(string expDate)
        {
            return int.Parse(expDate.Split("/").First());
        }

        private int GetExpYear(string expDate)
        {
            return int.Parse(expDate.Split("/").Last());

        }
    }
}
