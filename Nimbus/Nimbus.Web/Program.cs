using FluentAssertions.Common;
using Microsoft.Extensions.DependencyInjection;
using Nimbus;
using Nimbus.Shared.Logic;
using Nimbus.Shared.Repositories;
using Nimbus.Shared.Services;
using Nimbus.Web.Components;
using Nimbus.Web.Services;
using Microsoft.Extensions.Configuration;
using Nimbus.Shared;
using Nimbus.Shared.Controllers;
using Microsoft.AspNetCore.StaticFiles; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddSingleton<IFormFactor, FormFactor>()
.AddSingleton<IAddressRepository, AddressRepository>()
.AddSingleton<ITruckRepository, TruckRepository>()
.AddSingleton<IRouteRepository, RouteRepository>()
.AddSingleton<SelectionService>();

builder.Services.AddControllers();

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); 
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(Nimbus.Shared._Imports).Assembly,
        typeof(Nimbus.Web.Client._Imports).Assembly);

app.Run();
