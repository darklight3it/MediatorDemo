namespace MediatorDemo.BusinessLogic.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Requests;

    public class PizzaOrderNotificationSmsHandler : IAsyncNotificationHandler<PizzaOrderNotification>
    {
        public Task Handle(PizzaOrderNotification notification)
        {
            Thread.Sleep(5000);

            Console.Out.Write("An SMS was sent for the order " + notification.OrderId + "\n");

            return Task.FromResult(0);
        }
    }
}