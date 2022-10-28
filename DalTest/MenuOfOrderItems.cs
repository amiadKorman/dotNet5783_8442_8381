using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class MenuOfOrderItems
    {
        #region Add New Order Item
        public static void AddNewOrderItem()
        {
            OrderItem NewOrderItem = new OrderItem();
            Console.WriteLine("for add a new Order Item, please fill in the following data:");


            NewOrderItem.OrderID = SafeInput.IntegerInput("ID: ");
            NewOrderItem.ProductID = SafeInput.IntegerInput("ProductID: ");
            NewOrderItem.Price = SafeInput.DoubleInput("Price: ");
            NewOrderItem.Amount = SafeInput.IntegerInput("Amount: ");

            Console.WriteLine("Adding a new Base Station...");
            ///צריך "לשמור את הישות פה"

            Console.WriteLine("The new Base Station was successfully added\n");


        }
        #endregion

        #region Update Order Item
        public static void UpdateOrderItem()
        {

        }
        #endregion

        #region Show Order Item
        public static void ShowOrderItem()
        {

        }
        #endregion

        #region Show list Order Item
        public static void ShowListOfOrderItem()
        {

        }
        #endregion

        #region Delete Order Item
        public static void DeleteOrderItem()
        {

        }
        #endregion


        public static void OrderItemMenu()
        {
            Dal.OrderItemMenu OrderItemchoise = Dal.OrderItemMenu.AddOrderItems;
            while (!OrderItemchoise.Equals(Dal.EntitysMenu.Exit))
            {
                Console.WriteLine("for add Order - press 1\n" +
            "for Update Order - press 2\n" +
            "for show order - press 3\n" +
            "for show order list - press 4\n" +
            "for delete order - press 5\n");
            }
            switch (OrderItemchoise)
            {
                case Dal.OrderItemMenu.AddOrderItems:
                    AddNewOrderItem();
                    break;
                case Dal.OrderItemMenu.UpdateOrderItems:
                    UpdateOrderItem();
                    break;
                case Dal.OrderItemMenu.ShowOrderItems:
                    ShowOrderItem();
                    break;
                case Dal.OrderItemMenu.ShowListOfOrderItems:
                    ShowListOfOrderItem();
                    break;
                case Dal.OrderItemMenu.DeleteAnOrderItems:
                    DeleteOrderItem();
                    break;
                default:
                    Console.WriteLine("This option does not exist, please try again\n");
                    break;
            }
        }
    }
}




    


