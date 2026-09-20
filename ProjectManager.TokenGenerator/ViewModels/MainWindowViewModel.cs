using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.TokenGenerator.Services;

namespace ProjectManager.TokenGenerator.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly TokenApiService _tokenApiService;

    public MainWindowViewModel()
    {
        _tokenApiService = new TokenApiService("https://localhost:7007");
    }

    [ObservableProperty]
    private string emailAddress = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [ObservableProperty]
    private string token = string.Empty;

    [ObservableProperty] 
    private string statusMessage = string.Empty;

    [RelayCommand]
    private async Task GenerateTokenAsync()
    {
        try
        {
            StatusMessage = "Generating Token...";

            var generatedToken = await _tokenApiService.GenerateTokenAsync(EmailAddress, Password);

            if (string.IsNullOrWhiteSpace(generatedToken))
            {
                Token = string.Empty;
                StatusMessage = "Login Failed";
                return;
            }

            Token = generatedToken;
            StatusMessage = "Generated the token successfully";   
        }
        catch (Exception ex)
        {
            Token = string.Empty;
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    [RelayCommand]
    private void CopyToken()
    {
        StatusMessage = "Copy token not wired yet";
    }
}
