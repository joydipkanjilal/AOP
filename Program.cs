using Autofac.Demo;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container
builder.Services.AddMemoryCache();

builder.Services.AddControllersWithViews();

//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
var app = ContainerHelper.BuildContainer(builder);

//var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();