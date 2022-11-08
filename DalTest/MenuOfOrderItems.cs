namespace Dal;

internal class MenuOfOrderItems
{
    #region Add New Order Item
    /// <summary>
    /// 
    /// </summary>
    public static void AddNewOrderItem()
    {

        Console.WriteLine("for add a new Order Item, please fill in the following data:");
        int OrderID = SafeInput.IntegerInput("ID: ");
        int ProductID = SafeInput.IntegerInput("ProductID: ");
        double Price = SafeInput.DoubleInput("Price: ");
        int Amount = SafeInput.IntegerInput("Amount: ");
        Console.WriteLine("Adding a new Base Station...");
        Dal.DalOrderItem.AddOrderItem(OrderID, ProductID, Price, Amount);
        Console.WriteLine("The new Order Item was successfully added\n");
    }
    #endregion

    #region Update Order Item
    public static void UpdateOrderItem()
    {

    }
    #endregion

    #region Show Order Item
    /// <summary>
    /// 
    /// </summary>
    public static void ShowOrderItem()
    {
        int IdOrderItem = SafeInput.IntegerInput("ID: ");
        Console.WriteLine(DalOrderItem.GetOrderItem(IdOrderItem));

    }
    #endregion

    #region Show list Order Item
    /// <summary>
    /// 
    /// </summary>
    public static void ShowListOfOrderItem()
    {

    }
    #endregion

    #region Delete Order Item
    public static void DeleteOrderItem()
    {
        int IdOrderIthem = SafeInput.IntegerInput("ID: ");
        DalOrderItem.DeleteOrderItem(IdOrderIthem);

    }
    #endregion

    #region Order Item Menu
    /// <summary>
    /// 
    /// </summary>
    public static void OrderItemMenu()
    {
        OrderItemMenu OrderItemchoise = Dal.OrderItemMenu.AddOrderItems;
        while (!OrderItemchoise.Equals(EntitysMenu.Exit))
        {
            Console.WriteLine("for add Order - press 1\n" +
        "for Update Order - press 2\n" +
        "for show order - press 3\n" +
        "for show order list - press 4\n" +
        "for delete order - press 5\n");
        }
        switch (OrderItemchoise)
        {
            case Dal.OrderItemMenu.AddOrderItems:
                AddNewOrderItem();
                break;
            case Dal.OrderItemMenu.UpdateOrderItems:
                UpdateOrderItem();
                break;
            case Dal.OrderItemMenu.ShowOrderItems:
                ShowOrderItem();
                break;
            case Dal.OrderItemMenu.ShowListOfOrderItems:
                ShowListOfOrderItem();
                break;
            case Dal.OrderItemMenu.DeleteAnOrderItems:
                DeleteOrderItem();
                break;
            default:
                Console.WriteLine("This option does not exist, please try again\n");
                break;
        }
    }
    #endregion
}
