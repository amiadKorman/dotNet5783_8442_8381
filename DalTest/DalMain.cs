using DO;
using Dal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    class DalMain
    {
        #region Mainaly Main
        static void Main(string[] args)
        {
            EntitysMenu MenuChoise = EntitysMenu.OrderMenu;
            while (!MenuChoise.Equals(EntitysMenu.Exit))
            {
                Console.WriteLine("For Order press 1\n" +
                "For OrderItem press 2\n" +
                "For product press 3\n" +
                "Foe Exit press 0");
            };
            switch (MenuChoise)
            {
                case EntitysMenu.OrderMenu:
                    MenuOfOrder.OrderMenu();
                    break;
                case EntitysMenu.OrderItemsMenu:
                    MenuOfOrderItems.OrderItemMenu();
                    break;
                case EntitysMenu.ProductMenu:
                    MenuOfProduct.ProductMenu();
                    break;
                case EntitysMenu.Exit:
                    break;
                default:
                    Console.WriteLine("Error. Try again");
                    break;
            }
        }
        #endregion
    }
}



