using DO;
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
                Dal.EntitysMenu MenuChoise = Dal.EntitysMenu.OrderMenu;
                while (!MenuChoise.Equals(Dal.EntitysMenu.Exit))
                {
                    Console.WriteLine("For Order press 1\n" +
                    "For OrderItem press 2\n" +
                    "For product press 3\n" +
                    "Foe Exit press 4");
                };
            switch (MenuChoise)
            {
                case Dal.EntitysMenu.OrderMenu:
                    Dal.MenuOfOrder.OrderMenu();
                    break;
                case Dal.EntitysMenu.OrderItemsMenu:
                    Dal.MenuOfOrderItems.OrderItemMenu();
                    break;
                case Dal.EntitysMenu.ProductMenu:
                    Dal.MenuOfProduct.ProductMenu();
                    break;
                case Dal.EntitysMenu.Exit:
                    break;
                default:
                    Console.WriteLine("Error. Try again");
                    break;
            }
        }
        #endregion
    }



}



