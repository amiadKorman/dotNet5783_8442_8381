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
using System.Security.Cryptography;


namespace PL.Admin.AdminSingInWindow
{
    /// <summary>
    /// Interaction logic for AdminSingInWindow.xaml
    /// </summary>
    public partial class AdminSingInWindow : Window
    {
        private readonly BlApi.IBl bl = BlApi.Factory.Get();
        


        /// <summary>
        /// Uppload the window
        /// </summary>
        public AdminSingInWindow()
        {
            InitializeComponent();      
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
            textEmail.Text = "";

        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

       

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            textEmail.Text = "";
            

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
            string? email = txtEmail.Text;
            string? password = passwordBox.Password;

            string Kemail = "Amiadk16@gmail.com";
            string Kpassword = "12345678";
            string Remail = "asdfghjkl";
            string Rpassword = "RonChai318@gmail.com";


            if ((email == Kemail && password == Kpassword) || (email == Remail && password == Rpassword))
            {
                new ProductsWindowMenager().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("The email or password is incorrect");
            }    



            
        }

       
    }


   


}
