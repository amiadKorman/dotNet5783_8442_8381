using BO;
using BlTest1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlTest1
{
    internal class BlMenuOfCustomer
    {





        #region MENU
        /// <summary>
        /// Print customer menu and calls the appropriate method
        /// </summary>
        public static void CustomerMenu()
        {
            EnumsCustomerMenu ProductChoise = EnumsCustomerMenu.AddCustomer;
            while (!ProductChoise.Equals(EnumsCustomerMenu.GoBack))
            {
                ProductChoise = (EnumsCustomerMenu)SafeInput.IntegerInput(
                    "To Add a Customer - press 1\n" +
                    "To Update a Customer - press 2\n" +
                    "To Show a Customer - press 3\n" +
                    "To Show Customers List - press 4\n" +
                    "To Delete a Customer - press 5\n" +
                    "To Return back to the menu - press 0\n\n");

                switch (ProductChoise)
                {
                    case EnumsCustomerMenu.AddCustomer:
                        //AddNewCustomer();
                        break;
                    case EnumsCustomerMenu.UpdateCustomer:
                        //UpdateCustomer();
                        break;
                    case EnumsCustomerMenu.ShowCustomer:
                        //ShowCustomer();
                        break;
                    case EnumsCustomerMenu.ShowListOfCustomers:
                        //ShowListCustomer();
                        break;
                    case EnumsCustomerMenu.DeleteCustomer:
                        //DeleteCustomer();
                        break;
                    case EnumsCustomerMenu.GoBack:
                        //BlMain.Main();
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
