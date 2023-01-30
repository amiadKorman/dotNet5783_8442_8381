using PL.Customer;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for MenuWindowCustomer.xaml
    /// </summary>
    public partial class MenuWindowCustomer : Window
    {
        private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;

        
        public MenuWindowCustomer()
        {
            InitializeComponent();
        }

       

        private void sing_in(object sender, RoutedEventArgs e)
        {
            new CustomerSingInWindow().Show();
            Close();

        }

        private void sing_up(object sender, RoutedEventArgs e)
        {
            new CustomerSingUpWindow().Show();
            Close();
        }
    }
}
