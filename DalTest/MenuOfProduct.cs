using DO;
using System.Xml.Linq;

namespace Dal;

internal class MenuOfProduct
{
    private static DalProduct dalProduct = new();
    #region Add New Product
    public static void AddNewProduct()
    {
        Console.WriteLine("for add a new Order Item, please fill in the following data:");

        int ID = SafeInput.IntegerInput("ID: ");
        string name = SafeInput.StringInput("Name:");
        double price = SafeInput.DoubleInput("Price: ");
        Console.WriteLine("Category: ");
        CategoryOfProduct category = (CategoryOfProduct)SafeInput.IntegerInput
            ("Category Of Product:\n" +
            "X - press 1\n" +
            "Y- press 2\n" +
            "Z - press 3\n");
        int InStock = SafeInput.IntegerInput("InStock: ");
        Console.WriteLine("Adding a new Product...");
        Product product = new()
        {
            ID = ID,
            Name = name,
            Price = price,
            Category = category,
            InStock = InStock
        };
        int productID = dalProduct.AddProduct(product);
        Console.WriteLine("The new Product was successfully added\n");
    }
    #endregion

    #region Update Product
    public static void UpdateProduct()
    {
        throw new NotImplementedException();

        int ID = SafeInput.IntegerInput("Plese enter the ID of product that you wont to update: ");
        Product newProduct = dalProduct.GetProduct(ID);
        // USer input of product item properties
        if (newProduct.Name != "")
            newProduct.Name = newProduct.Name;
        if (newProduct.Price != 0.0)
            newProduct.Price = newProduct.Price;
        if (newProduct.Category != 0)
            newProduct.Category = newProduct.Category;
        if (newProduct.InStock != 0)
            newProduct.InStock = newProduct.InStock;
        return;

    }
    #endregion

    #region Show Product
    public static void ShowProduct()
    {
        int IdProduct = SafeInput.IntegerInput("ID: ");
        Console.WriteLine(dalProduct.GetProduct(IdProduct));
    }
    #endregion

    #region Show List Product
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
        int IdProduct = SafeInput.IntegerInput("Enter product ID: ");
        try
        {
            dalProduct.DeleteProduct(IdProduct);
        }
        catch(Exception ex)
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