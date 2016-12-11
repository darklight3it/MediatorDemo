namespace MediatorDemo.Controllers
{
    using System;
    using System.Collections.Generic;

    using BusinessLogic.Requests;
    using BusinessLogic.Responses;

    using MediatR;

    public class DemoController
    {
        private readonly IMediator mediator;

        public DemoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region Request Pizza

        public async void RequestPizza()
        {
            var request = new PizzaOrderRequest
                {
                    Address = "Via di prova 2, Crespellano",
                    Order = new Dictionary<PizzaType, int> { { PizzaType.Patatine, 15 }, { PizzaType.Margherita, 1 } }
                };

            PizzaOrderResponse response = await mediator.SendAsync(request);

            Console.Out.Write(
                "The bill is " + response.Bill + " EUR, and it will be delivered to " + request.Address + " at "
                + response.DeliveryTime + "\n");

            Console.ReadKey();
        }

        #endregion

        #region Cancel Pizza Order

        public void CancelPizzaOrder()
        {
            var request = new PizzaOrderCancellationRequest { OrderId = Guid.NewGuid() };

            try
            {
                mediator.Send(request);

                Console.Out.Write("The order " + request.OrderId + " is cancelled\n");
            }
            catch (ArgumentNullException)
            {
                Console.Out.Write("The order cannot be cancelled\n");
            }

            Console.ReadKey();
        }

        #endregion

        #region Request Pizza Advanced

        public async void RequestPizzaAdvanced()
        {
            var request = new PizzaOrderRequest
                {
                    Address = "Via di prova 2, Crespellano",
                    Order = new Dictionary<PizzaType, int> { { PizzaType.Patatine, 15 }, { PizzaType.Margherita, 1 } }
                };

            Console.Out.Write("Processing Your Order....\n");

            try
            {
                PizzaOrderResponse response = await mediator.SendAsync(request);

                Console.Out.Write(
                    "The bill is " + response.Bill + " EUR, and it will be delivered to " + request.Address + " at "
                    + response.DeliveryTime + "\n");
            }
            catch (ArgumentNullException)
            {
                Console.Out.Write("The order cannot be processed\n");
            }

            Console.ReadKey();
        }

        #endregion
        
        #region Request Pizza Advanced With Notification

        public async void RequestPizzaAdvancedWithNotification()
        {
            var request = new PizzaOrderRequest
                {
                    Address = "Via di prova 2, Crespellano",
                    Order = new Dictionary<PizzaType, int> { { PizzaType.Patatine, 15 }, { PizzaType.Margherita, 1 } }
                };

            Console.Out.Write("Processing Your Order....\n");

            try
            {
                PizzaOrderResponse response = await mediator.SendAsync(request);

                Console.Out.Write(
                    "The bill is " + response.Bill + " EUR, and it will be delivered to " + request.Address + " at "
                    + response.DeliveryTime + "\n");

                var notification = new PizzaOrderNotification
                {
                    OrderId = response.OrderId
                };

                await mediator.PublishAsync(notification);

            }
            catch (ArgumentNullException)
            {
                Console.Out.Write("The order cannot be processed\n");
            }

            Console.ReadKey();
        }

        #endregion
    }
}