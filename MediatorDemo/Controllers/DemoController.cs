namespace MediatorDemo.Controllers
{
    using System;
    using System.Collections.Generic;

    using MediatorDemo.BusinessLogic.Requests;
    using MediatorDemo.BusinessLogic.Responses;

    using MediatR;

    public class DemoController
    {
        private readonly IMediator mediator;

        public DemoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async void Run()
        {
            var request = new PizzaOrderRequest
                {
                    Address = "Via di prova 2, Crespellano",
                    Order = new Dictionary<PizzaType, int> { { PizzaType.Margherita, 2 }, { PizzaType.Diavola, 3 } }
                };

            Console.Out.Write("Processing Your Order....\n");

            try
            {
                PizzaOrderResponse response = await mediator.SendAsync(request);

                Console.Out.Write(
                    "The bill is " + response.Bill + " EUR, and it will be delivered to " + request.Address + " at " + response.DeliveryTime);
            }
            catch (ArgumentNullException)
            {
                Console.Out.Write("The order cannot be processed");
            }

            Console.ReadKey();
        }
    }
}