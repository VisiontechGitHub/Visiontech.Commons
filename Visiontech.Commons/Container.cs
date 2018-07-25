using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace VisiontechCommons
{
    public static class Container
    {

        private static readonly IServiceCollection services = new ServiceCollection();

        public static IServiceCollection Services
        {
            get
            {
                if (!(serviceProvider is null))
                {
                    throw new Exception("ServiceProvider already provided");
                }
                return services;
            }
            private set { }
        }

        private static IServiceProvider serviceProvider;

        public static IServiceProvider ServiceProvider {
            get {
                if (serviceProvider is null)
                {
                    serviceProvider = services.BuildServiceProvider();
                }
                return serviceProvider;
            }
            private set { }
        }

    }
}
