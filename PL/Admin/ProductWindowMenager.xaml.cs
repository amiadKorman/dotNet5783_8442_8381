﻿using System;
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
        public ProductWindowMenager()
        {
            InitializeComponent();
        }

        private void Add_product(object sender, RoutedEventArgs e)
        {
            new Products.ProductListWindow().Show();
            new Products.ProductWindow().Show();
            Close();


        }

        private void Show_product(object sender, RoutedEventArgs e)
        {
            new Products.ProductListWindow().Show();
            Close();

        }
    }
}