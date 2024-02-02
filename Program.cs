using Autofac.Challenge.MethodDuration.Demo;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRateLimiter(_ => _
    .AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit = 1;
        options.Window = TimeSpan.FromSeconds(10);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 1;
    }));


var app = ContainerHelper.BuildContainer(builder);
app.UseRateLimiter();

app.MapGet("/", () => "Hello World!");

//if(!Constants.Flag)
//{
    app.MapGet("/getemployees", (IDataRepository dataRepository) =>
    {
        return dataRepository.GetEmployees();
    }).RequireRateLimiting("fixed");

    Constants.Flag = true;
//}

app.Run();