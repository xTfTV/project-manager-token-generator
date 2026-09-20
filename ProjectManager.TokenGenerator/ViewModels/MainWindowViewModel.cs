using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProjectManager.TokenGenerator.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string emailAddress = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [ObservableProperty]
    private string token = string.Empty;

    [ObservableProperty] 
    private string statusMessage = string.Empty;

    [RelayCommand]
    private void GenerateToken()
    {
        StatusMessage = "Token generation not wired yet";
    }

    [RelayCommand]
    private void CopyToken()
    {
        StatusMessage = "Copy token not wired yet";
    }
}
