
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
}
