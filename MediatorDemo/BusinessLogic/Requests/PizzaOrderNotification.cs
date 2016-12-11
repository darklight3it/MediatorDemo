namespace MediatorDemo.BusinessLogic.Requests
{
    using System;

    using MediatR;

    public class PizzaOrderNotification : IAsyncNotification
    {
        public Guid OrderId { get; set; }
    }
}