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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void CustomerChoise(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();

        }

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
