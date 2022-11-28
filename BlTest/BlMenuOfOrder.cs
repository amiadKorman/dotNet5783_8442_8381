using Bl;
using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlTest
{
    internal class BlMenuOfOrder
    {


        #region MENU
        /// <summary>
        /// Print order menu and calls the appropriate method
        /// </summary>
        public static void OrderMenu()
        {
            OrderMenu Orderchoise = Bl.OrderMenu.AddOrder;
            while (!Orderchoise.Equals(Bl.OrderMenu.GoBack))
            {
                Orderchoise = (OrderMenu)BlSafeInput.IntegerInput(
                "To Add an Order - press 1\n" +
                "To Update an Order - press 2\n" +
                "To Show an Order - press 3\n" +
                "To Show Orders List - press 4\n" +
                "To Delete an Order - press 5\n" +
                "To Return Back To The Main Menu - press 0\n\n");

                switch (Orderchoise)
                {
                    case Bl.OrderMenu.AddOrder:
                        AddNewOrder();
                        break;
                    case Dal.OrderMenu.UpdateOrder:
                        UpdateOrder();
                        break;
                    case Dal.OrderMenu.ShowOrder:
                        ShowOrder();
                        break;
                    case Dal.OrderMenu.ShowListOfOrder:
                        ShowOrderList();
                        break;
                    case Dal.OrderMenu.DeleteAnOrder:
                        DeleteOrder();
                        break;
                    case Dal.OrderMenu.GoBack:
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
