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

namespace PL.Customer.CustomerMenuWindow
{
    /// <summary>
    /// Interaction logic for CustomerMenuWindow.xaml
    /// </summary>
    public partial class CustomerMenuWindow : Window
    {
        private readonly BlApi.IBl bl = BlApi.Factory.Get();
        
        
        public CustomerMenuWindow()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = bl.Product.GetList();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        
        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
