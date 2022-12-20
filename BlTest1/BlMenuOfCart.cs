using BlApi;
using BO;

namespace BlTest;

internal class BlMenuOfCart
{
    public static IBl ibl = new BlImplementation.Bl();

    #region ADD
    /// <summary>
    /// Add product to cart
    /// </summary>
    public static void AddNewProductToCart()
    {
        Console.WriteLine("To add a new product item to cart, please fill in the following data:");

        int productID = SafeInput.IntegerInput("Product ID: ");
        int amount = SafeInput.IntegerInput("Amount: ");
        int CustomerID = SafeInput.IntegerInput("CustomerID :");
        List<OrderItem>? Items = new List<OrderItem>();
        int totalPrice = 0;
        Console.WriteLine("Adding a new Order Item...");
        Cart cart = new()
        {
            TotalPrice = totalPrice,
            CustomerID = productID,
            Items = Items
        };
        try
        {
            ibl.Cart.Add(cart, productID);
            Console.WriteLine($"The Product was successfully added to cart{productID}\n");
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
    public static void CartMenu()
    {
        EnumCartMenu OrderItemchoise = EnumCartMenu.AddOrderItems;
        while (!OrderItemchoise.Equals(EnumCartMenu.GoBack))
        {
            OrderItemchoise = (EnumCartMenu)SafeInput.IntegerInput(
               "To Add prodact to cart - press 1\n" +
               "To Update an Order item - press 2\n" +
               "To Show an Order item by ID - press 3\n" +
               "To Show an Order item by order and product ID's - press 4\n" +
               "To Show Order items list - press 5\n" +
               "To Show an specific Order's order items list - press 6\n" +
               "To Delete an Order item - press 7\n" +
               "To Return back to the menu - press 0\n\n");

            switch (OrderItemchoise)
            {
                case EnumCartMenu.AddOrderItems:
                    AddNewProductToCart();
                    break;
                case EnumCartMenu.UpdateOrderItems:
                    //UpdateOrderItem();
                    break;
                case EnumCartMenu.ShowOrderItemByID:
                    //ShowOrderItem();
                    break;
                case EnumCartMenu.ShowOrderItemByProductAndCustomerID:
                    //ShowOrderItemByOrderAndCustomer();
                    break;
                case EnumCartMenu.ShowOrderItemsListOfSpecificOrder:
                    //ShowListOfOrderOrderItems();
                    break;
                case EnumCartMenu.ShowListOfOrderItems:
                    //ShowListOfOrderItems();
                    break;
                case EnumCartMenu.DeleteAnOrderItems:
                   //DeleteOrderItem();
                    break;
                case EnumCartMenu.GoBack:
                    break;
                default:
                    Console.WriteLine("This option doesn't exist, please try again\n");
                    break;
            }
        }
    }
    #endregion
}
