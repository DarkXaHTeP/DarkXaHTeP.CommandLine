// This file is a modified version of StartupMethods.cs.cs from aspnet/Hosting GitHub repository
// located at https://github.com/aspnet/Hosting/blob/rel/2.0.0/src/Microsoft.AspNetCore.Hosting/Internal/StartupMethods.cs
// and licensed under the Apache License, Version 2.0
// Copyright (c) .NET Foundation. All rights reserved.

// Modification notice: Changed namespace and updated signature of configureServices delegate

using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace DarkXaHTeP.CommandLine.Internal.Startup
{
    internal class StartupMethods
    {
        public StartupMethods(object instance, Action<IApplicationBuilder> configure, Action<IServiceCollection> configureServices)
        {
            Debug.Assert(configure != null);
            Debug.Assert(configureServices != null);

            StartupInstance = instance;
            ConfigureDelegate = configure;
            ConfigureServicesDelegate = configureServices;
        }

        public object StartupInstance { get; }
        public Action<IServiceCollection> ConfigureServicesDelegate { get; }
        public Action<IApplicationBuilder> ConfigureDelegate { get; }
    }
}