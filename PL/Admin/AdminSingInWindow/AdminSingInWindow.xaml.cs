using PL.Admin.MenuWindowMenager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
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
using System.Xml;
using System.Xml.XPath;


namespace PL.Admin.AdminSingInWindow
{
    /// <summary>
    /// Interaction logic for AdminSingInWindow.xaml
    /// </summary>
    public partial class AdminSingInWindow : Window
    {
        private IEnumerable<Admin> admins;

        public AdminSingInWindow()
        {
            InitializeComponent();
            
            var converter = new BrushConverter();
            ObservableCollection<Admin> admins = new ObservableCollection<Admin>();

           


        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBox.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(passwordBox.Password))
            {
                MessageBox.Show("Successfully Signed In");
            }
        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
                textEmail.Visibility = Visibility.Collapsed;
            else
                textEmail.Visibility = Visibility.Visible;
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        /// <summary>
        /// ning in to admin mood
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sing_In(object sender, RoutedEventArgs e)
        {
            String email = textEmail.Text;
            String password = textPassword.Text;

            new ProductsWindowMenager().Show();
            this.Close();




        }       
    }


    public class Admin
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Brush BgColor { get; set; }  
             
               
    }


}
