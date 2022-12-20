using BO;
using BlApi;

namespace BlTest;

internal class BlMenuOfProduct
{
    private static IBl ibl = new BlImplementation.Bl();

    #region ADD
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
        var categories = Enum.GetValues(typeof(Category));
        foreach (var category in categories)
        {
            Console.WriteLine($"\tFor {category} - press {(int)category}");
        }
        Category categorfy = (Category)SafeInput.IntegerInput();
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
            int productID = ID;
            ibl.Product.Add(product);
            Console.WriteLine($"The new product was successfully added with ID {productID}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region UPDATE
    /// <summary>
    /// Update existing product
    /// </summary>
    public static void UpdateProduct()
    {
        int IDProduct = SafeInput.IntegerInput("Enter product ID to update: ");
        try
        {
            Product product = ibl.Product.Get(IDProduct);
            Console.WriteLine(product);
            Console.WriteLine("To update, please fill in the following data(leave empty for no update):");
            // User input for product properties
            double? price = SafeInput.NullDoubleInput("Price: ");
            int? inStock = SafeInput.NullIntegerInput("In Stock: ");
            // Checking for changes to update
            if (price.HasValue)
                product.Price = price.Value;
            if (inStock.HasValue)
                product.InStock = inStock.Value;

            ibl.Product.Update(product);
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
            Product product = ibl.Product.Get(IDProduct) as Product;
            Console.WriteLine(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region Show All
    /// <summary>
    /// Print all products
    /// </summary>
    public static void ShowListProduct()
    {
        IEnumerable<Product?> products = (IEnumerable<Product?>)ibl.Product.GetAll();
        foreach (Product? product in products)
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
            ibl.Product.Delete(IDProduct);
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
    /// Print product menu and calls the appropriate method
    /// </summary>
    public static void ProductMenu()
    {
        EnumsProductMenu ProductChoise = EnumsProductMenu.AddProduct;
        while (!ProductChoise.Equals(EnumsProductMenu.GoBack))
        {
            ProductChoise = (EnumsProductMenu)SafeInput.IntegerInput(
                "To Add a Product - press 1\n" +
                "To Update a Product - press 2\n" +
                "To Show a Product - press 3\n" +
                "To Show Products List - press 4\n" +
                "To Delete a Product - press 5\n" +
                "To Return back to the menu - press 0\n\n");

            switch (ProductChoise)
            {
                case EnumsProductMenu.AddProduct:
                    AddNewProduct();
                    break;
                case EnumsProductMenu.UpdateProduct:
                   UpdateProduct();
                    break;
                case EnumsProductMenu.ShowProduct:
                    ShowProduct();
                    break;
                case EnumsProductMenu.ShowListOfProduct:
                   ShowListProduct();
                    break;
                case EnumsProductMenu.DeleteAProduct:
                    DeleteProduct();
                    break;
                case EnumsProductMenu.GoBack:                        
                    break;
                default:
                    Console.WriteLine("This option doesn't exist, please try again\n");
                    break;
            }
        }
    }
    #endregion
}
