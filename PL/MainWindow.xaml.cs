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
    /// Move to product list window
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ShowProductButton_Click(object sender, RoutedEventArgs e)
    {
        new ProductListWindow().Show();
        Close();
    }
}
