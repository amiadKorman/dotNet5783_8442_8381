﻿using DO;

namespace Dal;

internal class MenuOfProduct
{

    #region Add New Product
    public static void AddNewProduct()
    {
        Console.WriteLine("for add a new Order Item, please fill in the following data:");

        int ID = SafeInput.IntegerInput("ID: ");
        string Name = SafeInput.stringInput("Name:" );
        double Price = SafeInput.DoubleInput("Price: ");
        Console.WriteLine("Category: ");
        CategoryOfProduct CategoryOf = (CategoryOfProduct)SafeInput.IntegerInput
            ("Category Of Product:\n" +
            "X - press 1\n" +
            "Y- press 2\n" +
            "Z - press 3\n");
        int InStock = SafeInput.IntegerInput("InStock: ");
        Console.WriteLine("Adding a new Product...");
        DalProduct.AddProduct(ID, Name, Price, CategoryOf, InStock);
        Console.WriteLine("The new Product was successfully added\n");
    }
    #endregion

    #region Update Product
    public static void UpdateProduct()
    {
        

    }
    #endregion

    #region Show Product
    public static void ShowProduct()
    {
        int IdProduct = SafeInput.IntegerInput("ID: ");
        Console.WriteLine(DalProduct.GetProduct(IdProduct));

    }
    #endregion

    #region Show List Product
    public static void ShowListProduct()
    {
        DalProduct.ShowAllProdoct();
    }
    #endregion

    #region Delete Product
    public static void DeleteProduct()
    {
        int Idproduct = SafeInput.IntegerInput("ID: ");
        DalProduct.DeleteProduct(Idproduct);
    }
    #endregion
    
    public static void ProductMenu()
    {
        ProductMenu ProductChoise = Dal.ProductMenu.AddProduct;
        while (!ProductChoise.Equals(EntitysMenu.Exit))
        {
            Console.WriteLine("for add Order - press 1\n" +
        "for Update Order - press 2\n" +
        "for show order - press 3\n" +
        "for show order list - press 4\n" +
        "for delete order - press 5\n");
        }
        switch (ProductChoise)
        {
            case Dal.ProductMenu.AddProduct:
                AddNewProduct();
                break;
            case Dal.ProductMenu.UpdateProduct:
                UpdateProduct();
                break;
            case Dal.ProductMenu.ShowProduct:
                ShowProduct();
                break;
            case Dal.ProductMenu.ShowListOfProduct:
                ShowListProduct();
                break;
            case Dal.ProductMenu.DeleteAProduct:
                DeleteProduct();
                break;
            default:
                Console.WriteLine("This option does not exist, please try again\n");
                break;

        }
    }
}
