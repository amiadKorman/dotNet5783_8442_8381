using BO;
using BlApi;

namespace BlTest;

internal class BlMenuOfCart
{
    public static IBl ibl = new BlImplementation.Bl();
    private static Cart MainCart;

    #region ADD
    /// <summary>
    /// Add product to cart
    /// </summary>
    /// <param name="cart"></param>
    private static void AddNewProductToCart()
    {
        int productID = SafeInput.IntegerInput("Enter product ID to add to cart: ");
        try
        {
            ibl.Cart.Add(MainCart, productID);
            Console.WriteLine("The Product was successfully added to cart\n");
        }
        catch (BlInvalidFieldException ex)
        {
            Console.WriteLine("Failed to add product to cart" + ex);
        }
        catch (BlDoesNotExistException ex)
        {
            Console.WriteLine("Failed to add product to cart" + ex);
        }
        catch (BlOutOfStockException ex)
        {
            Console.WriteLine("Failed to add product to cart" + ex);
        }
    }
    #endregion

    /// <summary>
    /// Buy all products in cart
    /// </summary>
    private static void BuyCart()
    {
        try
        {
            ibl.Cart.Buy(MainCart);
            Console.WriteLine("The cart was successfully bought\n");
        }
        catch (BlInvalidFieldException ex)
        {
            Console.WriteLine("Failed to buy cart" + ex);
        }
        catch (BlDoesNotExistException ex)
        {
            Console.WriteLine("Failed to buy cart" + ex);
        }
        catch (BlOutOfStockException ex)
        {
            Console.WriteLine("Failed to buy cart" + ex);
        }
    }
    
    /// <summary>
    /// Update amount of item in cart
    /// </summary>
    private static void UpdateProductAmount()
    {
        int productID = SafeInput.IntegerInput("Enter product ID to update: ");
        int amount = SafeInput.IntegerInput("Enter new amount: ");
        try
        {
            MainCart = ibl.Cart.Update(MainCart, productID, amount);
        }
        catch (BlInvalidFieldException ex)
        {
            Console.WriteLine("Failed to update product" + ex);
        }
        catch (BlDoesNotExistException ex)
        {
            Console.WriteLine("Failed to update product" + ex);
        }
        catch (BlOutOfStockException ex)
        {
            Console.WriteLine("Failed to update product" + ex);
        }
    }

    #region MENU
    /// <summary>
    /// Print order item menu and calls the appropriate method
    /// </summary>
    public static void CartMenu(Cart cart)
    {
        MainCart = cart;
        EnumCartMenu OrderItemchoise = EnumCartMenu.BuyCart;
        while (!OrderItemchoise.Equals(EnumCartMenu.GoBack))
        {
            OrderItemchoise = (EnumCartMenu)SafeInput.IntegerInput(
               "\nTo Add prodact to cart - press 1\n" +
               "To Update Product Amount - press 2\n" +
               "To Buy Cart - press 3\n" +
               "To Return back to the menu - press 0\n\n");

            switch (OrderItemchoise)
            {
                case EnumCartMenu.AddProductToCart:
                    AddNewProductToCart();
                    break;
                case EnumCartMenu.UpdateProductAmount:
                    UpdateProductAmount();
                    break;
                case EnumCartMenu.BuyCart:
                    BuyCart();
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
