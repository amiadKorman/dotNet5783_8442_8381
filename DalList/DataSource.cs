using DO;

namespace Dal;

internal static class DataSource
{
    /// <summary>
    /// Random number for initialization
    /// </summary>
    static readonly Random RandomNumber = new();

    /// <summary>
    /// Array of customers
    /// </summary>
    internal static Customer[] customersArray = new Customer[20];

    /// <summary>
    /// Array of orders
    /// </summary>
    internal static Order[] ordersArray = new Order[100];

    /// <summary>
    /// Array of order items
    /// </summary>
    internal static OrderItem[] orderItemsArray = new OrderItem[200];

    /// <summary>
    /// Array of products
    /// </summary>
    internal static Product[] productsArray = new Product[50];

    internal static class Config
    {
        internal static int productsLastIndex = 0;
        internal static int customersLastIndex = 0;
        internal static int orderItemsLastIndex = 0;
        internal static int ordersLastIndex = 0;

        private static int orderItemID = 1000000;
        private static int orderID = 5000000;

        internal static int getOrderID() { return orderID++; }
        internal static int getorderItemID() { return orderItemID++; }
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
        InitializeCustomers();
        InitializeOrderItems();
        InitializeOrders();
    }

    private static void InitializeProducts()
    {
        productsArray[Config.productsLastIndex++] = new Product
        {
            ID = 100000,
            Name = "Apple iPhone 14 128GB",
            Price = 3749,
            Category = CategoryOfProduct.Phones,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new Product
        {
            ID = 100001,
            Name = "Apple iPhone 14 Pro 256GB",
            Price = 5445,
            Category = CategoryOfProduct.Phones,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new Product
        {
            ID = 100002,
            Name = "Apple iPhone 14 Pro Max 512GB",
            Price = 7499,
            Category = CategoryOfProduct.Phones,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new Product
        {
            ID = 100100,
            Name = "Apple MacBook Pro 16 2TB",
            Price = 15890,
            Category = CategoryOfProduct.Laptops,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new Product
        {
            ID = 100101,
            Name = "Apple MacBook Pro 14 512GB",
            Price = 13590,
            Category = CategoryOfProduct.Laptops,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new Product
        {
            ID = 100110,
            Name = "Dell XPS 17 1TB",
            Price = 16290,
            Category = CategoryOfProduct.Laptops,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new Product
        {
            ID = 100111,
            Name = "Dell XPS 15 1TB",
            Price = 12649,
            Category = CategoryOfProduct.Laptops,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new Product
        {
            ID = 100300,
            Name = "Samsung Odyssey 48.7'' 4K",
            Price = 11870,
            Category = CategoryOfProduct.Screens,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new Product
        {
            ID = 100310,
            Name = "ASUS ROG Strix 43'' 4K",
            Price = 7849,
            Category = CategoryOfProduct.Screens,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new Product
        {
            ID = 100400,
            Name = "Samsung 75'' Neo QLED 8K",
            Price = 29990,
            Category = CategoryOfProduct.Televisions,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new Product
        {
            ID = 100410,
            Name = "Sony Bravia OLED 77'' 4K",
            Price = 14280,
            Category = CategoryOfProduct.Televisions,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new Product
        {
            ID = 100500,
            Name = "Logitech MX Master 3S",
            Price = 469,
            Category = CategoryOfProduct.Accessories,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new Product
        {
            ID = 100510,
            Name = "Logitech MX Mechanical",
            Price = 699,
            Category = CategoryOfProduct.Accessories,
            InStock = RandomNumber.Next(50)
        };
    }

    private static void InitializeCustomers()
    {
        for (int i = 0; i < 5; i++)
        {
            customersArray[Config.customersLastIndex++] = new Customer
            {
                ID = RandomNumber.Next(100000000, 1000000000),
                Name = ((Names)i).ToString(),
                Email = $"{((Names)i).ToString() + i}@gmail.com",
                Address = $"{(Cities)RandomNumber.Next(5)} {(Streets)RandomNumber.Next(4)} {i}"
            };
        }
    }

    private static void InitializeOrders()
    {
        for (int i = 0; i < 20; i++)
        {
            ordersArray[Config.ordersLastIndex++] = new Order
            {
                ID = Config.getOrderID(),
                CustomerID = (customersArray[RandomNumber.Next(5)]).ID,
                OrderDate = DateTime.MinValue,
                ShipDate = DateTime.MinValue,
                DeliveryDate = DateTime.MinValue
            };
        }
    }

    private static void InitializeOrderItems()
    {
        for (int i = 0; i < 40; i++)
        {
            orderItemsArray[Config.orderItemsLastIndex++] = new OrderItem
            {
                ProductID = (productsArray[RandomNumber.Next(13)]).ID,
                OrderID = (ordersArray[RandomNumber.Next(20)]).ID,
                Price = 100,
                Amount = 3,
            };
        }
    }

}
