using BlApi;
using BO;

namespace BlTest;

public class BlMain
{
    #region Mainaly Main
    public static void Main(string[] args)
    {
        Cart cart = new();
        EnumsEntitysMenu MenuChoise = EnumsEntitysMenu.OrderMenu;
        while (!MenuChoise.Equals(EnumsEntitysMenu.Exit))
        {
            MenuChoise = (EnumsEntitysMenu)SafeInput.IntegerInput(
                "\nFor Order Menu - press 1\n" +
                "For Cart Menu - press 2\n" +
                "For Product Menu - press 3\n" +
                "For Exit - press 0\n\n");

            switch (MenuChoise)
            {
                case EnumsEntitysMenu.OrderMenu:
                    BlMenuOfOrder.OrderMenuBL();
                    break;
                case EnumsEntitysMenu.CartMenu:
                    BlMenuOfCart.CartMenu(cart);
                    break;
                case EnumsEntitysMenu.ProductMenu:
                    BlMenuOfProduct.ProductMenu(cart);
                    break;
                case EnumsEntitysMenu.Exit:
                    break;
                default:
                    Console.WriteLine("Error. Try again");
                    break;
            }
        }
    }
    #endregion
}
