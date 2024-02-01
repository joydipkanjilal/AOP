using Autofac.Challenge.MethodDuration.Demo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = ContainerHelper.BuildContainer(builder);

app.MapGet("/", () => "Hello World!");

app.MapGet("/getemployees", (IDataRepository dataRepository) =>
{
    return dataRepository.GetEmployees();
});

app.Run();