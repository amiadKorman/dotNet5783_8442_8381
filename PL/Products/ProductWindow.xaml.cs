using BlApi;
using BO;
using System;
using System.Windows;

namespace PL.Products;

/// <summary>
/// Interaction logic for ProductWindow.xaml
/// </summary>
public partial class ProductWindow : Window
{
    private IBl bl;

    public ProductWindow(IBl bl)
    {
        this.bl = bl;
        InitializeComponent();
        CategoryComboBox.ItemsSource = Enum.GetValues(typeof(BO.Category));
        // Hide update buttom
        AddButton.Visibility = Visibility.Visible;
        UpdateButton.Visibility = Visibility.Collapsed;
    }

    public ProductWindow(IBl bl, int ID) : this(bl)
    {
        this.bl = bl;
        InitializeComponent();
        CategoryComboBox.ItemsSource = Enum.GetValues(typeof(BO.Category));
        // Hide add button
        UpdateButton.Visibility = Visibility.Visible;
        AddButton.Visibility = Visibility.Collapsed;

        Product product1 = bl.Product.Get(ID);

        IdTextBox.Text = product1.ID.ToString();
        CategoryComboBox.SelectedItem = product1.Category;
        NameTextBox.Text = product1.Name;
        PriceTextBox.Text = product1.Price.ToString();
        InStockTextBox.Text = product1.InStock.ToString();
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        Product UserProduct = BuildProduct();

        try
        {
            bl.Product.Add(UserProduct);
            MessageBox.Show("The product successfully added");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        Close();
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {

        Product UserProduct = BuildProduct();
        
        try
        {
            bl.Product.Update(UserProduct);
            MessageBox.Show("The product successfully updated");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        Close();
    }

    private Product BuildProduct()
    {
        Product UserProduct = new();

        int userVal;

        int.TryParse(IdTextBox.Text, out userVal);
        UserProduct.ID = userVal;

        UserProduct.Category = (Category?)CategoryComboBox.SelectedItem;

        UserProduct.Name = NameTextBox.Text;

        int.TryParse(PriceTextBox.Text, out userVal);
        UserProduct.Price = userVal;

        int.TryParse(InStockTextBox.Text, out userVal);
        UserProduct.InStock = userVal;

        return UserProduct;
    }
}
