namespace MediatorDemo.Installers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.NetworkInformation;

    using BusinessLogic.Handlers;
    using BusinessLogic.Requests;
    using BusinessLogic.Responses;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Controllers;

    using MediatR;

    internal class ApplicationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMediator>().ImplementedBy<Mediator>());
            container.Register(Classes.FromAssemblyContaining<Ping>().Pick().WithServiceAllInterfaces());
            container.Register(Component.For<TextWriter>().Instance(Console.Out));

            container.Kernel.AddHandlersFilter(new ContravariantFilter());
            container.Register(
                Component.For<SingleInstanceFactory>().UsingFactoryMethod<SingleInstanceFactory>(k => t => k.Resolve(t)));

            container.Register(
                Component.For<MultiInstanceFactory>()
                    .UsingFactoryMethod<MultiInstanceFactory>(k => t => (IEnumerable<object>)k.ResolveAll(t)));

            container.Register(Component.For<DemoController>());


            container.Register(
                Component.For<IAsyncRequestHandler<PizzaOrderRequest, PizzaOrderResponse>>()
                    .ImplementedBy<PizzaRequestHandler>());


            container.Register(
                Component.For<IRequestHandler<PizzaOrderCancellationRequest, Unit>>()
                    .ImplementedBy<PizzaOrderCancellationHandler>());
        }
    }
}