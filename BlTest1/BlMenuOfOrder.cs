using BO;
using BlTest1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlTest1
{
    internal class BlMenuOfOrder
    {
        
      










        #region MENU
        /// <summary>
        /// Print order menu and calls the appropriate method
        /// </summary>
        public static void OrderMenu()
        {
            EnumsOrderMenu Orderchoise = EnumsOrderMenu.AddOrder;
            while (!Orderchoise.Equals(EnumsOrderMenu.GoBack))
            {
                Orderchoise = (EnumsOrderMenu)SafeInput.IntegerInput(
                "To Add an Order - press 1\n" +
                "To Update an Order - press 2\n" +
                "To Show an Order - press 3\n" +
                "To Show Orders List - press 4\n" +
                "To Delete an Order - press 5\n" +
                "To Return Back To The Main Menu - press 0\n\n");

                switch (Orderchoise)
                {
                    case EnumsOrderMenu.AddOrder:
                        //AddNewOrder();
                        break;
                    case EnumsOrderMenu.UpdateOrder:
                        //UpdateOrder();
                        break;
                    case EnumsOrderMenu.ShowOrder:
                        //ShowOrder();
                        break;
                    case EnumsOrderMenu.ShowListOfOrder:
                        //ShowOrderList();
                        break;
                    case EnumsOrderMenu.DeleteAnOrder:
                        //DeleteOrder();
                        break;
                    case EnumsOrderMenu.GoBack:
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
