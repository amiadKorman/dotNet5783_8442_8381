using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using PL.Admin.MenuWindowMenager;
using PL.Products;
using PL.Admin;


namespace PL.Admin.MenuWindowMenager
{
    /// <summary>
    /// Interaction logic for ProductsWindowMenager.xaml
    /// </summary>
    public partial class ProductsWindowMenager : Window
    {
        private readonly BlApi.IBl bl = BlApi.Factory.Get();

        public ProductsWindowMenager()
        {
            InitializeComponent();

            membersDataGrid.ItemsSource = bl.Product.GetList();
            
        }

       


        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
      

        private void CartChoise(object sender, RoutedEventArgs e)
        {
            new CartWindowMenager().Show();
            this.Close();
        }

        private void Add_product(object sender, RoutedEventArgs e)
        {
            new ProductWindow(bl).Show();
            



        }

        private void CustomerChoise(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Edit_product(object sender, RoutedEventArgs e)
        {
            new ProductWindow(bl).Show();
            

        }

        private void Delete_product(object sender, RoutedEventArgs e)
        {
           
        }


        private void ProductsListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) => new ProductWindow(bl, ((BO.ProductForList)ProductsListView.SelectedItem).ID).Show();

    }


}
