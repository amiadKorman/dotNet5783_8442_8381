using DO;

namespace Dal;

/// <summary>
/// Database for DalList
/// </summary>
internal sealed class DataSource
{
    internal static DataSource instance { get; }

    private DataSource() => s_Initialize();

    static DataSource() => instance = new DataSource();

    /// <summary>
    /// Random number field
    /// </summary>
    private static readonly Random RandomNumber = new();

    /// <summary>
    /// List of customers
    /// </summary>
    internal List<Customer?> customers = new();

    /// <summary>
    /// List of orders
    /// </summary>
    internal List<Order?> orders = new();

    /// <summary>
    /// List of order items 
    /// </summary>
    internal List<OrderItem?> orderItems = new();

    /// <summary>
    /// List of products
    /// </summary>
    internal List<Product?> products = new();

    internal static class Config
    {
        internal const int startOrderNumber = 1000000;
        private static int orderID = startOrderNumber;
        internal static int NextOrderID { get => orderID++; }

        internal const int startOrderItemNumber = 5000000;
        private static int orderItemID = startOrderItemNumber;
        internal static int NextOrderItemID { get => orderItemID++; }
    }

    /// <summary>
    /// Initilazing all entities lists
    /// </summary>
    private void s_Initialize()
    {
        InitializeProducts();
        InitializeCustomers();
        InitializeOrders();
        InitializeOrderItems();
    }

    /// <summary>
    /// Initialize products list
    /// </summary>
    private void InitializeProducts()
    {
        #region Initialize Products
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
        products.Add(
new()
{
    ID = 100510,
    Name = "iPhone X 64GB",
    Price = 2495,
    Category = CategoryOfProduct.Phones,
    InStock = 50
});

        products.Add(
        new()
        {
            ID = 100511,
            Name = "iPhone X 256GB",
            Price = 2995,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100512,
            Name = "Samsung Galaxy S9 64GB",
            Price = 1999,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100513,
            Name = "Google Pixel 2 64GB",
            Price = 1449,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100514,
            Name = "Google Pixel 2 128GB",
            Price = 1699,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });
        products.Add(
new()
{
    ID = 100515,
    Name = "Samsung Galaxy Note 8 64GB",
    Price = 1799,
    Category = CategoryOfProduct.Phones,
    InStock = 50
});

        products.Add(
        new()
        {
            ID = 100516,
            Name = "Samsung Galaxy S8 Plus 64GB",
            Price = 1499,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100517,
            Name = "Google Pixel XL 128GB",
            Price = 1699,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100518,
            Name = "OnePlus 5T 64GB",
            Price = 999,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100519,
            Name = "OnePlus 5T 128GB",
            Price = 1099,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });
        products.Add(
new()
{
    ID = 100520,
    Name = "Nokia 9 128GB",
    Price = 899,
    Category = CategoryOfProduct.Phones,
    InStock = 50
});

        products.Add(
        new()
        {
            ID = 100521,
            Name = "Sony Xperia XZ2 64GB",
            Price = 1499,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100522,
            Name = "Huawei Mate 10 Pro 128GB",
            Price = 1099,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100523,
            Name = "Huawei P20 Pro 128GB",
            Price = 1449,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100524,
            Name = "Xiaomi Mi Mix 2S 128GB",
            Price = 999,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100525,
            Name = "Xiaomi Mi A2 64GB",
            Price = 599,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100526,
            Name = "LG G7 ThinQ 64GB",
            Price = 1199,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100527,
            Name = "HTC U12+ 128GB",
            Price = 1199,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
new()
{
    ID = 100528,
    Name = "Samsung Galaxy S9 Plus 64GB",
    Price = 1449,
    Category = CategoryOfProduct.Phones,
    InStock = 50
});

        products.Add(
        new()
        {
            ID = 100529,
            Name = "Samsung Galaxy Note 9 128GB",
            Price = 1699,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100530,
            Name = "Apple iPhone XR 64GB",
            Price = 1449,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100531,
            Name = "Apple iPhone XS Max 512GB",
            Price = 2149,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100532,
            Name = "Google Pixel 3 XL 128GB",
            Price = 1449,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100533,
            Name = "OnePlus 6T 256GB",
            Price = 1299,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });

        products.Add(
new()
{
    ID = 100534,
    Name = "Nokia 8 Sirocco 128GB",
    Price = 1099,
    Category = CategoryOfProduct.Phones,
    InStock = 50
});

        products.Add(
        new()
        {
            ID = 100535,
            Name = "Xiaomi Mi 8 Pro 256GB",
            Price = 1199,
            Category = CategoryOfProduct.Phones,
            InStock = 50
        });
        products.Add(
new()
{
ID = 100536,
Name = "Apple MacBook Pro 15 inch 512GB",
Price = 2799,
Category = CategoryOfProduct.Laptops,
InStock = 50
});

        products.Add(
        new()
        {
            ID = 100537,
            Name = "Dell XPS 13 9370 256GB",
            Price = 1449,
            Category = CategoryOfProduct.Laptops,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100538,
            Name = "Microsoft Surface Pro 6 256GB",
            Price = 1699,
            Category = CategoryOfProduct.Laptops,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100539,
            Name = "Acer Swift 5 SF514-52T-76BI 512GB",
            Price = 1299,
            Category = CategoryOfProduct.Laptops,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100540,
            Name = "HP Spectre x360 13-ae051tu 512GB",
            Price = 1799,
            Category = CategoryOfProduct.Laptops,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100541,
            Name = "Lenovo Yoga 920 256GB",
            Price = 1099,
            Category = CategoryOfProduct.Laptops,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100542,
            Name = "Asus UX430UN-GV124T 256GB",
            Price = 1199,
            Category = CategoryOfProduct.Laptops,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100543,
            Name = "Razer Blade 15 512GB",
            Price = 2799,
            Category = CategoryOfProduct.Laptops,
            InStock = 50
        });

        products.Add(
new()
{
    ID = 100544,
    Name = "Samsung Notebook 9 Pro NP940X5M-X01US 512GB",
    Price = 1499,
    Category = CategoryOfProduct.Laptops,
    InStock = 50
});

        products.Add(
        new()
        {
            ID = 100545,
            Name = "Dell Inspiron 15 7570 256GB",
            Price = 799,
            Category = CategoryOfProduct.Laptops,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100546,
            Name = "Microsoft Surface Book 2 512GB",
            Price = 2199,
            Category = CategoryOfProduct.Laptops,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100547,
            Name = "Acer Chromebook R 13 CB5-312T-K1TF 256GB",
            Price = 499,
            Category = CategoryOfProduct.Laptops,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100548,
            Name = "HP Pavilion 15-cs1063cl 256GB",
            Price = 799,
            Category = CategoryOfProduct.Laptops,
            InStock = 50
        });
        products.Add(
new()
{
    ID = 100540,
    Name = "Apple AirPods",
    Price = 199,
    Category = CategoryOfProduct.Accessories,
    InStock = 50
});

        products.Add(
        new()
        {
            ID = 100541,
            Name = "Belkin Boost Up Wireless Charger",
            Price = 59,
            Category = CategoryOfProduct.Accessories,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100542,
            Name = "Anker PowerCore 10000 Portable Charger",
            Price = 25,
            Category = CategoryOfProduct.Accessories,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100543,
            Name = "Samsung Gear VR",
            Price = 99,
            Category = CategoryOfProduct.Accessories,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100544,
            Name = "Beats Solo3 Wireless On-Ear Headphones",
            Price = 299,
            Category = CategoryOfProduct.Accessories,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100545,
            Name = "Logitech K810 Illuminated Bluetooth Keyboard",
            Price = 99,
            Category = CategoryOfProduct.Accessories,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100546,
            Name = "Apple Pencil (2nd Generation)",
            Price = 129,
            Category = CategoryOfProduct.Accessories,
            InStock = 50
        });

        products.Add(
        new()
        {
            ID = 100547,
            Name = "Razer DeathAdder Elite Gaming Mouse",
            Price = 69,
            Category = CategoryOfProduct.Accessories,
            InStock = 50
        });






        #endregion
    }

    /// <summary>
    /// Initialize customers list
    /// </summary>
    private void InitializeCustomers()
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
    /// Initialize orders list
    /// </summary>
    private void InitializeOrders()
    {
        for (int i = 0; i < 20; i++)
        {
            Customer? customer = customers[RandomNumber.Next(customers.Count)];
            Order order = new()
            {
                ID = Config.NextOrderID,
                CustomerID = customer?.ID ?? 0
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
    /// Initialize order items list
    /// </summary>
    private void InitializeOrderItems()
    {
        for (int i = 0; i < orders.Count; i++)
        {
            Product? product = products[RandomNumber.Next(products.Count)];
            orderItems.Add(
                new()
                {
                    ID = Config.NextOrderItemID,
                    ProductID = product?.ID ?? 0,
                    OrderID = Config.startOrderNumber + i,
                    Price = product?.Price ?? 0,
                    Amount = RandomNumber.Next(1, 5),
                });
        }
        for (int i = 0; i < 20; i++)
        {
            Product? product = products[RandomNumber.Next(products.Count)];
            orderItems.Add(
                new()
                {
                    ID = Config.NextOrderItemID,
                    ProductID = product?.ID ?? 0,
                    OrderID = RandomNumber.Next(Config.startOrderNumber, Config.startOrderNumber + orders.Count),
                    Price = product?.Price ?? 0,
                    Amount = RandomNumber.Next(1, 5),
                });
        }
    }

}
