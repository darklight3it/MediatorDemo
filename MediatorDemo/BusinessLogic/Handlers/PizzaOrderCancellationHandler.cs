namespace MediatorDemo.BusinessLogic.Handlers
{
    using System;

    using MediatR;

    using Requests;

    public class PizzaOrderCancellationHandler : IRequestHandler<PizzaOrderCancellationRequest, Unit>
    {
        public Unit Handle(PizzaOrderCancellationRequest message)
        {
            if (message.OrderId == null) throw new ArgumentNullException();

            return new Unit();
        }
    }
}