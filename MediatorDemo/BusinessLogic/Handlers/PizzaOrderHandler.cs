namespace MediatorDemo.BusinessLogic.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Requests;

    using Responses;

    public class PizzaOrderHandler : IAsyncRequestHandler<PizzaOrderRequest, PizzaOrderResponse>
    {
        private static Dictionary<PizzaType, double> PriceList
            =>
                new Dictionary<PizzaType, double>
                    {
                        { PizzaType.Margherita, 5 },
                        { PizzaType.Capricciosa, 8 },
                        { PizzaType.Cotto, 7 },
                        { PizzaType.Crudo, 8 },
                        { PizzaType.Patatine, 6 },
                        { PizzaType.Diavola, 6 }
                    };

        public Task<PizzaOrderResponse> Handle(PizzaOrderRequest message)
        {
            Thread.Sleep(5000);
            if (message.Order == null || message.Address == null) throw new ArgumentNullException("You must specify the order and the delivery address");

            var random = new Random();

            var pizzaOrderResponse = new PizzaOrderResponse
                {
                    Bill = CalculatePrice(message.Order),
                    DeliveryTime = DateTime.Now + TimeSpan.FromMinutes(random.NextDouble() * 30),
                    OrderId = Guid.NewGuid()
                };

            return Task.FromResult(pizzaOrderResponse);
        }

        #region Private Memberss

        private static double CalculatePrice(Dictionary<PizzaType, int> order)
        {
            return order.Sum((source) => source.Value * PriceList[source.Key]);
        }

        #endregion
    }
}