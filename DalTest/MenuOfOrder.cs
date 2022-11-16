using DO;

namespace Dal;

internal class MenuOfOrder
{
    private static DalOrder dalOrder = new();
    #region Add New Order
    public static void AddNewOrder()
    {
        Console.WriteLine("for add a new Order, please fill in the following data:");
        int ID = SafeInput.IntegerInput("ID order: ");
        int customerID = SafeInput.IntegerInput("ID Customer: ");
        DateTime? NullDateTime = null;
        DateTime orderDate = Convert.ToDateTime(NullDateTime);
        DateTime shipDate = Convert.ToDateTime(NullDateTime); ;
        DateTime deliveryDate = Convert.ToDateTime(NullDateTime);
        Console.WriteLine("Adding a new Order...");
        Order order = new()
        {
            CustomerID = customerID,
            OrderDate = orderDate,
            ShipDate = shipDate,
            DeliveryDate = deliveryDate
        };
        dalOrder.AddOrder(order);
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
        if (order.CustomerID != 0)
            order.CustomerID = order.CustomerID;
        if (order.ShipDate != null)
            order.ShipDate = order.ShipDate;
        if (order.DeliveryDate != null)
            order.DeliveryDate = order.DeliveryDate;
    }
    #endregion

    #region Show Order
    public static void ShowOrder()
    {
        int IdOrder = SafeInput.IntegerInput("ID: ");
        Console.WriteLine(dalOrder.GetOrder(IdOrder));
    }
    #endregion

    #region Show Order List
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

