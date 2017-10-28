﻿using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DarkXaHTeP.CommandLine
{
    public class ConfigureServicesBuilder
    {
        public ConfigureServicesBuilder(MethodInfo configureServices)
        {
            MethodInfo = configureServices;
        }

        public MethodInfo MethodInfo { get; }

        public Action<IServiceCollection> Build(object instance) => builder => Invoke(instance, builder);

        private void Invoke(object instance, IServiceCollection services)
        {
            if (MethodInfo == null)
            {
                return;
            }

            var parameters = MethodInfo.GetParameters();
            if (parameters.Length > 1 ||
                parameters.Any(p => p.ParameterType != typeof(IServiceCollection)))
            {
                throw new InvalidOperationException("The ConfigureServices method must either be parameterless or take only one parameter of type IServiceCollection.");
            }

            var arguments = new object[MethodInfo.GetParameters().Length];

            if (parameters.Length > 0)
            {
                arguments[0] = services;
            }

            MethodInfo.Invoke(instance, arguments);
        }
    }
}