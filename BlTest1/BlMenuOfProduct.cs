using BO;
using BlTest1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlTest1
{
    internal class BlMenuOfProduct
    {




        #region MENU
        /// <summary>
        /// Print product menu and calls the appropriate method
        /// </summary>
        public static void ProductMenu()
        {
            EnumsProductMenu ProductChoise = EnumsProductMenu.AddProduct;
            while (!ProductChoise.Equals(EnumsProductMenu.GoBack))
            {
                ProductChoise = (EnumsProductMenu)SafeInput.IntegerInput(
                    "To Add a Product - press 1\n" +
                    "To Update a Product - press 2\n" +
                    "To Show a Product - press 3\n" +
                    "To Show Products List - press 4\n" +
                    "To Delete a Product - press 5\n" +
                    "To Return back to the menu - press 0\n\n");

                switch (ProductChoise)
                {
                    case EnumsProductMenu.AddProduct:
                        //AddNewProduct();
                        break;
                    case EnumsProductMenu.UpdateProduct:
                        //UpdateProduct();
                        break;
                    case EnumsProductMenu.ShowProduct:
                        //ShowProduct();
                        break;
                    case EnumsProductMenu.ShowListOfProduct:
                        //ShowListProduct();
                        break;
                    case EnumsProductMenu.DeleteAProduct:
                        //DeleteProduct();
                        break;
                    case EnumsProductMenu.GoBack:
                        // BlMain.Main();
                        break;
                    default:
                        Console.WriteLine("This option doesn't exist, please try again\n");
                        break;
                }
            }
        }
        #endregion
    }
}
