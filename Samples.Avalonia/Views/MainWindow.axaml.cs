using Avalonia.Controls;

using Samples.ViewModels;

namespace Samples.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}
