using System.Globalization;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Samples.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _lastMarkupValue = "Click a button to show the CommandParameter CLR type and value.";

    [RelayCommand]
    private void ShowMarkupValue(object? value)
    {
        LastMarkupValue = value is null
            ? "(null)"
            : $"{value.GetType().FullName}: {Convert.ToString(value, CultureInfo.InvariantCulture)}";
    }
}
