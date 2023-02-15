using PL.Customer.CustomerMenuWindow;
using PL.Customer.CustomerSingUpWindow;
using System.Windows;
using System.Windows.Input;

namespace PL
{
    public partial class CustomerSingInWindow : Window
    {
        public CustomerSingInWindow()
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
           
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e, object textBox)
        {
            

            new CustomerMenuWindow().Show();
            this.Close();
            
        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
           
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sing_up_Botton(object sender, RoutedEventArgs e)
        {
            new CustomerSingUpWindow().Show();
            this.Close();
        }
    }
}