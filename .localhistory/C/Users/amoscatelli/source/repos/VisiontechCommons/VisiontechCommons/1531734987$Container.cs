using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisiontechCommons
{
    public static class Container
    {

        public static readonly IServiceCollection services = new ServiceCollection();

        private static IServiceProvider serviceProvider;

        public static IServiceProvider ServiceProvider {
            get {
                return services.BuildServiceProvider();
            }
            private set { }
        }

    }
}
