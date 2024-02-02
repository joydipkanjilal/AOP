using Autofac.Challenge.MethodDuration.Demo;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
var concurrencyPolicy = "Concurrency";
builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.RejectionStatusCode = 429;

    rateLimiterOptions.AddConcurrencyLimiter(policyName: concurrencyPolicy, options =>
    {
        options.PermitLimit = 1;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 1;
    });
});

var app = ContainerHelper.BuildContainer(builder);

app.MapGet("/", () => "Hello World!");

//if(!Constants.Flag)
//{
    app.MapGet("/getemployees", (IDataRepository dataRepository/*, CancellationToken token*/) =>
    {
        //Task.Delay(100, token);
        return dataRepository.GetEmployees();
    }).RequireRateLimiting(concurrencyPolicy);

    //Constants.Flag = true;
//}

app.Run();