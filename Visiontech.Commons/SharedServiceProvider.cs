﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace VisiontechCommons
{
    public static class SharedServiceProvider
    {

        public static readonly IServiceCollection Services = new ServiceCollection();

        private static IServiceProvider serviceProvider;

        public static IServiceProvider ServiceProvider {
            get {
                if (serviceProvider is null)
                {
                    serviceProvider = Services.BuildServiceProvider();
                }
                return serviceProvider;
            }
            private set { }
        }

        public static void Reset()
        {
            serviceProvider = null;
        }

    }
}
