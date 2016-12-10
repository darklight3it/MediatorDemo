namespace MediatorDemo.BusinessLogic.Requests
{
    using System.Collections.Generic;

    using MediatR;

    using Responses;

    public class PizzaOrderRequest: IAsyncRequest<PizzaOrderResponse>
    {
        public Dictionary<PizzaType, int> Order { get; set; }

        public string Address { get; set; }
    }

    public enum PizzaType
    {
        Margherita,
        Diavola,
        Patatine,
        Capricciosa,
        Cotto,
        Crudo
    }
}