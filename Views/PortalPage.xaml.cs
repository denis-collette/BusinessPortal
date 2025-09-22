using BusinessPortal.ViewModels;

namespace BusinessPortal.Views;

public partial class PortalPage : ContentPage
{
    public PortalPage(PortalViewModel viewModel)
    {
        InitializeComponent();
        // Set the binding context to the view model provided by dependency injection
        BindingContext = viewModel;
    }
}

