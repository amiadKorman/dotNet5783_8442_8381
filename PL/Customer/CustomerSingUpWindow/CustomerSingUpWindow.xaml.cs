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

namespace PL.Customer.CustomerSingUpWindow
{
    /// <summary>
    /// Interaction logic for CustomerSingUpWindow.xaml
    /// </summary>
    public partial class CustomerSingUpWindow : Window
    {
        public CustomerSingUpWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (true)
            {
                this.DragMove();
            }
        }

        private void Cencel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MyTextBox_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MyTextBox_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
