namespace MediatorDemo.Installers
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Castle.MicroKernel;

    public class ContravariantFilter : IHandlersFilter
    {
        public bool HasOpinionAbout(Type service)
        {
            if (!service.IsGenericType) return false;

            Type genericType = service.GetGenericTypeDefinition();
            Type[] genericArguments = genericType.GetGenericArguments();
            return genericArguments.Count() == 1
                   && genericArguments.Single()
                          .GenericParameterAttributes.HasFlag(GenericParameterAttributes.Contravariant);
        }

        public IHandler[] SelectHandlers(Type service, IHandler[] handlers)
        {
            return handlers;
        }
    }
}