using BO;
using BlTest1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlTest1
{
    internal class BlMenuOfOrderItems
    {

          


        #region MENU
        /// <summary>
        /// Print order item menu and calls the appropriate method
        /// </summary>
        public static void OrderItemMenu()
        {
            EnumsOrderItemMenu OrderItemchoise = BlTest1.EnumsOrderItemMenu.AddOrderItems;
            while (!OrderItemchoise.Equals(BlTest1.EnumsOrderItemMenu.GoBack))
            {
                OrderItemchoise = (EnumsOrderItemMenu)SafeInput.IntegerInput(
                   "To Add an Order item - press 1\n" +
                   "To Update an Order item - press 2\n" +
                   "To Show an Order item by ID - press 3\n" +
                   "To Show an Order item by order and product ID's - press 4\n" +
                   "To Show Order items list - press 5\n" +
                   "To Show an specific Order's order items list - press 6\n" +
                   "To Delete an Order item - press 7\n" +
                   "To Return back to the menu - press 0\n\n");

                switch (OrderItemchoise)
                {
                    case BlTest1.EnumsOrderItemMenu.AddOrderItems:
                        //AddNewOrderItem();
                        break;
                    case BlTest1.EnumsOrderItemMenu.UpdateOrderItems:
                        //UpdateOrderItem();
                        break;
                    case BlTest1.EnumsOrderItemMenu.ShowOrderItemByID:
                        //ShowOrderItem();
                        break;
                    case BlTest1.EnumsOrderItemMenu.ShowOrderItemByProductAndCustomerID:
                        //ShowOrderItemByOrderAndCustomer();
                        break;
                    case BlTest1.EnumsOrderItemMenu.ShowOrderItemsListOfSpecificOrder:
                        //ShowListOfOrderOrderItems();
                        break;
                    case BlTest1.EnumsOrderItemMenu.ShowListOfOrderItems:
                        //ShowListOfOrderItems();
                        break;
                    case BlTest1.EnumsOrderItemMenu.DeleteAnOrderItems:
                       //DeleteOrderItem();
                        break;
                    case BlTest1.EnumsOrderItemMenu.GoBack:
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
