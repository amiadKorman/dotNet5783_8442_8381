﻿using DO;

namespace Dal;

internal class MenuOfOrderItems
{
    private static DalOrderItem dalOrderItem = new();

    #region ADD
    /// <summary>
    /// Add new order item
    /// </summary>
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
        try
        {
            int orderItemID = dalOrderItem.AddOrderItem(orderItem);
            Console.WriteLine($"The new Order Item was successfully added with ID {orderItemID}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region UPDATE
    /// <summary>
    /// Update existing order item
    /// </summary>
    public static void UpdateOrderItem()
    {
        int IDOrderItem = SafeInput.IntegerInput("Enter order item ID to update: ");
        try
        {
            OrderItem orderItem = dalOrderItem.GetOrderItem(IDOrderItem);
            Console.WriteLine(orderItem);
            Console.WriteLine("To update, please fill in the following data(-1 for no update):");
            // User input for order item properties
            int productID = SafeInput.IntegerInput("Product ID: ");
            int orderID = SafeInput.IntegerInput("Order ID: ");
            double price = SafeInput.DoubleInput("Price: ");
            int amount = SafeInput.IntegerInput("Amount: ");
            // Checking for changes to update
            if (productID != -1)
                orderItem.ProductID = productID;
            if (orderID != -1)
                orderItem.OrderID = orderID;
            if (price != -1)
                orderItem.Price = price;
            if (amount != -1)
                orderItem.Amount = amount;

            dalOrderItem.UpdateOrderItem(orderItem);
            Console.WriteLine($"The product was successfully updated:\n" + orderItem);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region SHOW
    /// <summary>
    /// Print specific order item by ID
    /// </summary>
    public static void ShowOrderItem()
    {
        int IdOrderItem = SafeInput.IntegerInput("Enter order item ID to show: ");
        try
        {
            OrderItem orderItem = dalOrderItem.GetOrderItem(IdOrderItem);
            Console.WriteLine(orderItem);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }

    /// <summary>
    /// Print specific order item by order and product ID
    /// </summary>
    public static void ShowOrderItemByOrderAndCustomer()
    {
        int orderID = SafeInput.IntegerInput("Enter Order item's order ID: ");
        int productID = SafeInput.IntegerInput("Enter Order item's product ID: ");
        try
        {
            OrderItem orderItem = dalOrderItem.GetOrderItem(orderID, productID);
            Console.WriteLine(orderItem);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }

    /// <summary>
    /// Print all order items
    /// </summary>
    public static void ShowListOfOrderItems()
    {
        OrderItem[] orderItems = dalOrderItem.GetAllOrderItems();
        foreach (OrderItem orderItem in orderItems)
        {
            Console.WriteLine(orderItem);
        }
    }

    /// <summary>
    /// Print all order order items
    /// </summary>
    public static void ShowListOfOrderOrderItems()
    {
        int orderID = SafeInput.IntegerInput("Enter Order item's order ID: ");
        try
        {
            OrderItem[] orderItems = dalOrderItem.GetAllOrderItems(orderID);
            foreach (OrderItem orderItem in orderItems)
            {
                Console.WriteLine(orderItem);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region DELETE
    /// <summary>
    /// Delete order item by ID
    /// </summary>
    public static void DeleteOrderItem()
    {
        int IdOrderIthem = SafeInput.IntegerInput("Enter order item ID to delete: ");
        try
        {
            dalOrderItem.DeleteOrderItem(IdOrderIthem);
            Console.WriteLine("The order item was successfully deleted\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region MENU
    /// <summary>
    /// Print order item menu and calls the appropriate method
    /// </summary>
    public static void OrderItemMenu()
    {
        OrderItemMenu OrderItemchoise = Dal.OrderItemMenu.AddOrderItems;
        while (!OrderItemchoise.Equals(Dal.OrderItemMenu.GoBack))
        {
            OrderItemchoise = (OrderItemMenu)SafeInput.IntegerInput(
               "To Add an Order item - press 1\n" +
               "To Update an Order item - press 2\n" +
               "To Show an Order item by ID - press 3\n" +
               "To Show an Order item by order and product ID's - press 4\n" +
               "To Show Order items list - press 5\n" +
               "To Show an specific Order's order items list - press 6\n" +
               "To Delete an Order item - press 7\n" +
               "To Return back to the menu - press 0\n\n");

            switch (OrderItemchoise)
            {
                case Dal.OrderItemMenu.AddOrderItems:
                    AddNewOrderItem();
                    break;
                case Dal.OrderItemMenu.UpdateOrderItems:
                    UpdateOrderItem();
                    break;
                case Dal.OrderItemMenu.ShowOrderItemByID:
                    ShowOrderItem();
                    break;
                case Dal.OrderItemMenu.ShowOrderItemByProductAndCustomerID:
                    ShowOrderItemByOrderAndCustomer();
                    break;
                case Dal.OrderItemMenu.ShowOrderItemsListOfSpecificOrder:
                    ShowListOfOrderOrderItems();
                    break;
                case Dal.OrderItemMenu.ShowListOfOrderItems:
                    ShowListOfOrderItems();
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