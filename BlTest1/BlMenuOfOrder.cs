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
        private static IBl Ibl = new Bl();


        #region Add New Order
        /// <summary>
        /// Add new order
        /// </summary>
        public static void AddNewOrder()
        {
            Console.WriteLine("To add a new Order, please fill in the following data:");

            int customerID = SafeInput.IntegerInput("Customer ID: ");
            Console.WriteLine("Adding a new Order...");
            IOrder order = new()
            {
                CustomerID = customerID
            };
            try
            {
                int orderID = idal.Order.Add(order);
                Console.WriteLine($"The new Order was successfully added with ID {orderID}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ", please try again\n");
            }
        }
        #endregion

        #region Update Order
        /// <summary>
        /// Update existing order
        /// </summary>
        public static void UpdateOrder()
        {
            int BlOrder = SafeInput.IntegerInput("Enter order ID to update: ");
            try
            {
                Order order = Ibl.Order.GetById(BlOrder);
                Console.WriteLine(order);
                // User input for order item properties
                string shipDate = "", deliveryDate = "";
                if (!order.ShipDate.HasValue)
                {
                    shipDate = SafeInput.NullStringInput("To update ship date to now enter something, or leave empty for no update: ");
                    if (shipDate != "")
                        order.ShipDate = DateTime.Now;
                }
                else if (!order.DeliveryDate.HasValue)
                {
                    deliveryDate = SafeInput.NullStringInput("To update delivery date to now enter something, or leave empty for no update: ");
                    if (deliveryDate != "")
                        order.DeliveryDate = DateTime.Now;
                }

                Ibl.Order.Update(order);
                Console.WriteLine($"The order was successfully updated:\n" + order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ", please try again\n");
            }
        }
        #endregion









        #region MENU
        /// <summary>
        /// Print order menu and calls the appropriate method
        /// </summary>
        public static void OrderMenuBL()
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
                        AddNewOrder();
                        break;
                    case EnumsOrderMenu.UpdateOrder:
                        UpdateOrder();
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
