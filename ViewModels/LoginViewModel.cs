using BusinessPortal.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace BusinessPortal.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;

        [ObservableProperty]
        private string _email = string.Empty;

        [ObservableProperty]
        private string _password = string.Empty;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
            Title = "Login";
        }

        [RelayCommand]
        private async Task Login()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter both email and password.", "OK");
                return;
            }

            var user = await _authService.LoginAsync(Email, Password);

            if (user != null)
            {
                // On successful login, navigate to the main application shell.
                // The "//" prefix makes the route absolute, clearing any navigation history.
                await Shell.Current.GoToAsync("//Main");
            }
            else
            {
                await Shell.Current.DisplayAlert("Login Failed", "Invalid email or password.", "OK");
            }
        }
    }
}

