using BusinessPortal.Models;
using BusinessPortal.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace BusinessPortal.ViewModels
{
    public partial class PortalViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;

        [ObservableProperty]
        private User? _currentUser;

        public PortalViewModel(IAuthService authService)
        {
            Title = "Portal";
            _authService = authService;
            // We will call a method to load the user info
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            CurrentUser = await _authService.GetCurrentUserAsync();
        }
    }
}

