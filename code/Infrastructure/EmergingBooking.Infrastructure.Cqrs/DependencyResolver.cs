using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace EmergingBooking.Infrastructure.Cqrs
{
    internal class DependencyResolver
    {
        private readonly IServiceProvider serviceProvider;

        public DependencyResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TDependencyType Resolve<TDependencyType>()
        {
            return serviceProvider.GetRequiredService<TDependencyType>();
        }

        public IEnumerable<TDependencyType> ResolveAll<TDependencyType>()
        {
            return serviceProvider.GetServices<TDependencyType>();
        }
    }
}