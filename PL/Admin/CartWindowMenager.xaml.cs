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

namespace PL.Admin
{
    /// <summary>
    /// Interaction logic for CartWindowMenager.xaml
    /// </summary>
    public partial class CartWindowMenager : Window
    {
        public CartWindowMenager()
        {
            InitializeComponent();
        }

        private void show_all_cart(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void home_page(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
