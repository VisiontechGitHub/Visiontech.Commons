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

        public static IServiceProvider ServiceProvider {
            get {
                return services.BuildServiceProvider(); ;
            }
            private set { }
        }

    }
}
