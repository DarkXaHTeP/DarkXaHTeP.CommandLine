// This file is a modified version of ConventionBasedStartup.cs from aspnet/Hosting GitHub repository
// located at https://github.com/aspnet/Hosting/blob/rel/2.0.0/src/Microsoft.AspNetCore.Hosting/Startup/ConventionBasedStartup.cs
// and licensed under the Apache License, Version 2.0
// Copyright (c) .NET Foundation. All rights reserved.

// Modification notice: Changed namespace and "ConfigureServices" method signature

using System;
using System.Reflection;
using System.Runtime.ExceptionServices;
using Microsoft.Extensions.DependencyInjection;

namespace DarkXaHTeP.CommandLine.Internal.Startup
{
    internal class ConventionBasedStartup: IStartup
    {
        private readonly StartupMethods _methods;

        public ConventionBasedStartup(StartupMethods methods)
        {
            _methods = methods;
        }
        
        public void Configure(IApplicationBuilder app)
        {
            try
            {
                _methods.ConfigureDelegate(app);
            }
            catch (Exception ex)
            {
                if (ex is TargetInvocationException)
                {
                    ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                }

                throw;
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_methods.ConfigureServicesDelegate == null)
            {
                return;
            }
            
            try
            {
                _methods.ConfigureServicesDelegate(services);
            }
            catch (Exception ex)
            {
                if (ex is TargetInvocationException)
                {
                    ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                }

                throw;
            }
        }
    }
}