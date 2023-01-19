using BO;
using BlApi;

namespace BlTest;

internal class BlMenuOfOrder
{
    private static IBl? ibl = BlApi.Factory.Get();

    #region Update
    /// <summary>
    /// Update order shipping date
    /// </summary>
    private static void UpdateOrderShipping()
    {
        int orderID = SafeInput.IntegerInput("Enter order ID to update shipping for: ");
        try
        {
            ibl.Order.UpdateShipping(orderID);
            Console.WriteLine("Order shipping date updated");
        }
        catch (BlAlreadyExistsException ex)
        {
            Console.WriteLine("Failed to update shipping date" + ex);
        }
        catch (BlDoesNotExistException ex)
        {
            Console.WriteLine("Failed to update shipping date" + ex);
        }
        catch (BlInvalidFieldException ex)
        {
            Console.WriteLine("Failed to update shipping date" + ex);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Failed to update shipping date" + ex);
        }
    }

    /// <summary>
    /// Update order delivery date
    /// </summary>
    private static void UpdateOrderDelivery()
    {
        int orderID = SafeInput.IntegerInput("Enter order ID to update delivery for: ");
        try
        {
            ibl.Order.UpdateDelivery(orderID);
            Console.WriteLine("Order delivery date updated");
        }
        catch (BlAlreadyExistsException ex)
        {
            Console.WriteLine("Failed to update delivery date" + ex);
        }
        catch (BlDoesNotExistException ex)
        {
            Console.WriteLine("Failed to update delivery date" + ex);
        }
        catch (BlInvalidFieldException ex)
        {
            Console.WriteLine("Failed to update delivery date" + ex);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Failed to update delivery date" + ex);
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
            Order order = ibl.Order.Get(IdOrder);
            Console.WriteLine(order);
        }
        catch (BlDoesNotExistException ex)
        {
            Console.WriteLine("Failed to get order details" + ex);
        }
        catch (BlInvalidFieldException ex)
        {
            Console.WriteLine("Failed to get order details" + ex);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Failed to get order details" + ex);
        }
    }

    /// <summary>
    /// Print all orders
    /// </summary>
    private static void ShowOrdersList()
    {
        try
        {
            IEnumerable<OrderForList?> orders = ibl.Order.GetAll();
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }
        catch (BlDoesNotExistException ex)
        {
            Console.WriteLine("Failed to show orders" + ex);
        }
        catch (BlInvalidFieldException ex)
        {
            Console.WriteLine("Failed to show orders" + ex);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Failed to show orders" + ex);
        }
        catch (BlFailedException ex)
        {
            Console.WriteLine("Failed to show orders" + ex);
        }
    }

    /// <summary>
    /// Print order tracking info
    /// </summary>
    private static void TrackOrder()
    {
        int orderID = SafeInput.IntegerInput("Enter order ID for tracking: ");
        try
        {
            OrderTracking tracking = ibl.Order.TrackOrder(orderID);
            Console.WriteLine(tracking);
        }
        catch (BlDoesNotExistException ex)
        {
            Console.WriteLine("Failed to track order" + ex);
        }
        catch (BlInvalidFieldException ex)
        {
            Console.WriteLine("Failed to track order" + ex);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Failed to track order" + ex);
        }
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
            "\nTo Show Orders List - press 1\n" +
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
