using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class MenuOfProduct
    {

        #region Add New Product
        public static void AddNewProduct()
        {
            Product NewProduct = new Product();
            Console.WriteLine("for add a new Order Item, please fill in the following data:");

            NewProduct.ID = SafeInput.IntegerInput("ID: ");
            Console.WriteLine("Name: ");
            NewProduct.Name = Console.ReadLine();
            NewProduct.Price = SafeInput.DoubleInput("Price: ");
            Console.WriteLine("Category: ");
            NewProduct.Category = (CategoryOfProduct)SafeInput.IntegerInput
                ("Category Of Product:\n" +
                "X - press 1\n" +
                "Y- press 2\n" +
                "Z - press 3\n");
            NewProduct.ID = SafeInput.IntegerInput("InStock: ");


            Console.WriteLine("Adding a new Product...");
            ///צריך "לשמור את הישות פה"

            Console.WriteLine("The new Product was successfully added\n");

        }
        #endregion

        #region Update Product
        public static void UpdateProduct()
        {

        }
        #endregion

        #region Show Product
        public static void ShowProduct()
        {

        }
        #endregion

        #region Show List Product
        public static void ShowListProduct()
        {

        }
        #endregion

        #region Delete Product
        public static void DeleteProduct()
        {

        }
        #endregion

        public static void ProductMenu()
        {
            Dal.ProductMenu ProductChoise = Dal.ProductMenu.AddProduct;
            while (!ProductChoise.Equals(Dal.EntitysMenu.Exit))
            {
                Console.WriteLine("for add Order - press 1\n" +
            "for Update Order - press 2\n" +
            "for show order - press 3\n" +
            "for show order list - press 4\n" +
            "for delete order - press 5\n");
            }
            switch (ProductChoise)
            {
                case Dal.ProductMenu.AddProduct:
                    AddNewProduct();
                    break;
                case Dal.ProductMenu.UpdateProduct:
                    UpdateProduct();
                    break;
                case Dal.ProductMenu.ShowProduct:
                    ShowProduct();
                    break;
                case Dal.ProductMenu.ShowListOfProduct:
                    ShowListProduct();
                    break;
                case Dal.ProductMenu.DeleteAProduct:
                    DeleteProduct();
                    break;
                default:
                    Console.WriteLine("This option does not exist, please try again\n");
                    break;

            }
        }
    }

}