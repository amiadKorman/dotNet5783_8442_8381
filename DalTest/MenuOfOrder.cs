namespace Dal;

internal class MenuOfOrder
{
    #region Add New Order
    public static void AddNewOrder()
    {
        Console.WriteLine("for add a new Order, please fill in the following data:");
        int Id = SafeInput.IntegerInput("ID order: ");
        int CustomerId = SafeInput.IntegerInput("ID Customer: ");
        DateTime? NullDateTime = null;
        DateTime OrderDate = Convert.ToDateTime(NullDateTime);
        DateTime ShipDate = Convert.ToDateTime(NullDateTime); ;
        DateTime DeliveryDate = Convert.ToDateTime(NullDateTime);
        Console.WriteLine("Adding a new Order...");
        DalOrder.AddOrder(Id, CustomerId, OrderDate, ShipDate, DeliveryDate);
    }
    #endregion

    #region Update Order
    public static void UpdateOrder()
    {
        int Id = SafeInput.IntegerInput("Plese enter the ID of order that you wont to update: ");
        DalOrder.OrderAreExist(Id);
        int CustomerId = SafeInput.IntegerInput("ID Customer: ");
        DateTime? NullDateTime = null;
        DateTime? OrderDate = Convert.ToDateTime(NullDateTime);
        DateTime? ShipDate = Convert.ToDateTime(NullDateTime); ;
        DateTime? DeliveryDate = Convert.ToDateTime(NullDateTime);
        Console.WriteLine("Update the Order ditels...");
    }
    #endregion

    #region Show Order
    public static void ShowOrder()
    {
        int IdOrder = SafeInput.IntegerInput("ID: ");
        Console.WriteLine(DalOrder.GetOrder(IdOrder));
    }
    #endregion

    #region Show Order List
    public static void ShowOrderList()
    {
        DalOrder.ShowAllOrders();
    }
    #endregion

    #region Delete Order
    public static void DeleteOrder()
    {
        int IdOrder = SafeInput.IntegerInput("ID: ");
        DalOrder.DeleteOrder(IdOrder);
    }
    #endregion

    #region OrderMenu
    public static void OrderMenu()
    {
        OrderMenu Orderchoise = Dal.OrderMenu.AddOrder;
        while (!Orderchoise.Equals(Dal.EntitysMenu.Exit))
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
                case Dal.OrderMenu.GoToTheFirstMenu:
                    break; ;
                default:
                    Console.WriteLine("This option does not exist, please try again\n");
                    break;
            }
        }
    }
    #endregion

}

