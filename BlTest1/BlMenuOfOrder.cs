using BO;
using BlTest1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BlImplementation;

namespace BlTest1
{
    internal class BlMenuOfOrder
    {
        private static IBl Ibl = new BlImplementation.Bl();

        #region
        public static void AddOrder()
        {
            Console.WriteLine("To add a new order, please fill in the following data:");
            int ID = SafeInput.IntegerInput("ID: ");
            int CostumerId = SafeInput.IntegerInput("Name: ");
            DateTime ODate = DateTime.Now;
            DateTime? SDate = null;
            DateTime? DDate = null;
            IEnumerable<OrderItem> items = new List<OrderItem>();
            double Total = SafeInput.DoubleInput("Price: ");
            Console.WriteLine("status: ");
            var status = Enum.GetValues(typeof(OrderStatus));
            foreach (OrderStatus orderStatus1 in OrderStatus)
            {
                Console.WriteLine($"\tFor {category} - press {(int)category}");
            }
            OrderStatus orderStatus = (OrderStatus)SafeInput.IntegerInput();
            int inStock = SafeInput.IntegerInput("In Stock: ");
            Console.WriteLine("Adding a new Product...");


            Order order = new()
            {
                ID = ID,
                CustomerID = CostumerId,
                OrderDate = ODate,
                ShipDate = SDate,
                DeliveryDate = DDate,
                Items = items,
                TotalPrice = Total,
                Status = orderStatus,
             
            };
            try
            {
                int Id = ID;
                ibl.Product.Add(order);
                Console.WriteLine($"The new product was successfully added with ID {ID}\n");
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
                Order order = Ibl.Order.Get(BlOrder);
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

        #region SHOW 
        /// <summary>
        /// Print specific order
        /// </summary>
        public static void ShowOrder()
        {
            int IdOrder = SafeInput.IntegerInput("Enter order ID: ");
            try
            {
                Order order = Ibl.Order.Get(IdOrder);
                Console.WriteLine(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ", please try again\n");
            }
        }
        #endregion

        #region Show All

        /// <summary>
        /// Print all orders
        /// </summary>
        public static void ShowOrderList()
        {
            IEnumerable<OrderForList?> orders = Ibl.Order.GetAll();
            foreach (var order in orders)
            {
                Console.WriteLine(order);
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
                    case EnumsOrderMenu.UpdateOrder:
                        UpdateOrder();
                        break;
                    case EnumsOrderMenu.ShowOrder:
                        ShowOrder();
                        break;
                    case EnumsOrderMenu.ShowListOfOrder:
                        ShowOrderList();
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
