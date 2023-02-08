using BlApi;
using System.Windows;
using PL.Admin.AdminSingInWindow;

namespace PL;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;
    /// <summary>
    /// Constructor
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Open the window of the menager
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void logIn_menager(object sender, RoutedEventArgs e)
    {
        new AdminSingInWindow().Show();
        Close();
    }

    /// <summary>
    /// Open the window of the Customer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void logIn_customer(object sender, RoutedEventArgs e)
    {
        new CustomerSingInWindow().Show();
        Close();

    }

    private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {

    }

    private void Image_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {

    }
}


