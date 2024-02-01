
using Autofac;
using Autofac.Challenge.MethodExecutionDuration.Demo;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
//    .ConfigureContainer<ContainerBuilder>(builder =>
//    {
//        builder.RegisterModule(new AutofacModule());
//    });
// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddScoped<IDataRepository, DataRepository>();

var app = ContainerHelper.BuildContainer(builder);

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
