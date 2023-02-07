using BO;
using System;
using System.Windows;

namespace PL.Products;

/// <summary>
/// Interaction logic for ProductWindow.xaml
/// </summary>
public partial class ProductWindow : Window
{
    private readonly BlApi.IBl bl;

    public ProductWindow(BlApi.IBl bl)
    {
        this.bl = bl;
        InitializeComponent();
        CategoryComboBox.ItemsSource = Enum.GetValues(typeof(BO.Category));
        // Hide update buttom
        AddButton.Visibility = Visibility.Visible;
        UpdateButton.Visibility = Visibility.Collapsed;

    }

    public ProductWindow(BlApi.IBl bl, int ID) : this(bl)
    {
        InitializeComponent();
        CategoryComboBox.ItemsSource = Enum.GetValues(typeof(BO.Category));
        // Hide add button
        UpdateButton.Visibility = Visibility.Visible;
        AddButton.Visibility = Visibility.Collapsed;

        // disable the option to edit ID Text Box
        IdTextBox.IsEnabled = false;

        Product product1 = bl.Product.Get(ID);

        IdTextBox.Text = product1.ID.ToString();
        CategoryComboBox.SelectedItem = product1.Category;
        NameTextBox.Text = product1.Name;
        PriceTextBox.Text = product1.Price.ToString();
        InStockTextBox.Text = product1.InStock.ToString();
    }

    public ProductWindow()
    {
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Product UserProduct = BuildProduct();
            bl.Product.Add(UserProduct);
            MessageBox.Show("The product successfully added");
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Product UserProduct = BuildProduct();
            bl.Product.Update(UserProduct);
            MessageBox.Show("The product successfully updated");
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private Product BuildProduct()
    {
        Product UserProduct = new();

        int input;
        if (int.TryParse(IdTextBox.Text, out input))
        {
            UserProduct.ID = input;
        }
        else
        {
            throw new Exception("ID must be a number");
        }

        if (CategoryComboBox.SelectedItem != null)
        {
            UserProduct.Category = (BO.Category)CategoryComboBox.SelectedItem;
        }
        else
        {
            throw new Exception("Category must be selected");
        }

        if (NameTextBox.Text != "")
        {
            UserProduct.Name = NameTextBox.Text;
        }
        else
        {
            throw new Exception("Name can't be empty");
        }

        if (int.TryParse(PriceTextBox.Text, out input))
        {
            UserProduct.Price = input;
        }
        else
        {
            throw new Exception("Price must be a number");
        }

        if (int.TryParse(InStockTextBox.Text, out input))
        {
            UserProduct.InStock = input;
        }
        else
        {
            throw new Exception("In Stock must be a number");
        }

        return UserProduct;
    }
}
