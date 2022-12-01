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
            OrderMenu Orderchoise = BlTest1.OrderMenu.AddOrder;
            while (!Orderchoise.Equals(BlTest1.OrderMenu.GoBack))
            {
                Orderchoise = (OrderMenu)SafeInput.IntegerInput(
                "To Add an Order - press 1\n" +
                "To Update an Order - press 2\n" +
                "To Show an Order - press 3\n" +
                "To Show Orders List - press 4\n" +
                "To Delete an Order - press 5\n" +
                "To Return Back To The Main Menu - press 0\n\n");

                switch (Orderchoise)
                {
                    case BlTest1.OrderMenu.AddOrder:
                        //AddNewOrder();
                        break;
                    case BlTest1.OrderMenu.UpdateOrder:
                        //UpdateOrder();
                        break;
                    case BlTest1.OrderMenu.ShowOrder:
                        //ShowOrder();
                        break;
                    case BlTest1.OrderMenu.ShowListOfOrder:
                        //ShowOrderList();
                        break;
                    case BlTest1.OrderMenu.DeleteAnOrder:
                        //DeleteOrder();
                        break;
                    case BlTest1.OrderMenu.GoBack:
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
