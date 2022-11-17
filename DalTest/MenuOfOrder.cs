using DO;

namespace Dal;

internal class MenuOfOrder
{
    private static DalOrder dalOrder = new();
    #region Add New Order
    public static void AddNewOrder()
    {
        Console.WriteLine("To add a new order, please fill in the following data:");

        //int ID = SafeInput.IntegerInput("ID: ");
        int customerID = SafeInput.IntegerInput("Customer ID: ");
        string customerName = SafeInput.StringInput("Customer name: ");
        string customerEmail = SafeInput.StringInput("Customer email: ");
        string customerAddress = SafeInput.StringInput("Customer address: ");
        DateTime ? NullDateTime = null;
        DateTime orderDate = Convert.ToDateTime(NullDateTime);
        DateTime shipDate = Convert.ToDateTime(NullDateTime); ;
        DateTime deliveryDate = Convert.ToDateTime(NullDateTime);
        Console.WriteLine("Adding a new Order...");
        Customer customer = new()
        {
            ID = customerID,
            Name = customerName,
            Email = customerEmail,
            Address = customerAddress
        };
        Order order = new()
        {
            Customer = customer,
            OrderDate = orderDate,
            ShipDate = shipDate,
            DeliveryDate = deliveryDate
        };
        try
        {
            int orderID = dalOrder.AddOrder(order);
            Console.WriteLine($"The new order was successfully added with ID {orderID}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region Update Order
    public static void UpdateOrder()
    {
        throw new NotImplementedException();

        int ID = SafeInput.IntegerInput("Plese enter the ID of order that you wont to update: ");
        Order order = dalOrder.GetOrder(ID);
        int CustomerId = SafeInput.IntegerInput("ID Customer: ");
        DateTime? NullDateTime = null;
        DateTime? OrderDate = Convert.ToDateTime(NullDateTime);
        DateTime? ShipDate = Convert.ToDateTime(NullDateTime); ;
        DateTime? DeliveryDate = Convert.ToDateTime(NullDateTime);
        Console.WriteLine("Update the Order ditels...");
        if (order.Customer.ID != 0)
            order.Customer = order.Customer;
        if (order.ShipDate != null)
            order.ShipDate = order.ShipDate;
        if (order.DeliveryDate != null)
            order.DeliveryDate = order.DeliveryDate;
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
    /// Print Order menu and calls the appropriate method
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

