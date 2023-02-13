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


namespace PL.Admin.MenuWindowMenager
{
    /// <summary>
    /// Interaction logic for CartWindowMenager.xaml
    /// </summary>
    public partial class CartWindowMenager : Window
    {
        
        private readonly BlApi.IBl bl = BlApi.Factory.Get();

        /// <summary>
        /// Uppload the window
        /// </summary>
        public CartWindowMenager()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = bl.Cart.GetList();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Uppload the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Product_button(object sender, RoutedEventArgs e)
        {
            new ProductsWindowMenager().Show();
            this.Close();

        }
    }
}
