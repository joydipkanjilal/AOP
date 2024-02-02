using Autofac.Challenge.MethodDuration.Demo;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers();

//builder.Services.AddRateLimiter(_ => _
//    .AddFixedWindowLimiter(policyName: "fixed", options =>
//    {
//        options.PermitLimit = 1;
//        options.Window = TimeSpan.FromSeconds(30);
//        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//        options.QueueLimit = 1;
//    }));

//var concurrencyPolicy = "concurrency";
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

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddTokenBucketLimiter("token", options =>
    {
        options.TokenLimit = 1;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 1;
        options.ReplenishmentPeriod = TimeSpan.FromSeconds(30);
        options.TokensPerPeriod = 1;
        options.AutoReplenishment = true;
    });
});


//builder.Services.AddRateLimiter(options =>
//{
//    options.RejectionStatusCode = 429;
//    options.AddTokenBucketLimiter(policyName: "token", options =>
//    {
//        options.TokenLimit = 1;
//        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//        options.QueueLimit = 1;
//        options.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
//        options.TokensPerPeriod = 1;
//        options.AutoReplenishment = true;
//    });
//});

var app = ContainerHelper.BuildContainer(builder);
//app.UseRateLimiter();
//app.MapGet("/", () => "Hello World!");


//if(!Constants.Flag)
//{
    app.MapGet("/getemployees", (IDataRepository dataRepository/*, CancellationToken token*/) =>
    {
        //Task.Delay(1000, token);
        return dataRepository.GetEmployees();
    }).RequireRateLimiting("token");

//Constants.Flag = true;
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();