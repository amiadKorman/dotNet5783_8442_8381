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
    private static void AddNewProductToCart()
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

    /// <summary>
    /// Confirm order
    /// </summary>
    private static void ConfirmOrder()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update amount of item in cart
    /// </summary>
    private static void UpdateProductAmount()
    {
        throw new NotImplementedException();
    }


    #region MENU
    /// <summary>
    /// Print order item menu and calls the appropriate method
    /// </summary>
    public static void CartMenu()
    {
        EnumCartMenu OrderItemchoise = EnumCartMenu.ConfirmOrder;
        while (!OrderItemchoise.Equals(EnumCartMenu.GoBack))
        {
            OrderItemchoise = (EnumCartMenu)SafeInput.IntegerInput(
               "To Add prodact to cart - press 1\n" +
               "To Update Product Amount - press 2\n" +
               "To Confirm Order - press 3\n" +
               "To Return back to the menu - press 0\n\n");

            switch (OrderItemchoise)
            {
                case EnumCartMenu.AddProductToCart:
                    AddNewProductToCart();
                    break;
                case EnumCartMenu.UpdateProductAmount:
                    UpdateProductAmount();
                    break;
                case EnumCartMenu.ConfirmOrder:
                    ConfirmOrder();
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
