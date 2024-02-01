using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;

namespace Autofac.Challenge.MethodExecutionDuration.Demo
{
    public class ContainerHelper
    {
        public static WebApplication BuildContainer(WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).

                ConfigureContainer<ContainerBuilder>(builder =>
                {                    
                    builder.Register(i => new MethodDurationInterceptor(Console.Out));
                    builder.RegisterType<DataRepository>()
                    .As<IDataRepository>()
                    .InstancePerDependency()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(MethodDurationInterceptor));
                });

            return builder.Build();
        }
    }

    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<DataRepository>()
                .As<IDataRepository>()
                .InstancePerDependency()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(MethodDurationInterceptor));

            builder.Register(c => new MethodDurationInterceptor(Console.Out));
        }
    }
}