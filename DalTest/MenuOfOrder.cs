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
        DateTime OrderDate = Convert.ToDateTime(NullDateTime);
        DateTime ShipDate = Convert.ToDateTime(NullDateTime); ;
        DateTime DeliveryDate = Convert.ToDateTime(NullDateTime);
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
            Console.WriteLine("for add Order - press 1\n" +
        "for Update Order - press 2\n" +
        "for show order - press 3\n" +
        "for show order list - press 4\n" +
        "for delete order - press 5\n");
        }
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
            default:
                Console.WriteLine("This option does not exist, please try again\n");
                break;
        }
    }
    #endregion
}
