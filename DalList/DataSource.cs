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
        for (int i = 0; i < 10; i++)
        {
            productsArry[i] = new Product
            {
                ID = 100000 + i,
                Name = "something",
                Price = 100,
                Category = CategoryOfProduct.Tech,
                InStock = 10
            };
        }
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
                CustomerName = "a",
                CustomerEmail =  "harta@gmail.com",
                CustomerAdress = "Jerus",
                OrderDate = DateTime.MinValue,
                ShipDate = DateTime.MinValue,
                DeliveryDate = DateTime.MinValue
            };
        }
    }




}
