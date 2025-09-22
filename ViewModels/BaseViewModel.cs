using CommunityToolkit.Mvvm.ComponentModel;

namespace BusinessPortal.ViewModels
{
    // Inherit from ObservableObject to enable MVVM Toolkit features.
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string _title = string.Empty;
    }
}

