namespace Dal;

public class DalMain
{
    #region Mainaly Main
    public static void Main(string[] args)
    {
        EntitysMenu MenuChoise = EntitysMenu.OrderMenu;
        while (!MenuChoise.Equals(EntitysMenu.Exit))
        {
            MenuChoise = (EntitysMenu)SafeInput.IntegerInput(
                "For Order Menu - press 1\n" +
                "For Order Item Menu - press 2\n" +
                "For Product Menu - press 3\n" +
                "For Customer Menu - press 4" +
                "For Exit - press 0\n\n");

            switch (MenuChoise)
            {
                case EntitysMenu.OrderMenu:
                    MenuOfOrder.OrderMenu();
                    break;
                case EntitysMenu.OrderItemsMenu:
                    MenuOfOrderItems.OrderItemMenu();
                    break;
                case EntitysMenu.ProductMenu:
                    MenuOfProduct.ProductMenu();
                    break;
                case EntitysMenu.CustomerMenu:
                    MenuOfCustomer.CustomerMenu();
                    break;
                case EntitysMenu.Exit:
                    break;
                default:
                    Console.WriteLine("Error. Try again");
                    break;
            }
        }
    }
    #endregion
}