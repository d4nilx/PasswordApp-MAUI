using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Security.Cryptography;

namespace MauiApp1.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private int length = 5;
    
    [ObservableProperty] private string title = "Password Generator";
    
    [ObservableProperty] private string readyPassword  = "Your password" ;

    [RelayCommand]
    private void GeneratePassword()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*|/><~.,;:[]{}£§+-=";
        
        char[] result = new char[Length];

        for (int i = 0; i < result.Length; i++)
        {
            int randomIndex = RandomNumberGenerator.GetInt32(chars.Length);
            result[i] = chars[randomIndex];
        }
        ReadyPassword = new string(result);
    }

    [RelayCommand]
    private async Task CopyPassword()
    {
        if (!string.IsNullOrEmpty(ReadyPassword))
        {
            await Clipboard.Default.SetTextAsync(ReadyPassword);
            await Shell.Current.DisplayAlert("Ready", "Password copied to clipboard", "OK");
        }
    }
}