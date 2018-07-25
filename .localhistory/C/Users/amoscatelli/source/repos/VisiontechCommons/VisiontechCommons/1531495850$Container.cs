using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisiontechCommons
{
    public static class Container
    {

        static readonly IServiceCollection services = new ServiceCollection();

        public static IServiceProvider Container { get{ }; private set; }

    }
}
