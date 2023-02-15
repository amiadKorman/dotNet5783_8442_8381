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

namespace PL.Admin.MenuWindowMenager
{
    
    /// <summary>
    /// Interaction logic for CustomersWindowMenager.xaml
    /// </summary>
    public partial class CustomersWindowMenager : Window
    {
        private readonly BlApi.IBl bl = BlApi.Factory.Get();
        /// <summary>
        /// Uppload the window
        /// </summary>
        public CustomersWindowMenager()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = bl.Customer.GetList();
        }

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        #region
        /// <summary>
        /// Change to the window of the products
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Product_Click(object sender, RoutedEventArgs e)
        {
            new ProductsWindowMenager().Show();
            this.Close();
        }

        /// <summary>
        /// Change to the window of the Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Order_Click(object sender, RoutedEventArgs e)
        {
            new OrdersWindowMenager().Show();
            this.Close();
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Log_Out(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();

        }

        #endregion
    }

}
