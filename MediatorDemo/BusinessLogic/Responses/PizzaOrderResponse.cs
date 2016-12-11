namespace MediatorDemo.BusinessLogic.Responses
{
    using System;

    public class PizzaOrderResponse
    {
        public Guid OrderId { get; set; }

        public DateTime DeliveryTime { get; set; }

        public double Bill { get; set; }
    }
}