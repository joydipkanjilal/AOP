using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;

namespace Autofac.Demo
{
    public class ContainerHelper
    {
        public static WebApplication BuildContainer(WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).
                ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterType<MemoryCacheInterceptor>();
                    builder.RegisterType<ProductRepository>()
                    .As<IProductRepository>()
                    .InstancePerDependency()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(MemoryCacheInterceptor));
                });

            return builder.Build();
        }
    }
}
