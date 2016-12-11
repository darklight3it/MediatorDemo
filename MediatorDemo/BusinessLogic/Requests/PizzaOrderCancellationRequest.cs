namespace MediatorDemo.BusinessLogic.Requests
{
    using System;

    using MediatR;

    public class PizzaOrderCancellationRequest : IRequest<Unit>
    {
        public Guid OrderId { get; set; }
    }
}