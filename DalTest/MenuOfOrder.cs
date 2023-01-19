using DalApi;
using DO;
using Dal;

namespace Dal;

internal class MenuOfOrder
{
    private static IDal? dal = Factory.Get();

    #region Add New Order
    /// <summary>
    /// Add new order
    /// </summary>
    public static void AddNewOrder()
    {
        Console.WriteLine("To add a new Order, please fill in the following data:");

        int customerID = SafeInput.IntegerInput("Customer ID: ");
        Console.WriteLine("Adding a new Order...");
        Order order = new()
        {
            CustomerID = customerID,
            OrderDate = DateTime.Now
        };
        try
        {
            int orderID = dal.Order.Add(order);
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
        int IDOrder = SafeInput.IntegerInput("Enter order ID to update: ");
        try
        {
            Order order = dal.Order.Get(IDOrder);
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

            dal.Order.Update(order);
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
            Order order = dal.Order.Get(IdOrder);
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
    public static void ShowOrderList()
    {
        IEnumerable<Order?> orders = dal.Order.GetAll();
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }
    }
    #endregion

    #region DELETE
    /// <summary>
    /// Delete order by ID
    /// </summary>
    public static void DeleteOrder()
    {
        int IdOrder = SafeInput.IntegerInput("Enter order ID: ");
        try
        {
            dal.Order.Delete(IdOrder);
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
    public static void OrderMenu()
    {
        OrderMenu Orderchoise = Dal.OrderMenu.AddOrder;
        while (!Orderchoise.Equals(Dal.OrderMenu.GoBack))
        {
            Orderchoise = (OrderMenu)SafeInput.IntegerInput(
            "To Add an Order - press 1\n" +
            "To Update an Order - press 2\n" +
            "To Show an Order - press 3\n" +
            "To Show Orders List - press 4\n" +
            "To Delete an Order - press 5\n" +
            "To Return Back To The Main Menu - press 0\n\n");

            switch (Orderchoise)
            {
                case Dal.OrderMenu.AddOrder:
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

