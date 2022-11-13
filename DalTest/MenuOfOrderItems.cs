namespace Dal;

internal class MenuOfOrderItems
{
    private static dalOrderItem dalOrderItem = new dalOrderItem();
    #region Add New Order Item
    /// <summary>
    /// 
    /// </summary>
    public static void AddNewOrderItem()
    {
        Console.WriteLine("for add a new Order Item, please fill in the following data:");
        int OrderID = SafeInput.IntegerInput("Order ID: ");
        int ProductID = SafeInput.IntegerInput("Product ID: ");
        double Price = SafeInput.DoubleInput("Price: ");
        int Amount = SafeInput.IntegerInput("Amount: ");
        Console.WriteLine("Adding a new Base Station...");
        dalOrderItem.AddOrderItem(OrderID, ProductID, Price, Amount);
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
        Console.WriteLine(dalOrderItem.GetOrderItem(IdOrderItem));

    }
    #endregion

    #region Show list Order Item
    /// <summary>
    /// 
    /// </summary>
    public static void ShowListOfOrderItem()
    {
        dalOrderItem.ShowAllOrderItems();
    }
    #endregion

    #region Delete Order Item
    public static void DeleteOrderItem()
    {
        int IdOrderIthem = SafeInput.IntegerInput("ID: ");
        dalOrderItem.DeleteOrderItem(IdOrderIthem);

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
            OrderItemchoise = (OrderItemMenu)SafeInput.IntegerInput(
               "To Add an Order item - press 1\n" +
               "To Update an Order item - press 2\n" +
               "To Show an Order item - press 3\n" +
               "To Show Order items list - press 4\n" +
               "To Delete an Order item - press 5\n" +
               "To Return back to the menu - press 0\n\n");

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
                case Dal.OrderItemMenu.GoToTheFirstMenu:
                    break;
                default:
                    Console.WriteLine("This option does not exist, please try again\n");
                    break;
            }
        }
    }
    #endregion
}