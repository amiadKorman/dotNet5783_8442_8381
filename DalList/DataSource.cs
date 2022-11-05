using DO;


namespace Dal;

internal static class DataSource
{
    /// <summary>
    /// Random number for initialization
    /// </summary>
    static readonly Random RandomNumber = new();

    /// <summary>
    /// Array of orders
    /// </summary>
    internal static Order[] ordersArry = new Order[100];

    /// <summary>
    /// Array of order items
    /// </summary>
    internal static OrderItem[] orderItemsArry = new OrderItem[200];

    /// <summary>
    /// Array of products
    /// </summary>
    internal static Product[] productsArry = new Product[50];

    internal static class Config
    {
        internal static int productsLastIndex = 0;
        internal static int orderItemsLastIndex = 0;
        internal static int ordersLastIndex = 0;

        private static int orderItemID = 1000000;
        private static int orderID = 5000000;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    static DataSource()
    {
        s_Initialize();
    }

    private static void s_Initialize()
    {
        InitializeProducts();
        InitializeOrderItems();
        InitializeOrders();
    }
    private static void InitializeProducts()
    {
        productsArry[0] = new Product
        {
            ID = 100000,
            Name = "Apple iPhone 14 128GB",
            Price = 3749,
            Category = CategoryOfProduct.Phones,
            InStock = 10
        };
        productsArry[1] = new Product
        {
            ID = 100001,
            Name = "Apple iPhone 14 Pro 256GB",
            Price = 5445,
            Category = CategoryOfProduct.Phones,
            InStock = 5
        };
        productsArry[2] = new Product
        {
            ID = 100002,
            Name = "Apple iPhone 14 Pro Max 512GB",
            Price = 7499,
            Category = CategoryOfProduct.Phones,
            InStock = 0
        };
        productsArry[3] = new Product
        {
            ID = 100100,
            Name = "Apple MacBook Pro 16 2TB",
            Price = 15890,
            Category = CategoryOfProduct.Laptops,
            InStock = 7
        };
        productsArry[4] = new Product
        {
            ID = 100101,
            Name = "Apple MacBook Pro 14 512GB",
            Price = 13590,
            Category = CategoryOfProduct.Laptops,
            InStock = 9
        };
        productsArry[5] = new Product
        {
            ID = 100110,
            Name = "Dell XPS 17 1TB",
            Price = 16290,
            Category = CategoryOfProduct.Laptops,
            InStock = 4
        };
        productsArry[6] = new Product
        {
            ID = 100111,
            Name = "Dell XPS 15 1TB",
            Price = 12649,
            Category = CategoryOfProduct.Laptops,
            InStock = 2
        };
        productsArry[7] = new Product
        {
            ID = 100300,
            Name = "Samsung Odyssey 48.7'' 4K",
            Price = 11870,
            Category = CategoryOfProduct.Screens,
            InStock = 1
        };
        productsArry[8] = new Product
        {
            ID = 100310,
            Name = "ASUS ROG Strix 43'' 4K",
            Price = 7849,
            Category = CategoryOfProduct.Screens,
            InStock = 7
        };
        productsArry[9] = new Product
        {
            ID = 100400,
            Name = "Samsung 75'' Neo QLED 8K",
            Price = 29990,
            Category = CategoryOfProduct.Televisions,
            InStock = 10
        };
        productsArry[10] = new Product
        {
            ID = 100410,
            Name = "Sony Bravia OLED 77'' 4K",
            Price = 14280,
            Category = CategoryOfProduct.Televisions,
            InStock = 6
        };
        productsArry[11] = new Product
        {
            ID = 100500,
            Name = "Logitech MX Master 3S",
            Price = 469,
            Category = CategoryOfProduct.Accessories,
            InStock = 20
        };
        productsArry[12] = new Product
        {
            ID = 100510,
            Name = "Logitech MX Mechanical",
            Price = 699,
            Category = CategoryOfProduct.Accessories,
            InStock = 15
        };
    }

    private static void InitializeOrderItems()
    {
        for (int i = 0; i < 40; i++)
        {
            orderItemsArry[i] = new OrderItem
            {
                ProductID = i,
                OrderID = 100,
                Price = 100,
                Amount = 3,
            };
        }
    }

    private static void InitializeOrders()
    {
        for (int i = 0; i < 20; i++)
        {
            ordersArry[i] = new Order 
            { 
                ID = i,
                CustomerID = 212608442,
                OrderDate = DateTime.MinValue,
                ShipDate = DateTime.MinValue,
                DeliveryDate = DateTime.MinValue
            };
        }
    }




}
