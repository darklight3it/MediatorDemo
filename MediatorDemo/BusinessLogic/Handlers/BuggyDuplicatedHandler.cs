namespace MediatorDemo.BusinessLogic.Handlers
{
    using System;
    using System.Threading.Tasks;

    using MediatR;

    using Requests;

    using Responses;

    public class BuggyDuplicatedHandler : IAsyncRequestHandler<PizzaOrderRequest, PizzaOrderResponse>
    {
        public Task<PizzaOrderResponse> Handle(PizzaOrderRequest message)
        {
            throw new NotImplementedException();
        }
    }
}