using BlApi;
using PL.Products;
using System.Windows;

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
        new Admin.MenuWindowMenager().Show();
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
}


