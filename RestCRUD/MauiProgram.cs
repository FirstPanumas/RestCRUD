using Microsoft.Extensions.Logging;
using RestCRUD.Repositories;
using RestCRUD.Services;
namespace RestCRUD
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IPlatformHandler, PlatformHandler>();
            builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
            builder.Services.AddSingleton<ICustomerService, CustomerService>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<CustomerDetail>();

            return builder.Build(); 

            

        }
    }
}
