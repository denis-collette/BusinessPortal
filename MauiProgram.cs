using BusinessPortal.Services;
using BusinessPortal.ViewModels;
using BusinessPortal.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace BusinessPortal;

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

        // Add AppSettings
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("BusinessPortal.appsettings.json");
        if (stream != null)
        {
            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();
            builder.Configuration.AddConfiguration(config);
        }

#if DEBUG
        builder.Logging.AddDebug();
#endif
        // Register Services
        builder.Services.AddSingleton<IAuthService, MockAuthService>();

        // Register Views and ViewModels
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<PortalPage>();
        builder.Services.AddTransient<PortalViewModel>();

        // Add registrations for our new pages
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<ProfileViewModel>();

        builder.Services.AddTransient<SuperAdminPage>();
        builder.Services.AddTransient<SuperAdminViewModel>();


        return builder.Build();
    }
}

