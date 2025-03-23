using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nimbus.Services;
using Nimbus.Shared;
using Nimbus.Shared.Logic;
using Nimbus.Shared.Repositories;


//using Nimbus.Web.Services;
using Nimbus.Shared.Services;
using System.Security.Cryptography.X509Certificates;

namespace Nimbus
{
    
public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddDbContext<DataContext>();

            builder.Services.AddSingleton<IFormFactor, FormFactor>()
            .AddSingleton<IAddressRepository, AddressRepository>()
            .AddSingleton<IRouteRepository, RouteRepository>()
            .AddSingleton<ITruckRepository, TruckRepository>()
            .AddSingleton<IGeoLocationService, GeoLocationService>()
            .AddSingleton<SelectionService>()
            .AddMauiBlazorWebView();

            //builder.Services.AddControllers();


            using (var scope = builder.Build().Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                dbContext.Database.EnsureCreated();
                dbContext.Database.Migrate();
            }

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
