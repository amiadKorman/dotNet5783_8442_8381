using BO;
using BlApi;

namespace BlTest;

internal class BlMenuOfOrder
{
    private static IBl Ibl = new BlImplementation.Bl();

    #region Update
    /// <summary>
    /// Update order shipping date
    /// </summary>
    private static void UpdateOrderShipping()
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

    /// <summary>
    /// Update order delivery date
    /// </summary>
    private static void UpdateOrderDelivery()
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
    private static void ShowOrder()
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

    /// <summary>
    /// Print all orders
    /// </summary>
    private static void ShowOrdersList()
    {
        IEnumerable<OrderForList?> orders = Ibl.Order.GetAll();
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }
    }

    /// <summary>
    /// Print order tracking info
    /// </summary>
    private static void TrackOrder()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region MENU
    /// <summary>
    /// Print order menu and calls the appropriate method
    /// </summary>
    public static void OrderMenuBL()
    {
        EnumsOrderMenu Orderchoise = EnumsOrderMenu.TrackOrder;
        while (!Orderchoise.Equals(EnumsOrderMenu.GoBack))
        {
            Orderchoise = (EnumsOrderMenu)SafeInput.IntegerInput(
            "To Show Orders List - press 1\n" +
            "To Show Order Details - press 2\n" +
            "To Update Order Shipping - press 3\n" +
            "To Update Order Delivery - press 4\n" +
            "To Order Tracking - press 5\n" +
            "To Return Back To The Main Menu - press 0\n\n");

            switch (Orderchoise)
            {
                case EnumsOrderMenu.ShowListOfOrders:
                    ShowOrdersList();
                    break;
                case EnumsOrderMenu.ShowOrderDetails:
                    ShowOrder();
                    break;
                case EnumsOrderMenu.UpdateOrderShipping:
                    UpdateOrderShipping();
                    break;
                case EnumsOrderMenu.UpdateOrderDelivery:
                    UpdateOrderDelivery();
                    break;
                case EnumsOrderMenu.TrackOrder:
                    TrackOrder();
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
