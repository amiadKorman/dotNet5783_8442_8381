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
        /// <summary>
        /// upload the window
        /// </summary>
        public CustomerSingUpWindow() => InitializeComponent();
       
       private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (true)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cencel_Click(object sender, RoutedEventArgs e) => new CustomerSingUpWindow().Show();

        
        /// <summary>
        /// create a new customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            

        }

        /// <summary>
        /// Sing in to the system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SingInClick(object sender, RoutedEventArgs e) => new CustomerSingInWindow().Show();



    }
}
