using DO;

namespace Dal;

internal class MenuOfOrder
{
    private static DalOrder dalOrder = new();

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
            CustomerID = customerID
        };
        try
        {
            int orderID = dalOrder.AddOrder(order);
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
            Order order = dalOrder.GetOrder(IDOrder);
            Console.WriteLine(order);
            Console.WriteLine("To update, please fill in the following data(-1 for no update):");
            // User input for order item properties
            int customerID = SafeInput.IntegerInput("Customer ID: ");
            // Checking for changes to update
            if (customerID.Equals(""))
                order.CustomerID = customerID;
            // update she date of delivey and shiping 
            DateTime? NullDateTime = null;
            YseOrNo Y = (YseOrNo)SafeInput.IntegerInput("Are the ship go to the castumer");
            if(Y == YseOrNo.Yes)
            {
                order.ShipDate = DateTime.Now;
                Y = (YseOrNo)SafeInput.IntegerInput("Are the delivery get to the castumer");
                if (Y==YseOrNo.Yes)
                {
                    order.DeliveryDate = DateTime.Now;
                }
                else
                {
                    order.DeliveryDate = Convert.ToDateTime(NullDateTime);
                }
                order.ShipDate = Convert.ToDateTime(NullDateTime);
            } 
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
            Order order = dalOrder.GetOrder(IdOrder);
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
        Order[] orders = dalOrder.GetAllOrders();
        foreach (Order order in orders)
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
            dalOrder.DeleteOrder(IdOrder);
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

