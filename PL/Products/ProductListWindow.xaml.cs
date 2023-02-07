using System;
using System.Windows;
using System.Windows.Controls;

namespace PL.Products;

/// <summary>
/// Interaction logic for ProductListWindow.xaml
/// </summary>
public partial class ProductListWindow : Window
{
    private readonly BlApi.IBl bl = BlApi.Factory.Get();

    public ProductListWindow()
    {
        InitializeComponent();

        ProductsListView.ItemsSource = bl.Product.GetList();

        CategorySelector.Items.Add("All");
        foreach (var category in Enum.GetValues(typeof(BO.Category)))
        {
            CategorySelector.Items.Add(category);
        }

        CategorySelector.SelectedIndex = 0;
    }

    private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (CategorySelector.SelectedItem == CategorySelector.Items[0])
        {
            ProductsListView.ItemsSource = bl.Product.GetList();
        }
        else
        {
            ProductsListView.ItemsSource = bl.Product.GetList(p => p?.Category == (BO.Category)CategorySelector.SelectedItem);
        }
    }

    private void AddButton_Click(object sender, RoutedEventArgs e) => new ProductWindow(bl).Show();

    private void ProductsListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) => new ProductWindow(bl, ((BO.ProductForList)ProductsListView.SelectedItem).ID).Show();

    private void ProductsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}
