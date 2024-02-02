﻿using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;

namespace Autofac.Challenge.MethodDuration.Demo
{
    public class ContainerHelper
    {
        public static WebApplication BuildContainer(WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).

                ConfigureContainer<ContainerBuilder>(builder =>
                {
                    //builder.Register(i => new MethodDurationInterceptor(Console.Out));
                    builder.RegisterType<MethodDurationInterceptor>();
                    builder.RegisterType<DataRepository>()
                    .As<IDataRepository>()
                    .InstancePerLifetimeScope()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(MethodDurationInterceptor));
                });

            return builder.Build();
        }
    }
}