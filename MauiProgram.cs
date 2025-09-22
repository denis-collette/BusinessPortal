using BusinessPortal.Services; // Add this using statement
using Microsoft.Extensions.Configuration;
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

        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("BusinessPortal.appsettings.json");

        if (stream != null)
        {
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder.Configuration.AddConfiguration(config);
        }

        // --- START: Dependency Injection Registration ---

        // Register the MockAuthService as a Singleton.
        // The app will create one instance of MockAuthService and share it.
        // When a class asks for IAuthService, this instance will be provided.
        builder.Services.AddSingleton<IAuthService, MockAuthService>();

        // --- END: Dependency Injection Registration ---


#if DEBUG
        // We can add other services here in the future
#endif

        return builder.Build();
    }
}

