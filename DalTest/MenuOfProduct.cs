﻿using DO;
using System.Xml.Linq;

namespace Dal;

internal class MenuOfProduct
{
    private static DalProduct dalProduct = new();
    #region Add New Product
    /// <summary>
    /// Add new product
    /// </summary>
    public static void AddNewProduct()
    {
        Console.WriteLine("To add a new product, please fill in the following data:");

        int ID = SafeInput.IntegerInput("ID: ");
        string name = SafeInput.StringInput("Name: ");
        double price = SafeInput.DoubleInput("Price: ");
        Console.WriteLine("Category: ");
        var categories = Enum.GetValues(typeof(CategoryOfProduct));
        foreach (var category in categories)
        {
            Console.WriteLine($"\tFor {category} - press {(int)category}");
        }
        CategoryOfProduct categorfy = (CategoryOfProduct)SafeInput.IntegerInput();
        int inStock = SafeInput.IntegerInput("In Stock: ");
        Console.WriteLine("Adding a new Product...");
        Product product = new()
        {
            ID = ID,
            Name = name,
            Price = price,
            Category = categorfy,
            InStock = inStock
        };
        try
        {
            int productID = dalProduct.AddProduct(product);
            Console.WriteLine($"The new product was successfully added with ID {productID}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region Update Product
    /// <summary>
    /// Update existing product
    /// </summary>
    public static void UpdateProduct()
    {
        int IDProduct = SafeInput.IntegerInput("Enter product ID to update: ");
        try
        {
            Product product = dalProduct.GetProduct(IDProduct);
            Console.WriteLine(product);
            Console.WriteLine("To update, please fill in the following data(-1 for no update):");
            // User input for product properties
            string name = SafeInput.StringInput("Name: ");
            double price = SafeInput.DoubleInput("Price: ");
            Console.WriteLine("Category: ");
            var categories = Enum.GetValues(typeof(CategoryOfProduct));
            foreach (var category in categories)
            {
                Console.WriteLine($"\tFor {category} - press {(int)category}");
            }
            Console.WriteLine($"\tFor no change - press 0");
            CategoryOfProduct categorfy = (CategoryOfProduct)SafeInput.IntegerInput();
            int inStock = SafeInput.IntegerInput("In Stock: ");
            // Checking for changes to update
            if (name != "-1")
                product.Name = name;
            if (price != -1)
                product.Price = price;
            if (categorfy != 0)
                product.Category = categorfy;
            if (inStock != -1)
                product.InStock = inStock;

            dalProduct.UpdateProduct(product);
            Console.WriteLine($"The product was successfully updated:\n" + product);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region SHOW
    /// <summary>
    /// Print specific product
    /// </summary>
    public static void ShowProduct()
    {
        int IDProduct = SafeInput.IntegerInput("Enter product ID to show: ");
        try
        {
            Product product = dalProduct.GetProduct(IDProduct);
            Console.WriteLine(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }

    /// <summary>
    /// Print all products
    /// </summary>
    public static void ShowListProduct()
    {
        Product[] products = dalProduct.GetAllProdoct();
        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }
    }
    #endregion

    #region DELETE
    /// <summary>
    /// Delete product by ID
    /// </summary>
    public static void DeleteProduct()
    {
        int IDProduct = SafeInput.IntegerInput("Enter product ID to delete: ");
        try
        {
            dalProduct.DeleteProduct(IDProduct);
            Console.WriteLine("The product was successfully deleted\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region MENU
    /// <summary>
    /// Print Product menu and calls the appropriate method
    /// </summary>
    public static void ProductMenu()
    {
        ProductMenu ProductChoise = Dal.ProductMenu.AddProduct;
        while (!ProductChoise.Equals(Dal.ProductMenu.GoBack))
        {
            ProductChoise = (ProductMenu)SafeInput.IntegerInput(
                "To Add a Product - press 1\n" +
                "To Update a Product - press 2\n" +
                "To Show a Product - press 3\n" +
                "To Show Products List - press 4\n" +
                "To Delete a Product - press 5\n" +
                "To Return back to the menu - press 0\n\n");

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
                case Dal.ProductMenu.GoBack:
                    break;
                default:
                    Console.WriteLine("This option doesn't exist, please try again\n");
                    break;
            }
        }
    }
    #endregion
}