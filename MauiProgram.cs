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

        // --- START: Configuration Loading ---
        // This code reads the appsettings.json file and makes the settings
        // available throughout the application.
        var assembly = Assembly.GetExecutingAssembly();
        // The resource name must match YourProjectName.appsettings.json
        using var stream = assembly.GetManifestResourceStream("BusinessPortal.appsettings.json");

        if (stream != null)
        {
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder.Configuration.AddConfiguration(config);
        }
        // --- END: Configuration Loading ---


#if DEBUG
        // In a real app, you would register your services here for dependency injection.
        // e.g., builder.Services.AddSingleton<IMyApiService, MyApiService>();
#endif

        return builder.Build();
    }
}

