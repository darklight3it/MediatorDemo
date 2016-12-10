namespace MediatorTest
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FluentAssertions;

    using MediatorDemo.BusinessLogic.Handlers;
    using MediatorDemo.BusinessLogic.Requests;
    using MediatorDemo.BusinessLogic.Responses;

    using MediatR;

    using NUnit.Framework;

    using Rhino.Mocks;

    [TestFixture]
    public class PizzaRequestHandlerTest
    {
        private IMediator mediator { get; set; }

        private PizzaRequestHandler sut { get; set; }

        [SetUp]
        public void SetUp()
        {
            StubDependencies();

            sut = new PizzaRequestHandler();
        }

        [Test]
        public async Task Should_Be_Returning_CorrecteResponse()
        {
            // Arrange
            var order = new Dictionary<PizzaType, int> { { PizzaType.Margherita, 1 }, { PizzaType.Capricciosa, 2 } };
            PizzaOrderRequest pizzaOrderRequest = MakePizzaOrderRequest("Address", order);

            // Act
            PizzaOrderResponse response = await sut.Handle(pizzaOrderRequest);

            // Assert
            response.Bill.Should().Be(21);
        }

        [Test]
        public void Should_Throw_ArgumentNullException_When_Order_Or_Address_Are_Null()
        {
            // Arrange
            PizzaOrderRequest pizzaOrderRequest = MakePizzaOrderRequest(null, null);

            // Assert
            Assert.Throws<ArgumentNullException>(() => sut.Handle(pizzaOrderRequest));
        }

        #region Private Members

        private static PizzaOrderRequest MakePizzaOrderRequest(string address, Dictionary<PizzaType, int> dictionary)
        {
            return new PizzaOrderRequest { Address = address, Order = dictionary };
        }

        private void StubDependencies()
        {
            mediator = MockRepository.GenerateMock<IMediator>();
        }

        #endregion
    }
}