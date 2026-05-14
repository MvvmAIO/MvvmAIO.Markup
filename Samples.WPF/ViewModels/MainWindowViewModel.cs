using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System;
using System.Globalization;
using System.Windows;

namespace Samples.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [RelayCommand]
    private void ShowMarkupValue(object value)
    {
        var text = value is null
            ? "(null)"
            : $"{value.GetType().FullName}: {Convert.ToString(value, CultureInfo.InvariantCulture)}";

        MessageBox.Show(text, "MvvmAIO.Markup", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
