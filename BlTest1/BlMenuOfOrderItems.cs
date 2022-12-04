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
        public static Ibl ibl = new bl;

        #region ADD
        /// <summary>
        /// Add new order item
        /// </summary>
        public static void AddNewOrderItem()
        {
            Console.WriteLine("To add a new order item, please fill in the following data:");

            int orderID = SafeInput.IntegerInput("Order ID: ");
            int productID = SafeInput.IntegerInput("Product ID: ");
            double price = SafeInput.DoubleInput("Price: ");
            int amount = SafeInput.IntegerInput("Amount: ");

            Console.WriteLine("Adding a new Order Item...");
            OrderItem orderItem = new()
            {
                OrderID = orderID,
                ProductID = productID,
                Price = price,
                Amount = amount
            };
            try
            {
                int orderItemID = ibl.OrderItem.Add(orderItem);
                Console.WriteLine($"The new Order Item was successfully added with ID {orderItemID}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ", please try again\n");
            }
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Update existing order item
        /// </summary>
        public static void UpdateOrderItem()
        {
            int IDOrderItem = SafeInput.IntegerInput("Enter order item ID to update: ");
            try
            {
                OrderItem orderItem = idal.OrderItem.GetById(IDOrderItem);
                Console.WriteLine(orderItem);
                Console.WriteLine("To update, please fill in the following data(leave empty for no update):");
                // User input for order item properties
                double? price = SafeInput.NullDoubleInput("Price: ");
                int? amount = SafeInput.NullIntegerInput("Amount: ");
                // Checking for changes to update
                if (price.HasValue)
                    orderItem.Price = price.Value;
                if (amount.HasValue)
                    orderItem.Amount = amount.Value;

                ibl.OrderItem.Update(orderItem);
                Console.WriteLine($"The product was successfully updated:\n" + orderItem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ", please try again\n");
            }
        }
        #endregion




        #region MENU
        /// <summary>
        /// Print order item menu and calls the appropriate method
        /// </summary>
        public static void OrderItemMenu()
        {
            EnumsOrderItemMenu OrderItemchoise = EnumsOrderItemMenu.AddOrderItems;
            while (!OrderItemchoise.Equals(EnumsOrderItemMenu.GoBack))
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
                        AddNewOrderItem();
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
