using BusinessPortal.Views;

namespace BusinessPortal;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    // This method is the correct, modern way to set the startup page.
    // It runs after the dependency injection system is ready.
    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = base.CreateWindow(activationState);

        // This line reliably gets our registered LoginPage and sets it as the startup page.
        // This is the line that will fix the runtime crash.
        window.Page = IPlatformApplication.Current!.Services.GetRequiredService<LoginPage>();

        return window;
    }
}

