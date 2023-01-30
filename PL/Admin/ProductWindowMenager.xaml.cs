using PL.Products;
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
    /// Interaction logic for ProductWindowMenager.xaml
    /// </summary>
    public partial class ProductWindowMenager : Window
    {
        private readonly BlApi.IBl bl = BlApi.Factory.Get();

        public ProductWindowMenager()
        {
            InitializeComponent();
        }

        private void Add_product(object sender, RoutedEventArgs e)
        {
            new ProductWindow(bl).Show();
            Close();
        }
        
        



        private void Show_product(object sender, RoutedEventArgs e)
        {
            new ProductListWindow().Show();
            Close();
        }

        

        private void home_page(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
