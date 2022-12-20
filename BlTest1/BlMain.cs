﻿using BO;

namespace BlTest;

/// <summary>
/// Main menu for testing BL
/// </summary>
public class BlMain
{
    #region Mainaly Main
    public static void Main(string[] args)
    {
        EnumsEntitysMenu MenuChoise = EnumsEntitysMenu.OrderMenu;
        while (!MenuChoise.Equals(EnumsEntitysMenu.Exit))
        {
            MenuChoise = (EnumsEntitysMenu)SafeInput.IntegerInput(
                "For Cart Menu - press 1\n" +
                "For Order Menu - press 2\n" +
                "For Product Menu - press 3\n" +
                "For Exit - press 0\n\n");

            switch (MenuChoise)
            {
                case EnumsEntitysMenu.CartMenu:
                    BlMenuOfCart.CartMenu();
                    break;
                case EnumsEntitysMenu.OrderMenu:
                    BlMenuOfOrder.OrderMenuBL();
                    break;
                case EnumsEntitysMenu.ProductMenu:
                    BlMenuOfProduct.ProductMenu();
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
