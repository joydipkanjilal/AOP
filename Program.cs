using Autofac.Challenge.MethodDuration.Demo;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = 429;
    options.AddTokenBucketLimiter(policyName: "token", options =>
    {
        options.TokenLimit = 1;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 0;
        options.ReplenishmentPeriod = TimeSpan.FromSeconds(3);
        options.TokensPerPeriod = 1;
        options.AutoReplenishment = false;
    });
});

var app = ContainerHelper.BuildContainer(builder);
app.UseRateLimiter();

app.MapGet("/getemployees", (IDataRepository dataRepository/*, CancellationToken token*/) =>
{
    return dataRepository.GetEmployees();
}).RequireRateLimiting("token");

app.Run();