using DO;

namespace BO;

public class OrderTracking
{
    /// <summary>
    /// Order ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Order status
    /// </summary>
    public OrderStatus Status { get; set; }

    public override string ToString() => $@"
    Order ID: {ID}
    Order Status: {Status}
    ";
}
