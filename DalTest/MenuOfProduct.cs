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
        Product[] products = dalProduct.ShowAllProdoct();
        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }
    }
    #endregion

    #region Delete Product
    public static void DeleteProduct()
    {
        int Idproduct = SafeInput.IntegerInput("ID: ");
        dalProduct.DeleteProduct(Idproduct);
    }
    #endregion

    #region Product Menu
    public static void ProductMenu()
    {
        ProductMenu ProductChoise = Dal.ProductMenu.AddProduct;
        while (!ProductChoise.Equals(EntitysMenu.Exit))
        {
            ProductChoise = (ProductMenu)SafeInput.IntegerInput(
                "To Add a Product - press 1\n" +
                "To Update a Product - press 2\n" +
                "To Show a Product - press 3\n" +
                "To Show Products List - press 4\n" +
                "To Delete a Product List - press 5\n" +
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
                case Dal.ProductMenu.GoToTheFirstMenu:
                    break;
                default:
                    Console.WriteLine("This option does not exist, please try again\n");
                    break;
            }
        }
    }
    #endregion
}