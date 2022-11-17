using DO;

namespace Dal;

internal class MenuOfOrderItems
{
    private static DalOrderItem dalOrderItem = new();
    #region Add New Order Item
    public static void AddNewOrderItem()
    {
        Console.WriteLine("To add a new order item, please fill in the following data:");
        int orderID = SafeInput.IntegerInput("Order ID: ");
        int productID = SafeInput.IntegerInput("Product ID: ");
        double price = SafeInput.DoubleInput("Price: ");
        int amount = SafeInput.IntegerInput("Amount: ");
        Console.WriteLine("Adding a new Order Item...");
        OrderItem orderItem = new()
        {
            OrderID = orderID,
            ProductID = productID,
            Price = price,
            Amount = amount
        };
        int orderItemID = dalOrderItem.AddOrderItem(orderItem);
        Console.WriteLine("The new Order Item was successfully added\n");
    }
    #endregion

    #region Update Order Item
    public static void UpdateOrderItem()
    {
        throw new NotImplementedException();

        int ID = SafeInput.IntegerInput("Plese enter the ID of order item that you wont to update: ");
        OrderItem orderItem = dalOrderItem.GetOrderItem(ID);
        // USer input of order item properties
        if (orderItem.ProductID != 0)
            orderItem.ProductID = orderItem.ProductID;
        if (orderItem.OrderID != 0)
            orderItem.OrderID = orderItem.OrderID;
        if (orderItem.Price != 0.0)
            orderItem.Price = orderItem.Price;
        if (orderItem.Amount != 0)
            orderItem.Amount = orderItem.Amount;
    }
    #endregion

    #region SHOW
    /// <summary>
    /// Print specific order item
    /// </summary>
    public static void ShowOrderItem()
    {
        int IdOrderItem = SafeInput.IntegerInput("Enter order item ID: ");
        try
        {
            OrderItem orderItem = dalOrderItem.GetOrderItem(IdOrderItem);
            Console.WriteLine(orderItem);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    
    /// <summary>
    /// Print all order items
    /// </summary>
    public static void ShowListOfOrderItem()
    {
        OrderItem[] orderItems = dalOrderItem.GetAllOrderItems();
        foreach (OrderItem orderItem in orderItems)
        {
            Console.WriteLine(orderItem);
        }
    }
    #endregion

    #region DELETE
    /// <summary>
    /// Delete order item by ID
    /// </summary>
    public static void DeleteOrderItem()
    {
        int IdOrderIthem = SafeInput.IntegerInput("Enter order item ID: ");
        try
        {
            dalOrderItem.DeleteOrderItem(IdOrderIthem);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region MENU
    /// <summary>
    /// Print Order Item menu and calls the appropriate method
    /// </summary>
    public static void OrderItemMenu()
    {
        OrderItemMenu OrderItemchoise = Dal.OrderItemMenu.AddOrderItems;
        while (!OrderItemchoise.Equals(Dal.OrderItemMenu.GoBack))
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
                case Dal.OrderItemMenu.GoBack:
                    break;
                default:
                    Console.WriteLine("This option doesn't exist, please try again\n");
                    break;
            }
        }
    }
    #endregion
}