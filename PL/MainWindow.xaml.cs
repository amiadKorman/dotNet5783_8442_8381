using BlApi;
using System.Windows;
using PL.Admin.AdminSingInWindow;

namespace PL;

/// <summary>
/// This is the MainWindow class of the project
/// Here has two diffrent Kind of users
/// Adnisisntrator and Customer
/// 
/// Administrator can see all the Products orders and the customers he can edit and delete diteles
/// 
/// The user can see all the products add to cart and buy diffrent products
/// </summary>
public partial class MainWindow : Window
{
    private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;
    /// <summary>
    /// Uppload the window
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


