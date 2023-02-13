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
    /// Interaction logic for OrdersWindowMenager.xaml
    /// </summary>
    public partial class OrdersWindowMenager : Window
    {
        private readonly BlApi.IBl bl = BlApi.Factory.Get();
        
        public OrdersWindowMenager()
        {
            InitializeComponent();

            membersDataGrid.ItemsSource = bl.Order.GetAll();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

    

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        #region Menu left buttons
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Product_choise(object sender, RoutedEventArgs e)
        {
            new ProductsWindowMenager().Show();
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerChoise(object sender, RoutedEventArgs e)
        {
            new CustomersWindowMenager().Show();
            this.Close();
        }





        private void Logout(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();

        }
        #endregion
    }
}
