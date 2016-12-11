namespace MediatorDemo.BusinessLogic.Handlers
{
    using System;
    using System.Threading.Tasks;

    using MediatR;

    using Requests;

    using Responses;

    public class PizzaOrderCancellationHandler : IRequestHandler<PizzaOrderCancellationRequest, Unit>
    {
        public Unit Handle(PizzaOrderCancellationRequest message)
        {
            if (message.OrderId == null) throw new ArgumentNullException();

            return new Unit();
        }
    }
}