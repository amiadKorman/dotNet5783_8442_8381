using DalApi;
using DO;

namespace Dal;

internal static class DataSource
{
    /// <summary>
    /// Random number field
    /// </summary>
    private static readonly Random RandomNumber = new();

    /// <summary>
    /// List of customers
    /// </summary>
    internal static List<Customer?> customers = new();

    /// <summary>
    /// List of orders
    /// </summary>
    internal static List<Order?> orders = new();

    /// <summary>
    /// List of order items 
    /// </summary>
    internal static List<OrderItem?> orderItems = new();

    /// <summary>
    /// List of products
    /// </summary>
    internal static List<Product> products = new();

    internal static class Config
    {
        internal const int startOrderNumber = 1000000;
        private static int orderItemID = startOrderNumber;
        internal static int NextOrderID { get => orderID++; }

        internal const int startOrderItemNumber = 5000000;
        private static int orderID = startOrderItemNumber;
        internal static int NextOrderItemID { get => orderItemID++; }
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
        products.Add(
            new()
            {
                ID = 100000,
                Name = "Apple iPhone 14 128GB",
                Price = 3749,
                Category = CategoryOfProduct.Phones,
                InStock = RandomNumber.Next(50)
            });
        products.Add(
            new()
            {
                ID = 100001,
                Name = "Apple iPhone 14 Pro 256GB",
                Price = 5445,
                Category = CategoryOfProduct.Phones,
                InStock = RandomNumber.Next(50)
            });
        products.Add(
            new()
            {
                ID = 100002,
                Name = "Apple iPhone 14 Pro Max 512GB",
                Price = 7499,
                Category = CategoryOfProduct.Phones,
                InStock = RandomNumber.Next(50)
            });
        products.Add(
            new()
            {
                ID = 100100,
                Name = "Apple MacBook Pro 16 2TB",
                Price = 15890,
                Category = CategoryOfProduct.Laptops,
                InStock = RandomNumber.Next(50)
            });
        products.Add(
            new()
            {
                ID = 100101,
                Name = "Apple MacBook Pro 14 512GB",
                Price = 13590,
                Category = CategoryOfProduct.Laptops,
                InStock = RandomNumber.Next(50)
            });
        products.Add(
            new()
            {
                ID = 100110,
                Name = "Dell XPS 17 1TB",
                Price = 16290,
                Category = CategoryOfProduct.Laptops,
                InStock = RandomNumber.Next(50)
            });
        products.Add(
            new()
            {
                ID = 100111,
                Name = "Dell XPS 15 1TB",
                Price = 12649,
                Category = CategoryOfProduct.Laptops,
                InStock = RandomNumber.Next(50)
            });
        products.Add(
            new()
            {
                ID = 100300,
                Name = "Samsung Odyssey 48.7'' 4K",
                Price = 11870,
                Category = CategoryOfProduct.Screens,
                InStock = RandomNumber.Next(50)
            });
        products.Add(
            new()
            {
                ID = 100310,
                Name = "ASUS ROG Strix 43'' 4K",
                Price = 7849,
                Category = CategoryOfProduct.Screens,
                InStock = RandomNumber.Next(50)
            });
        products.Add(
            new()
            {
                ID = 100400,
                Name = "Samsung 75'' Neo QLED 8K",
                Price = 29990,
                Category = CategoryOfProduct.Televisions,
                InStock = RandomNumber.Next(50)
            });
        products.Add(
            new()
            {
                ID = 100410,
                Name = "Sony Bravia OLED 77'' 4K",
                Price = 14280,
                Category = CategoryOfProduct.Televisions,
                InStock = RandomNumber.Next(50)
            });
        products.Add(
            new()
            {
                ID = 100500,
                Name = "Logitech MX Master 3S",
                Price = 469,
                Category = CategoryOfProduct.Accessories,
                InStock = RandomNumber.Next(50)
            });
        products.Add(
            new()
            {
                ID = 100510,
                Name = "Logitech MX Mechanical",
                Price = 699,
                Category = CategoryOfProduct.Accessories,
                InStock = RandomNumber.Next(50)
            });
    }

    /// <summary>
    /// Initialize array with customers
    /// </summary>
    private static void InitializeCustomers()
    {
        for (int i = 1; i < 6; i++)
        {
            customers.Add(
                new()
                {
                    ID = RandomNumber.Next(100000000, 1000000000),
                    Name = ((Names)i).ToString(),
                    Email = $"{((Names)i).ToString() + i}@gmail.com",
                    Address = $"{(Cities)RandomNumber.Next(1, 6)} {(Streets)RandomNumber.Next(1, 5)} {i}"
                });
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
                ID = Config.NextOrderID,
                CustomerID = customers[RandomNumber.Next(customers.Count)].Value.ID,
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
            orders.Add(order);
        }
    }

    /// <summary>
    /// Initialize array with order items
    /// </summary>
    private static void InitializeOrderItems()
    {
        for (int i = 0; i < 40; i++)
        {
            Product? product = products[RandomNumber.Next(products.Count)];
            orderItems.Add(
                new()
                {
                    ID = Config.NextOrderItemID,
                    ProductID = product?.ID ?? 0,
                    OrderID = RandomNumber.Next(Config.startOrderNumber, Config.startOrderNumber + orders.Count),
                    Price = product?.Price ?? 0,
                    Amount = RandomNumber.Next(5),
                });
        }
    }

}
