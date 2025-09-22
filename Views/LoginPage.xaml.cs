using BusinessPortal.ViewModels;

namespace BusinessPortal.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();

        // This is the crucial step that connects the View to the ViewModel.
        BindingContext = viewModel;
    }
}

