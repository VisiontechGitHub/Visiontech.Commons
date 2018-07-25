using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace VisiontechCommons
{
    public static class Container
    {

        public static readonly IServiceCollection services = new ServiceCollection();

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
