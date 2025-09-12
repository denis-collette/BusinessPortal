namespace BusinessPortal;

// This is the C# code-behind for App.xaml. It's the application's entry point.
public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // The Shell is the main navigation container for the app.
        // It's like the root app component with a router outlet in Angular.
        MainPage = new AppShell();
    }
}
