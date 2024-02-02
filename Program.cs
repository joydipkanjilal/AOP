using Autofac.Challenge.MethodDuration.Demo;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddRateLimiter(_ => _
    .AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit = 1;
        options.Window = TimeSpan.FromSeconds(15);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 1;

    }));

//var concurrencyPolicy = "Concurrency";
//builder.Services.AddRateLimiter(rateLimiterOptions =>
//{
//    rateLimiterOptions.RejectionStatusCode = 429;

//    rateLimiterOptions.AddConcurrencyLimiter(policyName: concurrencyPolicy, options =>
//    {
//        options.PermitLimit = 1;
//        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//        options.QueueLimit = 1;
//    });
//});

//builder.Services.AddRateLimiter(options => {
//    options.RejectionStatusCode = 429;
//    options.AddTokenBucketLimiter(policyName: "token", options => {
//        options.TokenLimit = 1;
//        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//        options.QueueLimit = 1;
//        options.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
//        options.TokensPerPeriod = 1;
//        options.AutoReplenishment = true;
//    });
//});

var app = ContainerHelper.BuildContainer(builder);

//app.MapGet("/", () => "Hello World!");


//if(!Constants.Flag)
//{
    app.MapGet("/getemployees", (IDataRepository dataRepository/*, CancellationToken token*/) =>
    {
        //Task.Delay(100, token);
        return dataRepository.GetEmployees();
    }).RequireRateLimiting("fixed");

//Constants.Flag = true;
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();