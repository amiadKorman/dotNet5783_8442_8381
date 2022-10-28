﻿
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
    internal static Order[] orders = new Order[100];

    /// <summary>
    /// Array of order items
    /// </summary>
    internal static OrderItem[] orderItems = new OrderItem[200];

    /// <summary>
    /// Array of products
    /// </summary>
    internal static Product[] products = new Product[50];

    internal static class Config
    {
        internal static int productsLastIndex = 0;
        internal static int orderItemsLastIndex = 0;
        internal static int ordersLastIndex = 0;

        private static int OrderItemID { get; } = 0;
        private static int OrderID { get; } = 0;
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
            products[i] = new Product
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
            orderItems[i] = new OrderItem
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
            orders[i] = new Order 
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
