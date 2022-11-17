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

        internal static int GetOrderID { get => orderID++; }
        internal static int GetOrderItemID { get => orderItemID++; }
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
        InitializeOrders();
        InitializeOrderItems();
    }

    /// <summary>
    /// Initialize array with products
    /// </summary>
    private static void InitializeProducts()
    {
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = 100000,
            Name = "Apple iPhone 14 128GB",
            Price = 3749,
            Category = CategoryOfProduct.Phones,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = 100001,
            Name = "Apple iPhone 14 Pro 256GB",
            Price = 5445,
            Category = CategoryOfProduct.Phones,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = 100002,
            Name = "Apple iPhone 14 Pro Max 512GB",
            Price = 7499,
            Category = CategoryOfProduct.Phones,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = 100100,
            Name = "Apple MacBook Pro 16 2TB",
            Price = 15890,
            Category = CategoryOfProduct.Laptops,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = 100101,
            Name = "Apple MacBook Pro 14 512GB",
            Price = 13590,
            Category = CategoryOfProduct.Laptops,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = 100110,
            Name = "Dell XPS 17 1TB",
            Price = 16290,
            Category = CategoryOfProduct.Laptops,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = 100111,
            Name = "Dell XPS 15 1TB",
            Price = 12649,
            Category = CategoryOfProduct.Laptops,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = 100300,
            Name = "Samsung Odyssey 48.7'' 4K",
            Price = 11870,
            Category = CategoryOfProduct.Screens,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = 100310,
            Name = "ASUS ROG Strix 43'' 4K",
            Price = 7849,
            Category = CategoryOfProduct.Screens,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = 100400,
            Name = "Samsung 75'' Neo QLED 8K",
            Price = 29990,
            Category = CategoryOfProduct.Televisions,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = 100410,
            Name = "Sony Bravia OLED 77'' 4K",
            Price = 14280,
            Category = CategoryOfProduct.Televisions,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = 100500,
            Name = "Logitech MX Master 3S",
            Price = 469,
            Category = CategoryOfProduct.Accessories,
            InStock = RandomNumber.Next(50)
        };
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = 100510,
            Name = "Logitech MX Mechanical",
            Price = 699,
            Category = CategoryOfProduct.Accessories,
            InStock = RandomNumber.Next(50)
        };
    }

    /// <summary>
    /// Initialize array with customers
    /// </summary>
    private static void InitializeCustomers()
    {
        for (int i = 0; i < 5; i++)
        {
            customersArray[Config.customersLastIndex++] = new()
            {
                ID = RandomNumber.Next(100000000, 1000000000),
                Name = ((Names)i).ToString(),
                Email = $"{((Names)i).ToString() + i}@gmail.com",
                Address = $"{(Cities)RandomNumber.Next(5)} {(Streets)RandomNumber.Next(4)} {i}"
            };
        }
    }

    /// <summary>
    /// Initialize array with orders
    /// </summary>
    private static void InitializeOrders()
    {
        for (int i = 0; i < 20; i++)
        {
            Order order = new()
            {
                ID = Config.GetOrderID,
                Customer = customersArray[RandomNumber.Next(Config.customersLastIndex)],
            };
            bool shipped = RandomNumber.NextDouble() < 0.7D;
            if (shipped)
            {
                bool delivered = RandomNumber.NextDouble() < 0.3D;
                if (delivered)
                {
                    order.DeliveryDate = DateTime.Now - new TimeSpan(RandomNumber.NextInt64(TimeSpan.TicksPerDay));
                    order.ShipDate = order.DeliveryDate - new TimeSpan(RandomNumber.NextInt64(TimeSpan.TicksPerDay * 18));
                }
                else
                {
                    order.ShipDate = DateTime.Now - new TimeSpan(RandomNumber.NextInt64(TimeSpan.TicksPerDay * 10));
                }
                order.OrderDate = (DateTime)order.ShipDate - new TimeSpan(RandomNumber.NextInt64(TimeSpan.TicksPerDay * 3));
            }
            else
            {
                order.OrderDate = DateTime.Now - new TimeSpan(RandomNumber.NextInt64(TimeSpan.TicksPerDay * 3));
            }
        }
    }

    /// <summary>
    /// Initialize array with order items
    /// </summary>
    private static void InitializeOrderItems()
    {
        for (int i = 0; i < 40; i++)
        {
            Product product = productsArray[RandomNumber.Next(Config.productsLastIndex)];
            orderItemsArray[Config.orderItemsLastIndex++] = new OrderItem
            {
                ID = Config.GetOrderItemID,
                ProductID = product.ID,
                OrderID = (ordersArray[RandomNumber.Next(20)]).ID,
                Price = product.Price,
                Amount = RandomNumber.Next(5),
            };
        }
    }

}
